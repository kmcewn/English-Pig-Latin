namespace EngToPig
{
    partial class EngToPig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtbEnglish = new System.Windows.Forms.RichTextBox();
            this.lblEng = new System.Windows.Forms.Label();
            this.lblPigLatin = new System.Windows.Forms.Label();
            this.rtbPigLatin = new System.Windows.Forms.RichTextBox();
            this.btnEngToPig = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyIgpayAtinlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pigLatinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbEnglish
            // 
            this.rtbEnglish.Location = new System.Drawing.Point(12, 55);
            this.rtbEnglish.Name = "rtbEnglish";
            this.rtbEnglish.Size = new System.Drawing.Size(350, 186);
            this.rtbEnglish.TabIndex = 0;
            this.rtbEnglish.Text = "";
            // 
            // lblEng
            // 
            this.lblEng.AutoSize = true;
            this.lblEng.Location = new System.Drawing.Point(13, 36);
            this.lblEng.Name = "lblEng";
            this.lblEng.Size = new System.Drawing.Size(41, 13);
            this.lblEng.TabIndex = 1;
            this.lblEng.Text = "English";
            // 
            // lblPigLatin
            // 
            this.lblPigLatin.AutoSize = true;
            this.lblPigLatin.Location = new System.Drawing.Point(13, 252);
            this.lblPigLatin.Name = "lblPigLatin";
            this.lblPigLatin.Size = new System.Drawing.Size(67, 13);
            this.lblPigLatin.TabIndex = 3;
            this.lblPigLatin.Text = "Igpay Atinlay";
            // 
            // rtbPigLatin
            // 
            this.rtbPigLatin.Location = new System.Drawing.Point(12, 271);
            this.rtbPigLatin.Name = "rtbPigLatin";
            this.rtbPigLatin.ReadOnly = true;
            this.rtbPigLatin.Size = new System.Drawing.Size(350, 186);
            this.rtbPigLatin.TabIndex = 2;
            this.rtbPigLatin.Text = "";
            // 
            // btnEngToPig
            // 
            this.btnEngToPig.Location = new System.Drawing.Point(12, 474);
            this.btnEngToPig.Name = "btnEngToPig";
            this.btnEngToPig.Size = new System.Drawing.Size(175, 23);
            this.btnEngToPig.TabIndex = 4;
            this.btnEngToPig.Text = "English -> Pig Latin";
            this.btnEngToPig.UseVisualStyleBackColor = true;
            this.btnEngToPig.Click += new System.EventHandler(this.btnEngToPig_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.copyIgpayAtinlayToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearBoxes);
            // 
            // copyIgpayAtinlayToolStripMenuItem
            // 
            this.copyIgpayAtinlayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.pigLatinToolStripMenuItem});
            this.copyIgpayAtinlayToolStripMenuItem.Name = "copyIgpayAtinlayToolStripMenuItem";
            this.copyIgpayAtinlayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyIgpayAtinlayToolStripMenuItem.Text = "Copy...";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.CopyEnglish);
            // 
            // pigLatinToolStripMenuItem
            // 
            this.pigLatinToolStripMenuItem.Name = "pigLatinToolStripMenuItem";
            this.pigLatinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.pigLatinToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.pigLatinToolStripMenuItem.Text = "Pig Latin";
            this.pigLatinToolStripMenuItem.Click += new System.EventHandler(this.CopyPigLatin);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1});
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Paste...";
            // 
            // englishToolStripMenuItem1
            // 
            this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            this.englishToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.englishToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.englishToolStripMenuItem1.Text = "English";
            this.englishToolStripMenuItem1.Click += new System.EventHandler(this.PasteEnglish);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            // 
            // EngToPig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 510);
            this.Controls.Add(this.btnEngToPig);
            this.Controls.Add(this.lblPigLatin);
            this.Controls.Add(this.rtbPigLatin);
            this.Controls.Add(this.lblEng);
            this.Controls.Add(this.rtbEnglish);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EngToPig";
            this.Text = "English to Pig Latin Translator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbEnglish;
        private System.Windows.Forms.Label lblEng;
        private System.Windows.Forms.Label lblPigLatin;
        private System.Windows.Forms.RichTextBox rtbPigLatin;
        private System.Windows.Forms.Button btnEngToPig;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyIgpayAtinlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pigLatinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
    }
}

