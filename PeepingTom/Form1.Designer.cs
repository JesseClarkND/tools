namespace PeepingTom
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
            this._btnStart = new System.Windows.Forms.Button();
            this._btnImport = new System.Windows.Forms.Button();
            this._lstImport = new System.Windows.Forms.ListBox();
            this._dataGrid = new System.Windows.Forms.DataGridView();
            this._colURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colResponseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this._colImageMD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._btnStartList = new System.Windows.Forms.Button();
            this._fileDialog = new System.Windows.Forms.OpenFileDialog();
            this._folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this._lblDir = new System.Windows.Forms.Label();
            this._btnImageScan = new System.Windows.Forms.Button();
            this._btnFolderSelect = new System.Windows.Forms.Button();
            this._btnClear = new System.Windows.Forms.Button();
            this._bgwScanner = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblSubStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lstSubMessage = new System.Windows.Forms.ListBox();
            this._lstBatch = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtURL
            // 
            this._txtURL.Location = new System.Drawing.Point(24, 13);
            this._txtURL.Name = "_txtURL";
            this._txtURL.Size = new System.Drawing.Size(156, 20);
            this._txtURL.TabIndex = 0;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(61, 39);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(119, 23);
            this._btnStart.TabIndex = 1;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _btnImport
            // 
            this._btnImport.Location = new System.Drawing.Point(61, 255);
            this._btnImport.Name = "_btnImport";
            this._btnImport.Size = new System.Drawing.Size(119, 23);
            this._btnImport.TabIndex = 2;
            this._btnImport.Text = "Import";
            this._btnImport.UseVisualStyleBackColor = true;
            this._btnImport.Click += new System.EventHandler(this._btnImport_Click);
            // 
            // _lstImport
            // 
            this._lstImport.FormattingEnabled = true;
            this._lstImport.Location = new System.Drawing.Point(24, 102);
            this._lstImport.Name = "_lstImport";
            this._lstImport.Size = new System.Drawing.Size(156, 147);
            this._lstImport.TabIndex = 3;
            // 
            // _dataGrid
            // 
            this._dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._colURL,
            this._colResponseCode,
            this._colImage,
            this._colImageMD5});
            this._dataGrid.Location = new System.Drawing.Point(303, 13);
            this._dataGrid.Name = "_dataGrid";
            this._dataGrid.Size = new System.Drawing.Size(793, 329);
            this._dataGrid.TabIndex = 4;
            // 
            // _colURL
            // 
            this._colURL.HeaderText = "URL";
            this._colURL.Name = "_colURL";
            this._colURL.ReadOnly = true;
            this._colURL.Width = 200;
            // 
            // _colResponseCode
            // 
            this._colResponseCode.HeaderText = "Code";
            this._colResponseCode.Name = "_colResponseCode";
            this._colResponseCode.ReadOnly = true;
            // 
            // _colImage
            // 
            this._colImage.HeaderText = "Image";
            this._colImage.Name = "_colImage";
            this._colImage.ReadOnly = true;
            this._colImage.Width = 250;
            // 
            // _colImageMD5
            // 
            this._colImageMD5.HeaderText = "Image MD5";
            this._colImageMD5.Name = "_colImageMD5";
            this._colImageMD5.ReadOnly = true;
            this._colImageMD5.Width = 200;
            // 
            // _btnStartList
            // 
            this._btnStartList.Location = new System.Drawing.Point(61, 284);
            this._btnStartList.Name = "_btnStartList";
            this._btnStartList.Size = new System.Drawing.Size(119, 23);
            this._btnStartList.TabIndex = 5;
            this._btnStartList.Text = "Start";
            this._btnStartList.UseVisualStyleBackColor = true;
            this._btnStartList.Click += new System.EventHandler(this._btnStartList_Click);
            // 
            // _fileDialog
            // 
            this._fileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Directory:";
            // 
            // _lblDir
            // 
            this._lblDir.AutoSize = true;
            this._lblDir.Location = new System.Drawing.Point(83, 436);
            this._lblDir.Name = "_lblDir";
            this._lblDir.Size = new System.Drawing.Size(10, 13);
            this._lblDir.TabIndex = 7;
            this._lblDir.Text = "-";
            // 
            // _btnImageScan
            // 
            this._btnImageScan.Location = new System.Drawing.Point(61, 488);
            this._btnImageScan.Name = "_btnImageScan";
            this._btnImageScan.Size = new System.Drawing.Size(119, 23);
            this._btnImageScan.TabIndex = 8;
            this._btnImageScan.Text = "Start";
            this._btnImageScan.UseVisualStyleBackColor = true;
            this._btnImageScan.Click += new System.EventHandler(this._btnImageScan_Click);
            // 
            // _btnFolderSelect
            // 
            this._btnFolderSelect.Location = new System.Drawing.Point(61, 459);
            this._btnFolderSelect.Name = "_btnFolderSelect";
            this._btnFolderSelect.Size = new System.Drawing.Size(119, 23);
            this._btnFolderSelect.TabIndex = 9;
            this._btnFolderSelect.Text = "Pick Folder";
            this._btnFolderSelect.UseVisualStyleBackColor = true;
            this._btnFolderSelect.Click += new System.EventHandler(this._btnFolderSelect_Click);
            // 
            // _btnClear
            // 
            this._btnClear.Location = new System.Drawing.Point(977, 348);
            this._btnClear.Name = "_btnClear";
            this._btnClear.Size = new System.Drawing.Size(119, 23);
            this._btnClear.TabIndex = 10;
            this._btnClear.Text = "Clear";
            this._btnClear.UseVisualStyleBackColor = true;
            this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Status:";
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Location = new System.Drawing.Point(346, 348);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(10, 13);
            this._lblStatus.TabIndex = 12;
            this._lblStatus.Text = "-";
            // 
            // _lblSubStatus
            // 
            this._lblSubStatus.AutoSize = true;
            this._lblSubStatus.Location = new System.Drawing.Point(659, 370);
            this._lblSubStatus.Name = "_lblSubStatus";
            this._lblSubStatus.Size = new System.Drawing.Size(10, 13);
            this._lblSubStatus.TabIndex = 14;
            this._lblSubStatus.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Status:";
            // 
            // _lstSubMessage
            // 
            this._lstSubMessage.FormattingEnabled = true;
            this._lstSubMessage.Location = new System.Drawing.Point(616, 386);
            this._lstSubMessage.Name = "_lstSubMessage";
            this._lstSubMessage.Size = new System.Drawing.Size(469, 238);
            this._lstSubMessage.TabIndex = 15;
            // 
            // _lstBatch
            // 
            this._lstBatch.FormattingEnabled = true;
            this._lstBatch.Location = new System.Drawing.Point(329, 386);
            this._lstBatch.Name = "_lstBatch";
            this._lstBatch.Size = new System.Drawing.Size(245, 238);
            this._lstBatch.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 637);
            this.Controls.Add(this._lstBatch);
            this.Controls.Add(this._lstSubMessage);
            this.Controls.Add(this._lblSubStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnClear);
            this.Controls.Add(this._btnFolderSelect);
            this.Controls.Add(this._btnImageScan);
            this.Controls.Add(this._lblDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._btnStartList);
            this.Controls.Add(this._dataGrid);
            this.Controls.Add(this._lstImport);
            this.Controls.Add(this._btnImport);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this._txtURL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtURL;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Button _btnImport;
        private System.Windows.Forms.ListBox _lstImport;
        private System.Windows.Forms.DataGridView _dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colResponseCode;
        private System.Windows.Forms.DataGridViewImageColumn _colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _colImageMD5;
        private System.Windows.Forms.Button _btnStartList;
        private System.Windows.Forms.OpenFileDialog _fileDialog;
        private System.Windows.Forms.FolderBrowserDialog _folderDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblDir;
        private System.Windows.Forms.Button _btnImageScan;
        private System.Windows.Forms.Button _btnFolderSelect;
        private System.Windows.Forms.Button _btnClear;
        private System.ComponentModel.BackgroundWorker _bgwScanner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Label _lblSubStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox _lstSubMessage;
        private System.Windows.Forms.ListBox _lstBatch;
    }
}

