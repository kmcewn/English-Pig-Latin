using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EngToPig
{
    public partial class EngToPig : Form
    {
        public EngToPig()
        {
            InitializeComponent();
        }
        /*/ Code Archive for btnEngToPig_Click (for QoL) 
         * [TAG001] Core Variables
         * [TAG002] The Main Code
         * [TAG003] Internal Variables
         * [TAG004] Check For New Line Character
         * [TAG005] Pull The Word Out
         * [TAG006] Handling The Whitelist
         * [TAG007] Defining The Word
         * [TAG008] Handling Special Starting Characters
         * [TAG009] Handling Special Ending Characters
         * [TAG010] Converting the Word To Pig Latin (all lowercase)
         * [TAG011] The Actual Converstion (all lowercase)
         * [TAG012] Converting the Word To Pig Latin (any capitals)
         * [TAG013] Checking for Vowels
         * [TAG014] Handling Capitalized One Letter Words
         * [TAG015] Handling Fully Capitalized Words (Vowel First)
         * [TAG016] When There's no Vowels
         * [TAG017] Check if a Word is Uppercase (No Starting Vowel)
         * [TAG018] Converting the Word (No Starting Vowel)
         * [TAG019] Cleanup and Add Word to the Pig Latin Sentence
         * 
         * [FUN001] Getting the Index 
         * [FUN002] Checking for Vowels (English to Pig Latin specific)
         * /*/

        /*/ [FUN001] Getting the Index; Check if at [Space] or [New Line] /*/
        private int getIndex(String Struct, int ind)
        {
            if ((Struct.IndexOf("\n") < ind && Struct.IndexOf("\n") != -1 && Struct.IndexOf("\n") != 0) || ind == -1) /*/ a condition to check if the next excusable space is a new line character rather than a space character (being a space where the word is spliced from) while ignoring if the new line character is the very first letter /*/
            {
                ind = Struct.IndexOf("\n"); /*/ if the conditions are met, the ind is set to the new line character that follows /*/
            }
            return ind;
        }

        /*/ [FUN002] Checking for Vowels (English to Pig Latin specific) /*/
        private int getFirstVowel(string checkFirstLetter, string aWord, int count)
        {
            while (!(checkFirstLetter == "a" || checkFirstLetter == "e" || checkFirstLetter == "i" || checkFirstLetter == "o" || checkFirstLetter == "u") && !(count == aWord.Length + 1)) /*/ as long as it is not on a vowel or at the end of the word, run through it /*/
            {
                if (!(count >= aWord.Length))
                {
                    checkFirstLetter = aWord[count].ToString().ToLower();
                }
                count += 1;
            }
            return count;
        }

        private void btnEngToPig_Click(object sender, EventArgs e)
        {
            /*/ [TAG001] Core Variables /*/
            string whiteList = "abcdefghijklmnopqrstuvwxyz,.?!' \n\"()"; /*/ A list of acceptable characters to parse into Pig Latin (including characters that are to be treated as acceptable by the parser) /*/
            string EngStruct = rtbEnglish.Text; /*/ The English sentence /*/
            string LatStruct = ""; /*/ The unparsed Pig Latin sentence /*/
            int ind; /*/ handles splicing of the English sentence into words /*/
            Boolean lastInd = false; /*/ Initially planned to check what the prior index was, now used to check if the last index has been reached /*/
            int foundChars = 0; /*/ Initially used for tracking if the word starts with quotes (due to parsing errors), now used to count the amount of characters in the starting position of the word for nicer parsing. /*/
            Boolean prevWordsAreCapital = false; /*/ in the case of single letter words, tracks if the previous words were capitals to smartly determine if I should be Iway or IWAY (as an example) /*/
            Boolean archPrevWordsAreCapital = false; /*/ tracks what the last value of prevWordsAreCapital is, allowing for it to become false when a period or other sentence ending character is inserted. /*/

            /*/ [TAG002] The Main Code /*/
            for (ind = EngStruct.IndexOf(" "); !lastInd; ind = EngStruct.IndexOf(" ")) /*/ parses through the English sentence, pulling the position of each space until it reaches the last index /*/
            {
                /*/ [TAG003] Internal Variables /*/
                string aWord; /*/ used to pull words (one at a time) out of the English sentence /*/
                string newWord = ""; /*/ used to create the new word for the Pig Latin sentence /*/
                Boolean failedWhitelist = true; /*/ a boolean check to ensure the pulled word is indeed capable of translating (as well as ignoring certain characters allowed by the translator for formatting) /*/
                string endAppend = "";  /*/ used when the word is being converted to append special characters at the end of the word, allowing it to exclude them from the conversion /*/
                int cropLength; /*/ used to crop the length of the word in accordance with what characters are at the end of the word (works in tandem with endAppend) /*/
                string checkFirstLetter; /*/ used to check each letter of the word starting at the first to see where the first vowel is /*/
                string tempWord; /*/ used to check if the word after the current word is capitalized (mainly only required for English to Pig Latin translations, to be removed when reversing the direction) /*/
                int newInd; /*/ handles the ind function for the tempWord, allowing the same operation to be done to get said word /*/
                string appendage; /*/ different from endAppend; used to determine what part of the word goes after the first part. Holds all the consonants that go before the vowels /*/

                /*/ [TAG004] Check For New Line Character /*/
                ind = getIndex(EngStruct, ind);


                /*/ [TAG005] Pull The Word Out /*/
                if (ind == -1) /*/ if neither a space or new line character exists /*/
                {
                    aWord = EngStruct; /*/ the word is the rest of the English sentence /*/
                    lastInd = true; /*/ inform the program we are on the last word /*/
                }
                else
                {
                    aWord = EngStruct.Substring(0, ind); /*/ the word is spliced form the English sentence /*/
                }


                /*/ [TAG006] Handling The Whitelist (ensure the word can translate) /*/
                for (int i = 0; i < aWord.Length && failedWhitelist; i++) /*/ a temporary count running through the pulled word /*/
                {
                    for (int j = 0; j < whiteList.Length && failedWhitelist; j++) /*/ a temporary count for each letter running through the whitelist until it finds an appropriate letter /*/
                    {
                        if (aWord[i].ToString().ToLower().Equals(whiteList[j].ToString().ToLower())) /*/ if the current letter matches any item in the whiteList /*/
                        {
                            failedWhitelist = false; /*/ for now it has not failed the white list test /*/
                        }
                    }
                    if (failedWhitelist) /*/ if it failed the whitelist test set i to the length to force it out of the loop /*/
                    {
                        i = aWord.Length;
                    }
                    else if (i + 1 != aWord.Length) /*/ if the loop is not at its end, turn the failed flag back on so it will keep iterating /*/
                    {
                        failedWhitelist = true;
                    }
                }


                /*/ [TAG007] Defining The Word /*/
                if (failedWhitelist) /*/ if it failed the whitelist, simply define the new word as the old word /*/
                {
                    newWord = aWord;
                }
                else /*/ otherwise, get into the meat and bones of the code /*/
                {
                    /*/ [TAG008] Handling Special Starting Characters /*/
                    while (aWord[0] == '\n' || aWord[0] == '\"' || aWord[0] == '\'' || aWord[0] == '(') /*/ Start by splicing out any special characters as allowed by the code at the start /*/
                    {
                        foundChars += 1; /*/ found one more special character /*/
                        LatStruct += aWord[0]; /*/ Rather than including it in the word, append it to the Pig Latin sentence /*/
                        aWord = aWord.Substring(1); /*/ remove the special character from the word /*/
                        EngStruct = EngStruct.Substring(1); /*/ remove the special character from the English sentence /*/
                    }

                    /*/ [TAG009] Handling Special Ending Characters /*/
                    cropLength = 0; /*/ start with a fresh crop length, as initially unknown if needed to crop /*/
                    while ((aWord[aWord.Length - cropLength - 1] == '"' || aWord[aWord.Length - cropLength - 1] == '?' || aWord[aWord.Length - cropLength - 1] == '.' || aWord[aWord.Length - cropLength - 1] == '!' || aWord[aWord.Length - cropLength - 1] == '\'' || aWord[aWord.Length - cropLength - 1] == ',' || aWord[aWord.Length - cropLength - 1] == '\'' || aWord[aWord.Length - cropLength - 1] == ')' || (aWord.Length > 2 && aWord.Substring(aWord.Length - cropLength - 2, 2) == "'s")) && aWord.Length - cropLength != 0)
                    { /*/ ^super long while statement to check if the last character (after cropping) matches any of the special character /*/
                        if (aWord.Substring(aWord.Length - cropLength - 2, 2) == "'s") /*/ was unsure on the rules of this but ultimately decided to add to end append function, if it has 's at the end, crop it out /*/
                        {
                            cropLength += 2; /*/ increase the crop by 2 characters ( accounting for 's ) /*/
                            endAppend = aWord.Substring(aWord.Length - cropLength, 2) + endAppend; /*/ add 's to the endAppend function /*/
                        }
                        else
                        { /*/ if it is literally any other special character run the below function, as they all cna be done with one statement /*/
                            cropLength += 1; /*/ increase the crop by 1 /*/
                            endAppend = aWord[aWord.Length - cropLength] + endAppend; /*/ add the character to the end appendage /*/
                            if (aWord[aWord.Length - cropLength] == '.' || aWord[aWord.Length - cropLength] == '!' || aWord[aWord.Length - cropLength] == '?') /*/ to handle single letter words, if the sentence ended change some details about capitalization /*/
                            {
                                archPrevWordsAreCapital = prevWordsAreCapital; /*/ archive the current value of prevWordsAreCapital (will be deleted at the end of the loop but used to handle current word) /*/
                                prevWordsAreCapital = false; /*/ State that the previous words are no longer capital in regard to the next word using it /*/
                            }
                        }
                    }


                    /*/ [TAG010] Converting the Word To Pig Latin (all lowercase) /*/
                    if (aWord[0].ToString().ToLower() == aWord[0].ToString()) /*/ if the entire word is lower case run through this, as there are different conditions for each /*/
                    {
                        prevWordsAreCapital = false; /*/ for the next word, note that the prior word was not capital /*/
                        checkFirstLetter = aWord[0].ToString().ToLower() /*/ find the first letter of the word /*/;
                        if (checkFirstLetter == "a" || checkFirstLetter == "e" || checkFirstLetter == "i" || checkFirstLetter == "o" || checkFirstLetter == "u") /*/ if said first letter was a vowel our work is done; convert the word /*/
                        {
                            newWord = aWord.Substring(0, aWord.Length - cropLength) + "way"; /*/ convert the word by simply adding "way" to it and ignoring the space that is cropped /*/
                        }
                        else /*/ otherwise, start checking other stuff /*/
                        {
                            appendage = ""; /*/ prepare to need to splice the word /*/
                            int count = getFirstVowel(checkFirstLetter, aWord, 1); /*/ determine where the first vowel is; will go beyond the length if none exist /*/
                            if (!(count > aWord.Length)) /*/ if the count is not at the end of the word, set the appendage to everything before the count position /*/
                            {
                                appendage = aWord.Substring(0, count - 1); /*/ set the appendage to the first portion of the word /*/
                            }
                            appendage += "ay"; /*/ add "ay" to the end of the appendage /*/

                            /*/ [TAG011] The Actual Converstion (all lowercase) /*/
                            if (count == aWord.Length + 1) /*/ if the count did not find a vowel /*/
                            {
                                newWord = aWord + appendage.Substring(appendage.Length - 2); /*/ the new word will be set to itself + "ay". was unclear on rules regarding this as there are basically no words that fit this but had to ensure it could run /*/
                            }
                            else /*/ otherwise /*/
                            {
                                newWord = aWord.Substring(count - 1, aWord.Length - (count - 1) - cropLength) + appendage; /*/ the new word is the second half of the word plus the appendage /*/
                            }
                        }
                    }

                    /*/ [TAG012] Converting the Word To Pig Latin (any capitals) /*/
                    else
                    {
                        checkFirstLetter = aWord[0].ToString().ToLower(); /*/ get the first letter /*/

                        /*/ [TAG013] Checking for Vowels /*/
                        if (checkFirstLetter == "a" || checkFirstLetter == "e" || checkFirstLetter == "i" || checkFirstLetter == "o" || checkFirstLetter == "u") /*/ if the first letter is a vowel /*/
                        {
                            newWord = aWord.Substring(0, aWord.Length - cropLength) + "way"; /*/ convert the word by adding "way" to the end of the word discluding it's cropped section /*/

                            /*/ [TAG014] Handling Capitalized One Letter Words /*/
                            if (cropLength == aWord.Length - 1 && aWord.ToUpper() == aWord) /*/ if the word is a capital but only one letter /*/
                            {
                                if (!prevWordsAreCapital) /*/ if none of the prior words were capitals /*/
                                {
                                    if (archPrevWordsAreCapital) /*/ if the prior words were capitals according to the archive (as in they will no longer be by the next word due to a period or other cases) /*/
                                    {
                                        newWord = newWord.ToUpper(); /*/ this word is capitalized /*/
                                    }
                                    else /*/ otherwise, some more logic /*/
                                    {
                                        tempWord = EngStruct.Substring(ind + 1); /*/ a temporary word to handle the next word in line to check if that is bold /*/
                                        newInd = tempWord.IndexOf(' '); /*/ find the next letter (essentially) to see if the next letter is capital (to be sure it isn't the start of capitalized sentences /*/
                                        newInd = getIndex(tempWord, newInd); /*/ run a claculation to ensure it uses the same algorithm to find the index /*/
                                        tempWord = tempWord.Substring(0, newInd); /*/ get the next word, now that all needed info is available /*/
                                        if (tempWord.ToUpper() == tempWord) /*/ finally, if the next word is capitalized, this word should be capitalized /*/
                                        {
                                            if (!(aWord[aWord.Length - 1] == '.' || aWord[aWord.Length - 1] == '?' || aWord[aWord.Length - 1] == '!' || aWord[aWord.Length - 1] == ')' || aWord[aWord.Length - 1] == '"' || aWord[aWord.Length - 1] == '\''))
                                            { /*/ but it will only be capital if there isn't specific punctuation between them /*/
                                                newWord = newWord.ToUpper(); /*/ this word is capitalized /*/
                                            }
                                        }
                                    }
                                }
                                else /*/ if the prior words WERE CAPITALIZED, I will be capitalized to [IWAY] (and more examples) /*/
                                {
                                    newWord = newWord.ToUpper(); /*/ this word is capitalized /*/
                                }
                            }

                            /*/ [TAG015] Handling Fully Capitalized Words (Vowel First) /*/
                            else if (aWord.ToUpper() == aWord) /*/ if the english word is fully capitalized /*/
                            {
                                newWord = newWord.ToUpper(); /*/ this word is capitalized /*/
                                prevWordsAreCapital = true; /*/ state that the previous word was indeed capital /*/
                            }
                            else /*/ otherwise /*/
                            {
                                archPrevWordsAreCapital = prevWordsAreCapital; /*/ archive the current state of prevWordsAreCapital /*/
                                prevWordsAreCapital = false; /*/ state that this word was not capital /*/
                            }
                        }

                        /*/ [TAG016] When There's no Vowels /*/
                        else
                        {
                            appendage = ""; /*/ prepare the appendage /*/
                            int count = getFirstVowel(checkFirstLetter, aWord, 1);  /*/ find the first vowel /*/
                            if (!(count > aWord.Length)) /*/ if there was no vowel /*/
                            {
                                appendage = aWord.Substring(0, count - 1).ToLower(); /*/ the appendage is set to the entire word /*/
                            }
                            appendage += "ay"; /*/ add "ay" to it /*/

                            /*/ [TAG017] Check if a Word is Uppercase (No Starting Vowel) /*/
                            if (aWord.ToUpper() == aWord)
                            {
                                appendage = appendage.ToUpper();
                            }

                            /*/ [TAG018] Converting the Word (No Starting Vowel) /*/
                            if (count == aWord.Length + 1) /*/ if the count did not find a vowel /*/
                            {
                                newWord = aWord.Substring(0, aWord.Length - cropLength) + appendage.Substring(appendage.Length - 2); /*/ the new word is just the whole word with "ay" added to the end /*/
                            }
                            else /*/ otherwise /*/
                            {
                                newWord = aWord[count - 1].ToString().ToUpper(); /*/ Start the word as the first character of the second half capitalized /*/
                                newWord += aWord.Substring(count, aWord.Length - 1 - (count - 1) - cropLength); /*/ Add the rest of the second half /*/
                                newWord += appendage; /*/ add the first half plus "ay" /*/
                            }
                        }
                    }
                    newWord += endAppend; /*/ add the special characters grabbed earlier to whatever word was created /*/
                }

                /*/ [TAG019] Cleanup and Add Word to the Pig Latin Sentence /*/
                LatStruct += newWord; /*/ add the new word to the Pig Latin sentence /*/
                if (EngStruct.Trim().IndexOf(" ") != -1 && EngStruct.IndexOf('\n') != ind) /*/ if there is plausibly a next word /*/
                {
                    LatStruct += " "; /*/ add a space /*/
                }
                if (EngStruct.IndexOf('\n') == ind) /*/ if the found index used was a new line character /*/
                {
                    LatStruct += '\n'; /*/ move to the new line /*/
                }
                if (!lastInd) /*/ as long as it is not the last word /*/
                {
                    EngStruct = EngStruct.Substring(ind + 1 - foundChars); /*/ crop the English sentence to dorp the used word and index character /*/
                    while (EngStruct[0] == '\n') /*/ every new line charater after the word should be added to the Pig Latin sentence so as to not need them /*/
                    {
                        LatStruct += '\n'; /*/ add a new line character /*/
                        EngStruct = EngStruct.Substring(1); /*/ crop said new line character from the English /*/
                    }
                }
                foundChars = 0; /*/ clear any found characters /*/
                EngStruct = EngStruct.Trim(); /*/ trim the English structure (to ensure there is no space at the start /*/
                archPrevWordsAreCapital = false; /*/ turn off the archived value if applicable /*/
            }
            rtbPigLatin.Text = LatStruct; /*/ once done converting, show the structure in the Pig Latin box /*/
        }

        private void CopyEnglish(object sender, EventArgs e) /*/ Handles copying the contents of the English text box /*/
        {
            if (rtbEnglish.Text.Length > 0) /*/ As long as there is text in the English text box /*/
            {
                Clipboard.SetText(rtbEnglish.Text); /*/ Copy the text to the clipboard /*/
                MessageBox.Show("Copied English text successfully to the clipboard");
            }
        }

        private void CopyPigLatin(object sender, EventArgs e) /*/ Handles copying the contents of the Pig Latin text box /*/
        {
            if (rtbPigLatin.Text.Length > 0) /*/ As long as there is text in the Pig Latin text box /*/
            {
                Clipboard.SetText(rtbPigLatin.Text); /*/ Copy the text to the clipboard /*/
                MessageBox.Show("Copied Pig Latin text successfully to the clipboard");
            }
        }

        private void PasteEnglish(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText()) rtbEnglish.Text = Clipboard.GetText();
        }

        private void ClearBoxes(object sender, EventArgs e)
        {
            rtbEnglish.Text = "";
            rtbPigLatin.Text = "";
        }
    }
}
