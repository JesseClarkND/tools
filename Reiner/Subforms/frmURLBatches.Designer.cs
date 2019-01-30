namespace Reiner.Subforms
{
    partial class frmURLBatches
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
            this._txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._lstURL = new System.Windows.Forms.ListBox();
            this._txtURL = new System.Windows.Forms.TextBox();
            this._btnAdd = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this._ddlBatches = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(57, 107);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(141, 20);
            this._txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // _lstURL
            // 
            this._lstURL.FormattingEnabled = true;
            this._lstURL.Location = new System.Drawing.Point(204, 53);
            this._lstURL.Name = "_lstURL";
            this._lstURL.Size = new System.Drawing.Size(211, 264);
            this._lstURL.TabIndex = 2;
            // 
            // _txtURL
            // 
            this._txtURL.Location = new System.Drawing.Point(204, 331);
            this._txtURL.Name = "_txtURL";
            this._txtURL.Size = new System.Drawing.Size(139, 20);
            this._txtURL.TabIndex = 3;
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(349, 329);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(31, 23);
            this._btnAdd.TabIndex = 4;
            this._btnAdd.Text = "+";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
            // 
            // _btnRemove
            // 
            this._btnRemove.Location = new System.Drawing.Point(384, 329);
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(31, 23);
            this._btnRemove.TabIndex = 5;
            this._btnRemove.Text = "-";
            this._btnRemove.UseVisualStyleBackColor = true;
            this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
            // 
            // _ddlBatches
            // 
            this._ddlBatches.FormattingEnabled = true;
            this._ddlBatches.Location = new System.Drawing.Point(204, 26);
            this._ddlBatches.Name = "_ddlBatches";
            this._ddlBatches.Size = new System.Drawing.Size(176, 21);
            this._ddlBatches.TabIndex = 6;
            this._ddlBatches.SelectedIndexChanged += new System.EventHandler(this._ddlBatches_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Create New";
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(57, 133);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(31, 23);
            this._btnSave.TabIndex = 8;
            this._btnSave.Text = "+";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(384, 24);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(31, 23);
            this._btnDelete.TabIndex = 9;
            this._btnDelete.Text = "-";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this._btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "URL:";
            // 
            // frmURLBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 374);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._ddlBatches);
            this.Controls.Add(this._btnRemove);
            this.Controls.Add(this._btnAdd);
            this.Controls.Add(this._txtURL);
            this.Controls.Add(this._lstURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._txtName);
            this.Name = "frmURLBatches";
            this.Text = "URL Batches";
            this.Load += new System.EventHandler(this.frmURLBatches_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox _lstURL;
        private System.Windows.Forms.TextBox _txtURL;
        private System.Windows.Forms.Button _btnAdd;
        private System.Windows.Forms.Button _btnRemove;
        private System.Windows.Forms.ComboBox _ddlBatches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnDelete;
        private System.Windows.Forms.Label label3;
    }
}