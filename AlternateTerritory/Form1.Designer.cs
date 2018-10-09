namespace AlternateTerritory
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
            this._btnStart = new System.Windows.Forms.Button();
            this._txtDomain = new System.Windows.Forms.TextBox();
            this._btnS3Test = new System.Windows.Forms.Button();
            this._btnSocialMediaTest = new System.Windows.Forms.Button();
            this._btnSubdomainTakeoverTest = new System.Windows.Forms.Button();
            this._btnPHPInfoTest = new System.Windows.Forms.Button();
            this._btnDefaultTest = new System.Windows.Forms.Button();
            this._btnServicesTest = new System.Windows.Forms.Button();
            this._btnWebArchiveTest = new System.Windows.Forms.Button();
            this._rtbLog = new System.Windows.Forms.RichTextBox();
            this._btnDirectoryTraversal = new System.Windows.Forms.Button();
            this._btnKnownAttackTest = new System.Windows.Forms.Button();
            this._btnFindSubomainsTest = new System.Windows.Forms.Button();
            this._btnNetcraftTest = new System.Windows.Forms.Button();
            this._btnSecTrailsTest = new System.Windows.Forms.Button();
            this._btnDatabaseConnectivityTest = new System.Windows.Forms.Button();
            this._btnTestEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(941, 386);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 57);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start Service";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _txtDomain
            // 
            this._txtDomain.Location = new System.Drawing.Point(22, 12);
            this._txtDomain.Name = "_txtDomain";
            this._txtDomain.Size = new System.Drawing.Size(184, 20);
            this._txtDomain.TabIndex = 1;
            // 
            // _btnS3Test
            // 
            this._btnS3Test.Location = new System.Drawing.Point(118, 47);
            this._btnS3Test.Name = "_btnS3Test";
            this._btnS3Test.Size = new System.Drawing.Size(88, 47);
            this._btnS3Test.TabIndex = 2;
            this._btnS3Test.Text = "Test S3 Bucket Detection";
            this._btnS3Test.UseVisualStyleBackColor = true;
            this._btnS3Test.Click += new System.EventHandler(this._btnS3Test_Click);
            // 
            // _btnSocialMediaTest
            // 
            this._btnSocialMediaTest.Location = new System.Drawing.Point(118, 100);
            this._btnSocialMediaTest.Name = "_btnSocialMediaTest";
            this._btnSocialMediaTest.Size = new System.Drawing.Size(88, 47);
            this._btnSocialMediaTest.TabIndex = 3;
            this._btnSocialMediaTest.Text = "Test Social Media";
            this._btnSocialMediaTest.UseVisualStyleBackColor = true;
            this._btnSocialMediaTest.Click += new System.EventHandler(this._btnSocialMediaTest_Click);
            // 
            // _btnSubdomainTakeoverTest
            // 
            this._btnSubdomainTakeoverTest.Location = new System.Drawing.Point(118, 153);
            this._btnSubdomainTakeoverTest.Name = "_btnSubdomainTakeoverTest";
            this._btnSubdomainTakeoverTest.Size = new System.Drawing.Size(88, 47);
            this._btnSubdomainTakeoverTest.TabIndex = 4;
            this._btnSubdomainTakeoverTest.Text = "Test SubDomain Take Over";
            this._btnSubdomainTakeoverTest.UseVisualStyleBackColor = true;
            this._btnSubdomainTakeoverTest.Click += new System.EventHandler(this._btnSubdomainTakeoverTest_Click);
            // 
            // _btnPHPInfoTest
            // 
            this._btnPHPInfoTest.Location = new System.Drawing.Point(118, 206);
            this._btnPHPInfoTest.Name = "_btnPHPInfoTest";
            this._btnPHPInfoTest.Size = new System.Drawing.Size(88, 47);
            this._btnPHPInfoTest.TabIndex = 5;
            this._btnPHPInfoTest.Text = "Test PHPInfo Disclosure";
            this._btnPHPInfoTest.UseVisualStyleBackColor = true;
            this._btnPHPInfoTest.Click += new System.EventHandler(this._btnPHPInfoTest_Click);
            // 
            // _btnDefaultTest
            // 
            this._btnDefaultTest.Location = new System.Drawing.Point(118, 259);
            this._btnDefaultTest.Name = "_btnDefaultTest";
            this._btnDefaultTest.Size = new System.Drawing.Size(88, 47);
            this._btnDefaultTest.TabIndex = 6;
            this._btnDefaultTest.Text = "Test Default Pages";
            this._btnDefaultTest.UseVisualStyleBackColor = true;
            this._btnDefaultTest.Click += new System.EventHandler(this._btnDefaultTest_Click);
            // 
            // _btnServicesTest
            // 
            this._btnServicesTest.Location = new System.Drawing.Point(24, 100);
            this._btnServicesTest.Name = "_btnServicesTest";
            this._btnServicesTest.Size = new System.Drawing.Size(88, 47);
            this._btnServicesTest.TabIndex = 7;
            this._btnServicesTest.Text = "Test Services";
            this._btnServicesTest.UseVisualStyleBackColor = true;
            this._btnServicesTest.Click += new System.EventHandler(this._btnServicesTest_Click);
            // 
            // _btnWebArchiveTest
            // 
            this._btnWebArchiveTest.Location = new System.Drawing.Point(24, 47);
            this._btnWebArchiveTest.Name = "_btnWebArchiveTest";
            this._btnWebArchiveTest.Size = new System.Drawing.Size(88, 47);
            this._btnWebArchiveTest.TabIndex = 8;
            this._btnWebArchiveTest.Text = "Test WebArchive Crawl";
            this._btnWebArchiveTest.UseVisualStyleBackColor = true;
            this._btnWebArchiveTest.Click += new System.EventHandler(this._btnWebArchiveTest_Click);
            // 
            // _rtbLog
            // 
            this._rtbLog.Location = new System.Drawing.Point(234, 12);
            this._rtbLog.Name = "_rtbLog";
            this._rtbLog.Size = new System.Drawing.Size(501, 337);
            this._rtbLog.TabIndex = 9;
            this._rtbLog.Text = "";
            // 
            // _btnDirectoryTraversal
            // 
            this._btnDirectoryTraversal.Location = new System.Drawing.Point(22, 153);
            this._btnDirectoryTraversal.Name = "_btnDirectoryTraversal";
            this._btnDirectoryTraversal.Size = new System.Drawing.Size(88, 47);
            this._btnDirectoryTraversal.TabIndex = 10;
            this._btnDirectoryTraversal.Text = "Test Directory Traversal";
            this._btnDirectoryTraversal.UseVisualStyleBackColor = true;
            this._btnDirectoryTraversal.Click += new System.EventHandler(this._btnDirectoryTraversal_Click);
            // 
            // _btnKnownAttackTest
            // 
            this._btnKnownAttackTest.Location = new System.Drawing.Point(22, 206);
            this._btnKnownAttackTest.Name = "_btnKnownAttackTest";
            this._btnKnownAttackTest.Size = new System.Drawing.Size(88, 47);
            this._btnKnownAttackTest.TabIndex = 11;
            this._btnKnownAttackTest.Text = "Test Known Attack Files";
            this._btnKnownAttackTest.UseVisualStyleBackColor = true;
            this._btnKnownAttackTest.Click += new System.EventHandler(this._btnKnownAttackTest_Click);
            // 
            // _btnFindSubomainsTest
            // 
            this._btnFindSubomainsTest.Location = new System.Drawing.Point(741, 12);
            this._btnFindSubomainsTest.Name = "_btnFindSubomainsTest";
            this._btnFindSubomainsTest.Size = new System.Drawing.Size(275, 28);
            this._btnFindSubomainsTest.TabIndex = 12;
            this._btnFindSubomainsTest.Text = "findsubdomains.com";
            this._btnFindSubomainsTest.UseVisualStyleBackColor = true;
            this._btnFindSubomainsTest.Click += new System.EventHandler(this._btnFindSubomainsTest_Click);
            // 
            // _btnNetcraftTest
            // 
            this._btnNetcraftTest.Location = new System.Drawing.Point(741, 46);
            this._btnNetcraftTest.Name = "_btnNetcraftTest";
            this._btnNetcraftTest.Size = new System.Drawing.Size(275, 28);
            this._btnNetcraftTest.TabIndex = 13;
            this._btnNetcraftTest.Text = "netcraft";
            this._btnNetcraftTest.UseVisualStyleBackColor = true;
            this._btnNetcraftTest.Click += new System.EventHandler(this._btnNetcraftTest_Click);
            // 
            // _btnSecTrailsTest
            // 
            this._btnSecTrailsTest.Location = new System.Drawing.Point(741, 80);
            this._btnSecTrailsTest.Name = "_btnSecTrailsTest";
            this._btnSecTrailsTest.Size = new System.Drawing.Size(275, 28);
            this._btnSecTrailsTest.TabIndex = 14;
            this._btnSecTrailsTest.Text = "Security Trails";
            this._btnSecTrailsTest.UseVisualStyleBackColor = true;
            this._btnSecTrailsTest.Click += new System.EventHandler(this._btnSecTrailsTest_Click);
            // 
            // _btnDatabaseConnectivityTest
            // 
            this._btnDatabaseConnectivityTest.Location = new System.Drawing.Point(12, 396);
            this._btnDatabaseConnectivityTest.Name = "_btnDatabaseConnectivityTest";
            this._btnDatabaseConnectivityTest.Size = new System.Drawing.Size(88, 47);
            this._btnDatabaseConnectivityTest.TabIndex = 15;
            this._btnDatabaseConnectivityTest.Text = "Test Database Connect";
            this._btnDatabaseConnectivityTest.UseVisualStyleBackColor = true;
            this._btnDatabaseConnectivityTest.Click += new System.EventHandler(this._btnDatabaseConnectivityTest_Click);
            // 
            // _btnTestEmail
            // 
            this._btnTestEmail.Location = new System.Drawing.Point(106, 396);
            this._btnTestEmail.Name = "_btnTestEmail";
            this._btnTestEmail.Size = new System.Drawing.Size(88, 47);
            this._btnTestEmail.TabIndex = 16;
            this._btnTestEmail.Text = "Test Email";
            this._btnTestEmail.UseVisualStyleBackColor = true;
            this._btnTestEmail.Click += new System.EventHandler(this._btnTestEmail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 455);
            this.Controls.Add(this._btnTestEmail);
            this.Controls.Add(this._btnDatabaseConnectivityTest);
            this.Controls.Add(this._btnSecTrailsTest);
            this.Controls.Add(this._btnNetcraftTest);
            this.Controls.Add(this._btnFindSubomainsTest);
            this.Controls.Add(this._btnKnownAttackTest);
            this.Controls.Add(this._btnDirectoryTraversal);
            this.Controls.Add(this._rtbLog);
            this.Controls.Add(this._btnWebArchiveTest);
            this.Controls.Add(this._btnServicesTest);
            this.Controls.Add(this._btnDefaultTest);
            this.Controls.Add(this._btnPHPInfoTest);
            this.Controls.Add(this._btnSubdomainTakeoverTest);
            this.Controls.Add(this._btnSocialMediaTest);
            this.Controls.Add(this._btnS3Test);
            this.Controls.Add(this._txtDomain);
            this.Controls.Add(this._btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.TextBox _txtDomain;
        private System.Windows.Forms.Button _btnS3Test;
        private System.Windows.Forms.Button _btnSocialMediaTest;
        private System.Windows.Forms.Button _btnSubdomainTakeoverTest;
        private System.Windows.Forms.Button _btnPHPInfoTest;
        private System.Windows.Forms.Button _btnDefaultTest;
        private System.Windows.Forms.Button _btnServicesTest;
        private System.Windows.Forms.Button _btnWebArchiveTest;
        private System.Windows.Forms.RichTextBox _rtbLog;
        private System.Windows.Forms.Button _btnDirectoryTraversal;
        private System.Windows.Forms.Button _btnKnownAttackTest;
        private System.Windows.Forms.Button _btnFindSubomainsTest;
        private System.Windows.Forms.Button _btnNetcraftTest;
        private System.Windows.Forms.Button _btnSecTrailsTest;
        private System.Windows.Forms.Button _btnDatabaseConnectivityTest;
        private System.Windows.Forms.Button _btnTestEmail;
    }
}

