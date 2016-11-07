using System;
using System.Drawing;
using System.Windows.Forms;
using B_ESA_4.Common;
using System.IO;

namespace B_ESA_4.Forms
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            string help = Application.StartupPath + @"\Help.rtf";

            if (File.Exists(help))
            {
                richTextBox1.LoadFile(help);
            }
            else
            {
                richTextBox1.Text = "Hilfedatei nicht gefunden.\nPfad: " + help;
            }
            this.Icon = Icon.GetKepplerIcon(Application.StartupPath);
        }
    }
}
