using System;
using System.Drawing;
using System.Windows.Forms;
using B_ESA_4.Common;
using System.IO;

namespace B_ESA_4.Forms
{
    public partial class frmAutor : Form
    {
        public frmAutor()
        {
            InitializeComponent();
        }

        private void frmAutor_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.GetKepplerIcon(Application.StartupPath);

            string impressum = Application.StartupPath + "\\Impressum.png";
            string slogan = Application.StartupPath + "\\SloganMitIconTransparentCCD - ohne we're.png";

            if (File.Exists(impressum))
            {
                pictureBox1.Image = Image.FromFile(impressum);
            }

            if (File.Exists(slogan))
            {
                pictureBox2.Image = Image.FromFile(slogan);
            }            
        }
    }
}
