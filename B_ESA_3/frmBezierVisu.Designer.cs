namespace B_ESA_3
{
    partial class frmBezierVisu
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.txtP3 = new System.Windows.Forms.TextBox();
            this.btnPaint = new System.Windows.Forms.Button();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 367);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(638, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Punkt P1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Punkt P2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Punkt P3:";
            // 
            // txtP1
            // 
            this.txtP1.Location = new System.Drawing.Point(72, 27);
            this.txtP1.Name = "txtP1";
            this.txtP1.Size = new System.Drawing.Size(100, 20);
            this.txtP1.TabIndex = 2;
            this.txtP1.Text = "10,300";
            // 
            // txtP2
            // 
            this.txtP2.Location = new System.Drawing.Point(72, 53);
            this.txtP2.Name = "txtP2";
            this.txtP2.Size = new System.Drawing.Size(100, 20);
            this.txtP2.TabIndex = 4;
            this.txtP2.Text = "180,50";
            // 
            // txtP3
            // 
            this.txtP3.Location = new System.Drawing.Point(72, 79);
            this.txtP3.Name = "txtP3";
            this.txtP3.Size = new System.Drawing.Size(100, 20);
            this.txtP3.TabIndex = 5;
            this.txtP3.Text = "320,300";
            // 
            // btnPaint
            // 
            this.btnPaint.Location = new System.Drawing.Point(529, 71);
            this.btnPaint.Name = "btnPaint";
            this.btnPaint.Size = new System.Drawing.Size(96, 23);
            this.btnPaint.TabIndex = 8;
            this.btnPaint.Text = "Bezier zeichnen";
            this.btnPaint.UseVisualStyleBackColor = true;
            this.btnPaint.Click += new System.EventHandler(this.btnPaint_Click);
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(235, 27);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 20);
            this.txtN.TabIndex = 9;
            this.txtN.Text = "6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Anzahl n:";
            // 
            // frmBezierVisu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 484);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.btnPaint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtP3);
            this.Controls.Add(this.txtP2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtP1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmBezierVisu";
            this.Text = "Bezier-Kurve";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBezierVisu_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.TextBox txtP3;
        private System.Windows.Forms.Button btnPaint;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label4;
    }
}