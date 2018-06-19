namespace ElDorado
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
            this._txtURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._lstFound = new System.Windows.Forms.ListBox();
            this._lstPorts = new System.Windows.Forms.ListBox();
            this._chkPortScan = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnSelectFile = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._lblFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._radFile = new System.Windows.Forms.RadioButton();
            this._radBrute = new System.Windows.Forms.RadioButton();
            this._btnStart = new System.Windows.Forms.Button();
            this._chkRescan = new System.Windows.Forms.CheckBox();
            this._chkScreenshot = new System.Windows.Forms.CheckBox();
            this._bgWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this._lblCount = new System.Windows.Forms.Label();
            this._trkBarTasks = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trkBarTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtURL
            // 
            this._txtURL.Location = new System.Drawing.Point(51, 30);
            this._txtURL.Name = "_txtURL";
            this._txtURL.Size = new System.Drawing.Size(167, 20);
            this._txtURL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // _lstFound
            // 
            this._lstFound.FormattingEnabled = true;
            this._lstFound.Location = new System.Drawing.Point(320, 30);
            this._lstFound.Name = "_lstFound";
            this._lstFound.Size = new System.Drawing.Size(153, 251);
            this._lstFound.TabIndex = 2;
            // 
            // _lstPorts
            // 
            this._lstPorts.FormattingEnabled = true;
            this._lstPorts.Location = new System.Drawing.Point(514, 30);
            this._lstPorts.Name = "_lstPorts";
            this._lstPorts.Size = new System.Drawing.Size(74, 251);
            this._lstPorts.TabIndex = 3;
            // 
            // _chkPortScan
            // 
            this._chkPortScan.AutoSize = true;
            this._chkPortScan.Location = new System.Drawing.Point(12, 207);
            this._chkPortScan.Name = "_chkPortScan";
            this._chkPortScan.Size = new System.Drawing.Size(112, 17);
            this._chkPortScan.TabIndex = 5;
            this._chkPortScan.Text = "Perform Port Scan";
            this._chkPortScan.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnSelectFile);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._lblFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._radFile);
            this.panel1.Controls.Add(this._radBrute);
            this.panel1.Location = new System.Drawing.Point(28, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 116);
            this.panel1.TabIndex = 6;
            // 
            // _btnSelectFile
            // 
            this._btnSelectFile.Location = new System.Drawing.Point(85, 65);
            this._btnSelectFile.Name = "_btnSelectFile";
            this._btnSelectFile.Size = new System.Drawing.Size(52, 23);
            this._btnSelectFile.TabIndex = 5;
            this._btnSelectFile.Text = "Select";
            this._btnSelectFile.UseVisualStyleBackColor = true;
            this._btnSelectFile.Click += new System.EventHandler(this._btnSelectFile_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Subdomain enumeration type";
            // 
            // _lblFile
            // 
            this._lblFile.AutoSize = true;
            this._lblFile.Location = new System.Drawing.Point(30, 91);
            this._lblFile.Name = "_lblFile";
            this._lblFile.Size = new System.Drawing.Size(78, 13);
            this._lblFile.TabIndex = 3;
            this._lblFile.Text = "None Selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File:";
            // 
            // _radFile
            // 
            this._radFile.AutoSize = true;
            this._radFile.Location = new System.Drawing.Point(16, 58);
            this._radFile.Name = "_radFile";
            this._radFile.Size = new System.Drawing.Size(63, 17);
            this._radFile.TabIndex = 1;
            this._radFile.TabStop = true;
            this._radFile.Text = "Use File";
            this._radFile.UseVisualStyleBackColor = true;
            // 
            // _radBrute
            // 
            this._radBrute.AutoSize = true;
            this._radBrute.Location = new System.Drawing.Point(16, 35);
            this._radBrute.Name = "_radBrute";
            this._radBrute.Size = new System.Drawing.Size(80, 17);
            this._radBrute.TabIndex = 0;
            this._radBrute.TabStop = true;
            this._radBrute.Text = "Brute Force";
            this._radBrute.UseVisualStyleBackColor = true;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(323, 286);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(85, 51);
            this._btnStart.TabIndex = 7;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _chkRescan
            // 
            this._chkRescan.AutoSize = true;
            this._chkRescan.Location = new System.Drawing.Point(11, 230);
            this._chkRescan.Name = "_chkRescan";
            this._chkRescan.Size = new System.Drawing.Size(105, 17);
            this._chkRescan.TabIndex = 8;
            this._chkRescan.Text = "Rescan Findings";
            this._chkRescan.UseVisualStyleBackColor = true;
            // 
            // _chkScreenshot
            // 
            this._chkScreenshot.AutoSize = true;
            this._chkScreenshot.Location = new System.Drawing.Point(11, 253);
            this._chkScreenshot.Name = "_chkScreenshot";
            this._chkScreenshot.Size = new System.Drawing.Size(127, 17);
            this._chkScreenshot.TabIndex = 9;
            this._chkScreenshot.Text = "Screen Shot Findings";
            this._chkScreenshot.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Requests Made:";
            // 
            // _lblCount
            // 
            this._lblCount.AutoSize = true;
            this._lblCount.Location = new System.Drawing.Point(412, 10);
            this._lblCount.Name = "_lblCount";
            this._lblCount.Size = new System.Drawing.Size(13, 13);
            this._lblCount.TabIndex = 11;
            this._lblCount.Text = "0";
            // 
            // _trkBarTasks
            // 
            this._trkBarTasks.Location = new System.Drawing.Point(85, 292);
            this._trkBarTasks.Minimum = 1;
            this._trkBarTasks.Name = "_trkBarTasks";
            this._trkBarTasks.Size = new System.Drawing.Size(184, 45);
            this._trkBarTasks.TabIndex = 12;
            this._trkBarTasks.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tasks:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 349);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._trkBarTasks);
            this.Controls.Add(this._lblCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._chkScreenshot);
            this.Controls.Add(this._chkRescan);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._chkPortScan);
            this.Controls.Add(this._lstPorts);
            this.Controls.Add(this._lstFound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtURL);
            this.Name = "Form1";
            this.Text = "ElDorado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trkBarTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox _lstFound;
        private System.Windows.Forms.ListBox _lstPorts;
        private System.Windows.Forms.CheckBox _chkPortScan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _lblFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton _radFile;
        private System.Windows.Forms.RadioButton _radBrute;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnSelectFile;
        private System.Windows.Forms.CheckBox _chkRescan;
        private System.Windows.Forms.CheckBox _chkScreenshot;
        private System.ComponentModel.BackgroundWorker _bgWorker;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _lblCount;
        private System.Windows.Forms.TrackBar _trkBarTasks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

