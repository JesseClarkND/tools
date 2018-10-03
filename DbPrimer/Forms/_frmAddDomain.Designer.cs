namespace DbPrimer.Forms
{
    partial class _frmAddDomain
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
            this._txtDomain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._endBountyChecks = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._txtPolicy = new System.Windows.Forms.TextBox();
            this._chkPrivate = new System.Windows.Forms.CheckBox();
            this._radHackerone = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this._radSelf = new System.Windows.Forms.RadioButton();
            this._radBugBountyJP = new System.Windows.Forms.RadioButton();
            this._radSynack = new System.Windows.Forms.RadioButton();
            this._radBugcrowd = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _txtDomain
            // 
            this._txtDomain.Location = new System.Drawing.Point(90, 16);
            this._txtDomain.Name = "_txtDomain";
            this._txtDomain.Size = new System.Drawing.Size(100, 20);
            this._txtDomain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Domain";
            // 
            // _endBountyChecks
            // 
            this._endBountyChecks.Location = new System.Drawing.Point(90, 65);
            this._endBountyChecks.Name = "_endBountyChecks";
            this._endBountyChecks.Size = new System.Drawing.Size(200, 20);
            this._endBountyChecks.TabIndex = 2;
            this._endBountyChecks.Value = new System.DateTime(2999, 12, 31, 23, 4, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bounty Policy";
            // 
            // _txtPolicy
            // 
            this._txtPolicy.Location = new System.Drawing.Point(90, 39);
            this._txtPolicy.Name = "_txtPolicy";
            this._txtPolicy.Size = new System.Drawing.Size(100, 20);
            this._txtPolicy.TabIndex = 3;
            // 
            // _chkPrivate
            // 
            this._chkPrivate.AutoSize = true;
            this._chkPrivate.Location = new System.Drawing.Point(90, 242);
            this._chkPrivate.Name = "_chkPrivate";
            this._chkPrivate.Size = new System.Drawing.Size(59, 17);
            this._chkPrivate.TabIndex = 7;
            this._chkPrivate.Text = "Private";
            this._chkPrivate.UseVisualStyleBackColor = true;
            // 
            // _radHackerone
            // 
            this._radHackerone.AutoSize = true;
            this._radHackerone.Location = new System.Drawing.Point(3, 3);
            this._radHackerone.Name = "_radHackerone";
            this._radHackerone.Size = new System.Drawing.Size(78, 17);
            this._radHackerone.TabIndex = 8;
            this._radHackerone.TabStop = true;
            this._radHackerone.Text = "Hackerone";
            this._radHackerone.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._radSelf);
            this.panel1.Controls.Add(this._radBugBountyJP);
            this.panel1.Controls.Add(this._radSynack);
            this.panel1.Controls.Add(this._radBugcrowd);
            this.panel1.Controls.Add(this._radHackerone);
            this.panel1.Location = new System.Drawing.Point(90, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 135);
            this.panel1.TabIndex = 9;
            // 
            // _radSelf
            // 
            this._radSelf.AutoSize = true;
            this._radSelf.Location = new System.Drawing.Point(4, 97);
            this._radSelf.Name = "_radSelf";
            this._radSelf.Size = new System.Drawing.Size(43, 17);
            this._radSelf.TabIndex = 12;
            this._radSelf.TabStop = true;
            this._radSelf.Text = "Self";
            this._radSelf.UseVisualStyleBackColor = true;
            // 
            // _radBugBountyJP
            // 
            this._radBugBountyJP.AutoSize = true;
            this._radBugBountyJP.Location = new System.Drawing.Point(4, 73);
            this._radBugBountyJP.Name = "_radBugBountyJP";
            this._radBugBountyJP.Size = new System.Drawing.Size(108, 17);
            this._radBugBountyJP.TabIndex = 11;
            this._radBugBountyJP.TabStop = true;
            this._radBugBountyJP.Text = "Bugbounty Japan";
            this._radBugBountyJP.UseVisualStyleBackColor = true;
            // 
            // _radSynack
            // 
            this._radSynack.AutoSize = true;
            this._radSynack.Location = new System.Drawing.Point(4, 50);
            this._radSynack.Name = "_radSynack";
            this._radSynack.Size = new System.Drawing.Size(61, 17);
            this._radSynack.TabIndex = 10;
            this._radSynack.TabStop = true;
            this._radSynack.Text = "Synack";
            this._radSynack.UseVisualStyleBackColor = true;
            // 
            // _radBugcrowd
            // 
            this._radBugcrowd.AutoSize = true;
            this._radBugcrowd.Location = new System.Drawing.Point(3, 27);
            this._radBugcrowd.Name = "_radBugcrowd";
            this._radBugcrowd.Size = new System.Drawing.Size(73, 17);
            this._radBugcrowd.TabIndex = 9;
            this._radBugcrowd.TabStop = true;
            this._radBugcrowd.Text = "Bugcrowd";
            this._radBugcrowd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "ex yahoo.com, google.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Date";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(188, 324);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 12;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(269, 324);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _frmAddDomain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 359);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._chkPrivate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._txtPolicy);
            this.Controls.Add(this._endBountyChecks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtDomain);
            this.Name = "_frmAddDomain";
            this.Text = "_frmAddDomain";
            this.Load += new System.EventHandler(this._frmAddDomain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _endBountyChecks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtPolicy;
        private System.Windows.Forms.CheckBox _chkPrivate;
        private System.Windows.Forms.RadioButton _radHackerone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton _radSelf;
        private System.Windows.Forms.RadioButton _radBugBountyJP;
        private System.Windows.Forms.RadioButton _radSynack;
        private System.Windows.Forms.RadioButton _radBugcrowd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
    }
}