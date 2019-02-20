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
            this.label1 = new System.Windows.Forms.Label();
            this._lblIP1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._btnStartBatch1 = new System.Windows.Forms.Button();
            this._ddlTestURLBatch1 = new System.Windows.Forms.ComboBox();
            this._btnStartTestURL1 = new System.Windows.Forms.Button();
            this._txtTestURL1 = new System.Windows.Forms.TextBox();
            this._lblStatus1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._lblStarted1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._lblURL1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this._oval1 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uRLsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this._btnStartBatch2 = new System.Windows.Forms.Button();
            this._ddlTestURLBatch2 = new System.Windows.Forms.ComboBox();
            this._btnStartTestURL2 = new System.Windows.Forms.Button();
            this._txtTestURL2 = new System.Windows.Forms.TextBox();
            this._lblStatus2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._lblStarted2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._lblURL2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._lblIP2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this._oval2 = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Controls.Add(this._ddlTestURLBatch1);
            this.panel1.Controls.Add(this._btnStartTestURL1);
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
            this.panel1.Controls.Add(this.shapeContainer1);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 290);
            this.panel1.TabIndex = 5;
            // 
            // _btnStartBatch1
            // 
            this._btnStartBatch1.Location = new System.Drawing.Point(169, 200);
            this._btnStartBatch1.Name = "_btnStartBatch1";
            this._btnStartBatch1.Size = new System.Drawing.Size(57, 21);
            this._btnStartBatch1.TabIndex = 12;
            this._btnStartBatch1.Text = "Start";
            this._btnStartBatch1.UseVisualStyleBackColor = true;
            this._btnStartBatch1.Click += new System.EventHandler(this._btnStartBatch1_Click);
            // 
            // _ddlTestURLBatch1
            // 
            this._ddlTestURLBatch1.FormattingEnabled = true;
            this._ddlTestURLBatch1.Location = new System.Drawing.Point(6, 201);
            this._ddlTestURLBatch1.Name = "_ddlTestURLBatch1";
            this._ddlTestURLBatch1.Size = new System.Drawing.Size(157, 21);
            this._ddlTestURLBatch1.TabIndex = 11;
            // 
            // _btnStartTestURL1
            // 
            this._btnStartTestURL1.Location = new System.Drawing.Point(169, 160);
            this._btnStartTestURL1.Name = "_btnStartTestURL1";
            this._btnStartTestURL1.Size = new System.Drawing.Size(57, 21);
            this._btnStartTestURL1.TabIndex = 10;
            this._btnStartTestURL1.Text = "Start";
            this._btnStartTestURL1.UseVisualStyleBackColor = true;
            this._btnStartTestURL1.Click += new System.EventHandler(this._btnStartTestURL1_Click);
            // 
            // _txtTestURL1
            // 
            this._txtTestURL1.Location = new System.Drawing.Point(6, 160);
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
            this.label4.Location = new System.Drawing.Point(3, 144);
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
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this._oval1});
            this.shapeContainer1.Size = new System.Drawing.Size(281, 290);
            this.shapeContainer1.TabIndex = 13;
            this.shapeContainer1.TabStop = false;
            // 
            // _oval1
            // 
            this._oval1.Location = new System.Drawing.Point(202, 41);
            this._oval1.Name = "_oval1";
            this._oval1.Size = new System.Drawing.Size(20, 18);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.uRLsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1018, 24);
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
            // panel2
            // 
            this.panel2.Controls.Add(this._btnStartBatch2);
            this.panel2.Controls.Add(this._ddlTestURLBatch2);
            this.panel2.Controls.Add(this._btnStartTestURL2);
            this.panel2.Controls.Add(this._txtTestURL2);
            this.panel2.Controls.Add(this._lblStatus2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this._lblStarted2);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this._lblURL2);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this._lblIP2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.shapeContainer2);
            this.panel2.Location = new System.Drawing.Point(335, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 290);
            this.panel2.TabIndex = 7;
            // 
            // _btnStartBatch2
            // 
            this._btnStartBatch2.Location = new System.Drawing.Point(169, 200);
            this._btnStartBatch2.Name = "_btnStartBatch2";
            this._btnStartBatch2.Size = new System.Drawing.Size(57, 21);
            this._btnStartBatch2.TabIndex = 12;
            this._btnStartBatch2.Text = "Start";
            this._btnStartBatch2.UseVisualStyleBackColor = true;
            // 
            // _ddlTestURLBatch2
            // 
            this._ddlTestURLBatch2.FormattingEnabled = true;
            this._ddlTestURLBatch2.Location = new System.Drawing.Point(6, 201);
            this._ddlTestURLBatch2.Name = "_ddlTestURLBatch2";
            this._ddlTestURLBatch2.Size = new System.Drawing.Size(157, 21);
            this._ddlTestURLBatch2.TabIndex = 11;
            // 
            // _btnStartTestURL2
            // 
            this._btnStartTestURL2.Location = new System.Drawing.Point(169, 160);
            this._btnStartTestURL2.Name = "_btnStartTestURL2";
            this._btnStartTestURL2.Size = new System.Drawing.Size(57, 21);
            this._btnStartTestURL2.TabIndex = 10;
            this._btnStartTestURL2.Text = "Start";
            this._btnStartTestURL2.UseVisualStyleBackColor = true;
            this._btnStartTestURL2.Click += new System.EventHandler(this._btnStartTestURL2_Click);
            // 
            // _txtTestURL2
            // 
            this._txtTestURL2.Location = new System.Drawing.Point(6, 160);
            this._txtTestURL2.Name = "_txtTestURL2";
            this._txtTestURL2.Size = new System.Drawing.Size(157, 20);
            this._txtTestURL2.TabIndex = 9;
            // 
            // _lblStatus2
            // 
            this._lblStatus2.AutoSize = true;
            this._lblStatus2.Location = new System.Drawing.Point(53, 88);
            this._lblStatus2.Name = "_lblStatus2";
            this._lblStatus2.Size = new System.Drawing.Size(88, 13);
            this._lblStatus2.TabIndex = 8;
            this._lblStatus2.Text = "256.256.256.256";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Test URL:";
            // 
            // _lblStarted2
            // 
            this._lblStarted2.AutoSize = true;
            this._lblStarted2.Location = new System.Drawing.Point(53, 58);
            this._lblStarted2.Name = "_lblStarted2";
            this._lblStarted2.Size = new System.Drawing.Size(88, 13);
            this._lblStarted2.TabIndex = 5;
            this._lblStarted2.Text = "256.256.256.256";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Started:";
            // 
            // _lblURL2
            // 
            this._lblURL2.AutoSize = true;
            this._lblURL2.Location = new System.Drawing.Point(53, 27);
            this._lblURL2.Name = "_lblURL2";
            this._lblURL2.Size = new System.Drawing.Size(88, 13);
            this._lblURL2.TabIndex = 3;
            this._lblURL2.Text = "256.256.256.256";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "URL:";
            // 
            // _lblIP2
            // 
            this._lblIP2.AutoSize = true;
            this._lblIP2.Location = new System.Drawing.Point(53, 0);
            this._lblIP2.Name = "_lblIP2";
            this._lblIP2.Size = new System.Drawing.Size(88, 13);
            this._lblIP2.TabIndex = 1;
            this._lblIP2.Text = "256.256.256.256";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "IP:";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this._oval2});
            this.shapeContainer2.Size = new System.Drawing.Size(363, 290);
            this.shapeContainer2.TabIndex = 13;
            this.shapeContainer2.TabStop = false;
            // 
            // _oval2
            // 
            this._oval2.Location = new System.Drawing.Point(202, 41);
            this._oval2.Name = "_oval2";
            this._oval2.Size = new System.Drawing.Size(20, 18);
            // 
            // Reiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 369);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Reiner";
            this.Text = "Reiner";
            this.Load += new System.EventHandler(this.Reiner_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _lblIP1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnStartTestURL1;
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
        private System.Windows.Forms.ComboBox _ddlTestURLBatch1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape _oval1;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _btnStartBatch2;
        private System.Windows.Forms.ComboBox _ddlTestURLBatch2;
        private System.Windows.Forms.Button _btnStartTestURL2;
        private System.Windows.Forms.TextBox _txtTestURL2;
        private System.Windows.Forms.Label _lblStatus2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _lblStarted2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _lblURL2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label _lblIP2;
        private System.Windows.Forms.Label label14;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.OvalShape _oval2;
    }
}

