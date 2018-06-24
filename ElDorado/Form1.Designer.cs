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
            this.label8 = new System.Windows.Forms.Label();
            this._pnlPortsSelect = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this._radCommonPorts = new System.Windows.Forms.RadioButton();
            this._radAllPorts = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this._lblPortCount = new System.Windows.Forms.Label();
            this._btnStartPort = new System.Windows.Forms.Button();
            this._chkSave = new System.Windows.Forms.CheckBox();
            this._radPopularPorts = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._trkBarTasks)).BeginInit();
            this._pnlPortsSelect.SuspendLayout();
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
            this._lstFound.Location = new System.Drawing.Point(458, 33);
            this._lstFound.Name = "_lstFound";
            this._lstFound.Size = new System.Drawing.Size(237, 251);
            this._lstFound.TabIndex = 2;
            this._lstFound.SelectedIndexChanged += new System.EventHandler(this._lstFound_SelectedIndexChanged);
            // 
            // _lstPorts
            // 
            this._lstPorts.FormattingEnabled = true;
            this._lstPorts.Location = new System.Drawing.Point(744, 33);
            this._lstPorts.Name = "_lstPorts";
            this._lstPorts.Size = new System.Drawing.Size(85, 251);
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
            this._chkPortScan.CheckedChanged += new System.EventHandler(this._chkPortScan_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this._btnSelectFile);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._lblFile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._radFile);
            this.panel1.Controls.Add(this._radBrute);
            this.panel1.Location = new System.Drawing.Point(28, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 116);
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
            this._btnStart.Location = new System.Drawing.Point(458, 290);
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
            this._chkRescan.Location = new System.Drawing.Point(12, 230);
            this._chkRescan.Name = "_chkRescan";
            this._chkRescan.Size = new System.Drawing.Size(105, 17);
            this._chkRescan.TabIndex = 8;
            this._chkRescan.Text = "Rescan Findings";
            this._chkRescan.UseVisualStyleBackColor = true;
            // 
            // _chkScreenshot
            // 
            this._chkScreenshot.AutoSize = true;
            this._chkScreenshot.Location = new System.Drawing.Point(12, 253);
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
            this.label5.Location = new System.Drawing.Point(458, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Requests Made:";
            // 
            // _lblCount
            // 
            this._lblCount.AutoSize = true;
            this._lblCount.Location = new System.Drawing.Point(550, 13);
            this._lblCount.Name = "_lblCount";
            this._lblCount.Size = new System.Drawing.Size(13, 13);
            this._lblCount.TabIndex = 11;
            this._lblCount.Text = "0";
            // 
            // _trkBarTasks
            // 
            this._trkBarTasks.Location = new System.Drawing.Point(85, 323);
            this._trkBarTasks.Minimum = 1;
            this._trkBarTasks.Name = "_trkBarTasks";
            this._trkBarTasks.Size = new System.Drawing.Size(184, 45);
            this._trkBarTasks.TabIndex = 12;
            this._trkBarTasks.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tasks:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Max Length: 3 char";
            // 
            // _pnlPortsSelect
            // 
            this._pnlPortsSelect.Controls.Add(this._radPopularPorts);
            this._pnlPortsSelect.Controls.Add(this._radAllPorts);
            this._pnlPortsSelect.Controls.Add(this._radCommonPorts);
            this._pnlPortsSelect.Controls.Add(this.label9);
            this._pnlPortsSelect.Location = new System.Drawing.Point(154, 194);
            this._pnlPortsSelect.Name = "_pnlPortsSelect";
            this._pnlPortsSelect.Size = new System.Drawing.Size(200, 123);
            this._pnlPortsSelect.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Which ports shall be scanned:";
            // 
            // _radCommonPorts
            // 
            this._radCommonPorts.AutoSize = true;
            this._radCommonPorts.Location = new System.Drawing.Point(15, 58);
            this._radCommonPorts.Name = "_radCommonPorts";
            this._radCommonPorts.Size = new System.Drawing.Size(120, 17);
            this._radCommonPorts.TabIndex = 8;
            this._radCommonPorts.TabStop = true;
            this._radCommonPorts.Text = "0 to 1023 (Common)";
            this._radCommonPorts.UseVisualStyleBackColor = true;
            // 
            // _radAllPorts
            // 
            this._radAllPorts.AutoSize = true;
            this._radAllPorts.Location = new System.Drawing.Point(15, 82);
            this._radAllPorts.Name = "_radAllPorts";
            this._radAllPorts.Size = new System.Drawing.Size(96, 17);
            this._radAllPorts.TabIndex = 9;
            this._radAllPorts.TabStop = true;
            this._radAllPorts.Text = "0 to 65535 (All)";
            this._radAllPorts.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(697, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Requests Made:";
            // 
            // _lblPortCount
            // 
            this._lblPortCount.AutoSize = true;
            this._lblPortCount.Location = new System.Drawing.Point(788, 9);
            this._lblPortCount.Name = "_lblPortCount";
            this._lblPortCount.Size = new System.Drawing.Size(13, 13);
            this._lblPortCount.TabIndex = 18;
            this._lblPortCount.Text = "0";
            // 
            // _btnStartPort
            // 
            this._btnStartPort.Location = new System.Drawing.Point(744, 290);
            this._btnStartPort.Name = "_btnStartPort";
            this._btnStartPort.Size = new System.Drawing.Size(85, 51);
            this._btnStartPort.TabIndex = 19;
            this._btnStartPort.Text = "Start";
            this._btnStartPort.UseVisualStyleBackColor = true;
            this._btnStartPort.Click += new System.EventHandler(this._btnStartPort_Click);
            // 
            // _chkSave
            // 
            this._chkSave.AutoSize = true;
            this._chkSave.Location = new System.Drawing.Point(12, 276);
            this._chkSave.Name = "_chkSave";
            this._chkSave.Size = new System.Drawing.Size(89, 17);
            this._chkSave.TabIndex = 20;
            this._chkSave.Text = "Save Results";
            this._chkSave.UseVisualStyleBackColor = true;
            // 
            // _radPopularPorts
            // 
            this._radPopularPorts.AutoSize = true;
            this._radPopularPorts.Location = new System.Drawing.Point(15, 36);
            this._radPopularPorts.Name = "_radPopularPorts";
            this._radPopularPorts.Size = new System.Drawing.Size(114, 17);
            this._radPopularPorts.TabIndex = 10;
            this._radPopularPorts.TabStop = true;
            this._radPopularPorts.Text = "Most Popular Ports";
            this._radPopularPorts.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 380);
            this.Controls.Add(this._chkSave);
            this.Controls.Add(this._btnStartPort);
            this.Controls.Add(this._lblPortCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._pnlPortsSelect);
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
            this._pnlPortsSelect.ResumeLayout(false);
            this._pnlPortsSelect.PerformLayout();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel _pnlPortsSelect;
        private System.Windows.Forms.RadioButton _radAllPorts;
        private System.Windows.Forms.RadioButton _radCommonPorts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _lblPortCount;
        private System.Windows.Forms.Button _btnStartPort;
        private System.Windows.Forms.CheckBox _chkSave;
        private System.Windows.Forms.RadioButton _radPopularPorts;
    }
}

