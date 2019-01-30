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
            this.label1 = new System.Windows.Forms.Label();
            this._lblIP1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnStartTestURL = new System.Windows.Forms.Button();
            this._txtTestURL1 = new System.Windows.Forms.TextBox();
            this._lblStatus1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblStarted1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lblURL1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this._btnStartBatch1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _txtDomain
            // 
            this._txtDomain.Location = new System.Drawing.Point(615, 258);
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
            this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // _lblIP1
            // 
            this._lblIP1.AutoSize = true;
            this._lblIP1.Location = new System.Drawing.Point(53, 0);
            this._lblIP1.Name = "_lblIP1";
            this._lblIP1.Size = new System.Drawing.Size(88, 13);
            this._lblIP1.TabIndex = 1;
            this._lblIP1.Text = "256.256.256.256";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnStartBatch1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this._btnStartTestURL);
            this.panel1.Controls.Add(this._txtTestURL1);
            this.panel1.Controls.Add(this._lblStatus1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this._lblStarted1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._lblURL1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this._lblIP1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 290);
            this.panel1.TabIndex = 5;
            // 
            // _btnStartTestURL
            // 
            this._btnStartTestURL.Location = new System.Drawing.Point(169, 132);
            this._btnStartTestURL.Name = "_btnStartTestURL";
            this._btnStartTestURL.Size = new System.Drawing.Size(57, 21);
            this._btnStartTestURL.TabIndex = 10;
            this._btnStartTestURL.Text = "Start";
            this._btnStartTestURL.UseVisualStyleBackColor = true;
            // 
            // _txtTestURL1
            // 
            this._txtTestURL1.Location = new System.Drawing.Point(6, 132);
            this._txtTestURL1.Name = "_txtTestURL1";
            this._txtTestURL1.Size = new System.Drawing.Size(157, 20);
            this._txtTestURL1.TabIndex = 9;
            // 
            // _lblStatus1
            // 
            this._lblStatus1.AutoSize = true;
            this._lblStatus1.Location = new System.Drawing.Point(53, 88);
            this._lblStatus1.Name = "_lblStatus1";
            this._lblStatus1.Size = new System.Drawing.Size(88, 13);
            this._lblStatus1.TabIndex = 8;
            this._lblStatus1.Text = "256.256.256.256";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Test URL:";
            // 
            // _lblStarted1
            // 
            this._lblStarted1.AutoSize = true;
            this._lblStarted1.Location = new System.Drawing.Point(53, 58);
            this._lblStarted1.Name = "_lblStarted1";
            this._lblStarted1.Size = new System.Drawing.Size(88, 13);
            this._lblStarted1.TabIndex = 5;
            this._lblStarted1.Text = "256.256.256.256";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Started:";
            // 
            // _lblURL1
            // 
            this._lblURL1.AutoSize = true;
            this._lblURL1.Location = new System.Drawing.Point(53, 27);
            this._lblURL1.Name = "_lblURL1";
            this._lblURL1.Size = new System.Drawing.Size(88, 13);
            this._lblURL1.TabIndex = 3;
            this._lblURL1.Text = "256.256.256.256";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.uRLsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // uRLsToolStripMenuItem
            // 
            this.uRLsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageBatchesToolStripMenuItem});
            this.uRLsToolStripMenuItem.Name = "uRLsToolStripMenuItem";
            this.uRLsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.uRLsToolStripMenuItem.Text = "URLs";
            // 
            // manageBatchesToolStripMenuItem
            // 
            this.manageBatchesToolStripMenuItem.Name = "manageBatchesToolStripMenuItem";
            this.manageBatchesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.manageBatchesToolStripMenuItem.Text = "Manage Batches";
            this.manageBatchesToolStripMenuItem.Click += new System.EventHandler(this.manageBatchesToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 173);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(157, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // _btnStartBatch1
            // 
            this._btnStartBatch1.Location = new System.Drawing.Point(169, 172);
            this._btnStartBatch1.Name = "_btnStartBatch1";
            this._btnStartBatch1.Size = new System.Drawing.Size(57, 21);
            this._btnStartBatch1.TabIndex = 12;
            this._btnStartBatch1.Text = "Start";
            this._btnStartBatch1.UseVisualStyleBackColor = true;
            // 
            // Reiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 369);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._btnStart);
            this.Controls.Add(this._txtDomain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Reiner";
            this.Text = "Reiner";
            this.Load += new System.EventHandler(this.Reiner_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtDomain;
        private System.Windows.Forms.Button _btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblIP1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnStartTestURL;
        private System.Windows.Forms.TextBox _txtTestURL1;
        private System.Windows.Forms.Label _lblStatus1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _lblStarted1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lblURL1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uRLsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBatchesToolStripMenuItem;
        private System.Windows.Forms.Button _btnStartBatch1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

