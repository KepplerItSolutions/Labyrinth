namespace B_ESA_4.Forms
{
    partial class FrmLabyrinthGame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.labyrinthLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automatikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labyrinthLadenToolStripMenuItem,
            this.automatikToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.neuStartenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // labyrinthLadenToolStripMenuItem
            // 
            this.labyrinthLadenToolStripMenuItem.Name = "labyrinthLadenToolStripMenuItem";
            this.labyrinthLadenToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.labyrinthLadenToolStripMenuItem.Text = "Labyrinth laden";
            this.labyrinthLadenToolStripMenuItem.Click += new System.EventHandler(this.labyrinthLadenToolStripMenuItem_Click);
            // 
            // automatikToolStripMenuItem
            // 
            this.automatikToolStripMenuItem.Name = "automatikToolStripMenuItem";
            this.automatikToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.automatikToolStripMenuItem.Text = "Automatik";
            this.automatikToolStripMenuItem.Click += new System.EventHandler(this.automatikToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // autorToolStripMenuItem
            // 
            this.autorToolStripMenuItem.Name = "autorToolStripMenuItem";
            this.autorToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.autorToolStripMenuItem.Text = "Autor";
            this.autorToolStripMenuItem.Click += new System.EventHandler(this.autorToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // neuStartenToolStripMenuItem
            // 
            this.neuStartenToolStripMenuItem.Name = "neuStartenToolStripMenuItem";
            this.neuStartenToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.neuStartenToolStripMenuItem.Text = "Neu starten";
            this.neuStartenToolStripMenuItem.Click += new System.EventHandler(this.neuStartenToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FrmLabyrinthGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 474);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmLabyrinthGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Labyrinth";
            this.Load += new System.EventHandler(this.frmLabyrinthGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLabyrinthGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLabyrinthGame_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem labyrinthLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automatikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuStartenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}

