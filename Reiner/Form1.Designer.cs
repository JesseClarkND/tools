namespace Reiner
{
    partial class Reiner
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
            this._btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtDomain
            // 
            this._txtDomain.Location = new System.Drawing.Point(12, 12);
            this._txtDomain.Name = "_txtDomain";
            this._txtDomain.Size = new System.Drawing.Size(184, 20);
            this._txtDomain.TabIndex = 2;
            // 
            // _btnStart
            // 
            this._btnStart.Location = new System.Drawing.Point(724, 300);
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(75, 57);
            this._btnStart.TabIndex = 3;
            this._btnStart.Text = "Start";
            this._btnStart.UseVisualStyleBackColor = true;
            // 
            // Reiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 369);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this._txtDomain);
            this.Name = "Reiner";
            this.Text = "Reiner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtDomain;
        private System.Windows.Forms.Button _btnStart;
    }
}

