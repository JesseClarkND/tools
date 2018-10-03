namespace DbPrimer
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
            this._btnAddDomain = new System.Windows.Forms.Button();
            this._rtbLog = new System.Windows.Forms.RichTextBox();
            this._btnTestConnection = new System.Windows.Forms.Button();
            this._btnDumpDomains = new System.Windows.Forms.Button();
            this._btnInitialize = new System.Windows.Forms.Button();
            this._btnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnAddDomain
            // 
            this._btnAddDomain.Location = new System.Drawing.Point(13, 13);
            this._btnAddDomain.Name = "_btnAddDomain";
            this._btnAddDomain.Size = new System.Drawing.Size(112, 31);
            this._btnAddDomain.TabIndex = 0;
            this._btnAddDomain.Text = "Add New Domain";
            this._btnAddDomain.UseVisualStyleBackColor = true;
            this._btnAddDomain.Click += new System.EventHandler(this._btnAddDomain_Click);
            // 
            // _rtbLog
            // 
            this._rtbLog.Location = new System.Drawing.Point(193, 12);
            this._rtbLog.Name = "_rtbLog";
            this._rtbLog.Size = new System.Drawing.Size(493, 254);
            this._rtbLog.TabIndex = 1;
            this._rtbLog.Text = "";
            // 
            // _btnTestConnection
            // 
            this._btnTestConnection.Location = new System.Drawing.Point(12, 294);
            this._btnTestConnection.Name = "_btnTestConnection";
            this._btnTestConnection.Size = new System.Drawing.Size(112, 31);
            this._btnTestConnection.TabIndex = 2;
            this._btnTestConnection.Text = "Test DB Connection";
            this._btnTestConnection.UseVisualStyleBackColor = true;
            this._btnTestConnection.Click += new System.EventHandler(this._btnTestConnection_Click);
            // 
            // _btnDumpDomains
            // 
            this._btnDumpDomains.Location = new System.Drawing.Point(809, 13);
            this._btnDumpDomains.Name = "_btnDumpDomains";
            this._btnDumpDomains.Size = new System.Drawing.Size(112, 31);
            this._btnDumpDomains.TabIndex = 3;
            this._btnDumpDomains.Text = "Dump Domains";
            this._btnDumpDomains.UseVisualStyleBackColor = true;
            this._btnDumpDomains.Click += new System.EventHandler(this._btnDumpDomains_Click);
            // 
            // _btnInitialize
            // 
            this._btnInitialize.Location = new System.Drawing.Point(130, 294);
            this._btnInitialize.Name = "_btnInitialize";
            this._btnInitialize.Size = new System.Drawing.Size(112, 31);
            this._btnInitialize.TabIndex = 4;
            this._btnInitialize.Text = "Initialize Database";
            this._btnInitialize.UseVisualStyleBackColor = true;
            this._btnInitialize.Click += new System.EventHandler(this._btnInitialize_Click);
            // 
            // _btnBackup
            // 
            this._btnBackup.Location = new System.Drawing.Point(248, 294);
            this._btnBackup.Name = "_btnBackup";
            this._btnBackup.Size = new System.Drawing.Size(112, 31);
            this._btnBackup.TabIndex = 5;
            this._btnBackup.Text = "Backup Database";
            this._btnBackup.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 337);
            this.Controls.Add(this._btnBackup);
            this.Controls.Add(this._btnInitialize);
            this.Controls.Add(this._btnDumpDomains);
            this.Controls.Add(this._btnTestConnection);
            this.Controls.Add(this._rtbLog);
            this.Controls.Add(this._btnAddDomain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnAddDomain;
        private System.Windows.Forms.RichTextBox _rtbLog;
        private System.Windows.Forms.Button _btnTestConnection;
        private System.Windows.Forms.Button _btnDumpDomains;
        private System.Windows.Forms.Button _btnInitialize;
        private System.Windows.Forms.Button _btnBackup;
    }
}

