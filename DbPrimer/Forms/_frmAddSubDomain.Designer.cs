namespace DbPrimer.Forms
{
    partial class _frmAddSubDomain
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
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._txtSubName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._txtFoundType = new System.Windows.Forms.TextBox();
            this._dateFound = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this._cmbDomain = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(249, 279);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(168, 279);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _txtSubName
            // 
            this._txtSubName.Location = new System.Drawing.Point(92, 12);
            this._txtSubName.Name = "_txtSubName";
            this._txtSubName.Size = new System.Drawing.Size(100, 20);
            this._txtSubName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Subdomain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ex: test, s.test.sub";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Found Type:";
            // 
            // _txtFoundType
            // 
            this._txtFoundType.Location = new System.Drawing.Point(92, 134);
            this._txtFoundType.Name = "_txtFoundType";
            this._txtFoundType.Size = new System.Drawing.Size(100, 20);
            this._txtFoundType.TabIndex = 5;
            // 
            // _dateFound
            // 
            this._dateFound.Location = new System.Drawing.Point(92, 39);
            this._dateFound.Name = "_dateFound";
            this._dateFound.Size = new System.Drawing.Size(200, 20);
            this._dateFound.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Found:";
            // 
            // _cmbDomain
            // 
            this._cmbDomain.FormattingEnabled = true;
            this._cmbDomain.Location = new System.Drawing.Point(92, 78);
            this._cmbDomain.Name = "_cmbDomain";
            this._cmbDomain.Size = new System.Drawing.Size(121, 21);
            this._cmbDomain.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Parent:";
            // 
            // _frmAddSubDomain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 314);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._cmbDomain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._dateFound);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtFoundType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtSubName);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnCancel);
            this.Name = "_frmAddSubDomain";
            this.Text = "_frmAddSubDomain";
            this.Load += new System.EventHandler(this._frmAddSubDomain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.TextBox _txtSubName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtFoundType;
        private System.Windows.Forms.DateTimePicker _dateFound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cmbDomain;
        private System.Windows.Forms.Label label5;
    }
}