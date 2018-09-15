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
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(12, 292);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 57);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start Service";
            this._btnStart.UseVisualStyleBackColor = true;
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // _txtDomain
            // 
            this._txtDomain.Location = new System.Drawing.Point(28, 13);
            this._txtDomain.Name = "_txtDomain";
            this._txtDomain.Size = new System.Drawing.Size(184, 20);
            this._txtDomain.TabIndex = 1;
            // 
            // _btnS3Test
            // 
            this._btnS3Test.Location = new System.Drawing.Point(575, 10);
            this._btnS3Test.Name = "_btnS3Test";
            this._btnS3Test.Size = new System.Drawing.Size(88, 47);
            this._btnS3Test.TabIndex = 2;
            this._btnS3Test.Text = "Test S3 Bucket Detection";
            this._btnS3Test.UseVisualStyleBackColor = true;
            this._btnS3Test.Click += new System.EventHandler(this._btnS3Test_Click);
            // 
            // _btnSocialMediaTest
            // 
            this._btnSocialMediaTest.Location = new System.Drawing.Point(575, 63);
            this._btnSocialMediaTest.Name = "_btnSocialMediaTest";
            this._btnSocialMediaTest.Size = new System.Drawing.Size(88, 47);
            this._btnSocialMediaTest.TabIndex = 3;
            this._btnSocialMediaTest.Text = "Test Social Media";
            this._btnSocialMediaTest.UseVisualStyleBackColor = true;
            this._btnSocialMediaTest.Click += new System.EventHandler(this._btnSocialMediaTest_Click);
            // 
            // _btnSubdomainTakeoverTest
            // 
            this._btnSubdomainTakeoverTest.Location = new System.Drawing.Point(575, 116);
            this._btnSubdomainTakeoverTest.Name = "_btnSubdomainTakeoverTest";
            this._btnSubdomainTakeoverTest.Size = new System.Drawing.Size(88, 47);
            this._btnSubdomainTakeoverTest.TabIndex = 4;
            this._btnSubdomainTakeoverTest.Text = "Test SubDomain Take Over";
            this._btnSubdomainTakeoverTest.UseVisualStyleBackColor = true;
            this._btnSubdomainTakeoverTest.Click += new System.EventHandler(this._btnSubdomainTakeoverTest_Click);
            // 
            // _btnPHPInfoTest
            // 
            this._btnPHPInfoTest.Location = new System.Drawing.Point(575, 169);
            this._btnPHPInfoTest.Name = "_btnPHPInfoTest";
            this._btnPHPInfoTest.Size = new System.Drawing.Size(88, 47);
            this._btnPHPInfoTest.TabIndex = 5;
            this._btnPHPInfoTest.Text = "Test PHPInfo Disclosure";
            this._btnPHPInfoTest.UseVisualStyleBackColor = true;
            this._btnPHPInfoTest.Click += new System.EventHandler(this._btnPHPInfoTest_Click);
            // 
            // _btnDefaultTest
            // 
            this._btnDefaultTest.Location = new System.Drawing.Point(575, 222);
            this._btnDefaultTest.Name = "_btnDefaultTest";
            this._btnDefaultTest.Size = new System.Drawing.Size(88, 47);
            this._btnDefaultTest.TabIndex = 6;
            this._btnDefaultTest.Text = "Test Default Pages";
            this._btnDefaultTest.UseVisualStyleBackColor = true;
            this._btnDefaultTest.Click += new System.EventHandler(this._btnDefaultTest_Click);
            // 
            // _btnServicesTest
            // 
            this._btnServicesTest.Location = new System.Drawing.Point(575, 275);
            this._btnServicesTest.Name = "_btnServicesTest";
            this._btnServicesTest.Size = new System.Drawing.Size(88, 47);
            this._btnServicesTest.TabIndex = 7;
            this._btnServicesTest.Text = "Test Services";
            this._btnServicesTest.UseVisualStyleBackColor = true;
            this._btnServicesTest.Click += new System.EventHandler(this._btnServicesTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 361);
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
    }
}

