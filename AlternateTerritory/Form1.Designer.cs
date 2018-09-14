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
            this.SuspendLayout();
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(28, 326);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 23);
            this._btnStart.TabIndex = 0;
            this._btnStart.Text = "Start";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 361);
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
    }
}

