namespace Socialite
{
    partial class Form1
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
            this._lstResult = new System.Windows.Forms.ListBox();
            this._txtURL = new System.Windows.Forms.TextBox();
            this._txtAddTarget = new System.Windows.Forms.TextBox();
            this._btnStart = new System.Windows.Forms.Button();
            this._bgwScanner = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this._lblCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lstTarget = new System.Windows.Forms.ListBox();
            this._btnAddTarget = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this._btnFolderSelect = new System.Windows.Forms.Button();
            this._lblDir = new System.Windows.Forms.Label();
            this._btnStartFolder = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lstResult
            // 
            this._lstResult.FormattingEnabled = true;
            this._lstResult.Location = new System.Drawing.Point(445, 65);
            this._lstResult.Name = "_lstResult";
            this._lstResult.Size = new System.Drawing.Size(760, 264);
            this._lstResult.TabIndex = 0;
            // 
            // _txtURL
            // 
            this._txtURL.Location = new System.Drawing.Point(50, 27);
            this._txtURL.Name = "_txtURL";
            this._txtURL.Size = new System.Drawing.Size(201, 20);
            this._txtURL.TabIndex = 1;
            // 
            // _txtAddTarget
            // 
            this._txtAddTarget.Location = new System.Drawing.Point(339, 251);
            this._txtAddTarget.Name = "_txtAddTarget";
            this._txtAddTarget.Size = new System.Drawing.Size(100, 20);
            this._txtAddTarget.TabIndex = 2;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(257, 24);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 3;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Count:";
            // 
            // _lblCount
            // 
            this._lblCount.AutoSize = true;
            this._lblCount.Location = new System.Drawing.Point(88, 165);
            this._lblCount.Name = "_lblCount";
            this._lblCount.Size = new System.Drawing.Size(13, 13);
            this._lblCount.TabIndex = 5;
            this._lblCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "URL:";
            // 
            // _lstTarget
            // 
            this._lstTarget.FormattingEnabled = true;
            this._lstTarget.Location = new System.Drawing.Point(339, 68);
            this._lstTarget.Name = "_lstTarget";
            this._lstTarget.Size = new System.Drawing.Size(100, 173);
            this._lstTarget.TabIndex = 7;
            // 
            // _btnAddTarget
            // 
            this._btnAddTarget.Location = new System.Drawing.Point(339, 277);
            this._btnAddTarget.Name = "_btnAddTarget";
            this._btnAddTarget.Size = new System.Drawing.Size(100, 23);
            this._btnAddTarget.TabIndex = 8;
            this._btnAddTarget.Text = "Add";
            this._btnAddTarget.UseVisualStyleBackColor = true;
            this._btnAddTarget.Click += new System.EventHandler(this._btnAddTarget_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1217, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scannerToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // scannerToolStripMenuItem
            // 
            this.scannerToolStripMenuItem.Name = "scannerToolStripMenuItem";
            this.scannerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.scannerToolStripMenuItem.Text = "Scanner";
            this.scannerToolStripMenuItem.Click += new System.EventHandler(this.scannerToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Directory:";
            // 
            // _btnFolderSelect
            // 
            this._btnFolderSelect.Location = new System.Drawing.Point(15, 95);
            this._btnFolderSelect.Name = "_btnFolderSelect";
            this._btnFolderSelect.Size = new System.Drawing.Size(75, 40);
            this._btnFolderSelect.TabIndex = 12;
            this._btnFolderSelect.Text = "Select Folder";
            this._btnFolderSelect.UseVisualStyleBackColor = true;
            this._btnFolderSelect.Click += new System.EventHandler(this._btnFolderSelect_Click);
            // 
            // _lblDir
            // 
            this._lblDir.AutoSize = true;
            this._lblDir.Location = new System.Drawing.Point(61, 79);
            this._lblDir.Name = "_lblDir";
            this._lblDir.Size = new System.Drawing.Size(76, 13);
            this._lblDir.TabIndex = 13;
            this._lblDir.Text = "None selected";
            // 
            // _btnStartFolder
            // 
            this._btnStartFolder.Location = new System.Drawing.Point(91, 95);
            this._btnStartFolder.Name = "_btnStartFolder";
            this._btnStartFolder.Size = new System.Drawing.Size(75, 40);
            this._btnStartFolder.TabIndex = 14;
            this._btnStartFolder.Text = "Start Folder";
            this._btnStartFolder.UseVisualStyleBackColor = true;
            this._btnStartFolder.Click += new System.EventHandler(this._btnStartFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 341);
            this.Controls.Add(this._btnStartFolder);
            this.Controls.Add(this._lblDir);
            this.Controls.Add(this._btnFolderSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._btnAddTarget);
            this.Controls.Add(this._lstTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this._txtAddTarget);
            this.Controls.Add(this._txtURL);
            this.Controls.Add(this._lstResult);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _lstResult;
        private System.Windows.Forms.TextBox _txtURL;
        private System.Windows.Forms.TextBox _txtAddTarget;
        private System.Windows.Forms.Button _btnStart;
        private System.ComponentModel.BackgroundWorker _bgwScanner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox _lstTarget;
        private System.Windows.Forms.Button _btnAddTarget;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scannerToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button _btnFolderSelect;
        private System.Windows.Forms.Label _lblDir;
        private System.Windows.Forms.Button _btnStartFolder;
    }
}

