using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_ESA_3
{
    public partial class frmBezierVisu : Form
    {
        public frmBezierVisu()
        {
            InitializeComponent();
        }

        private void frmBezierVisu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ZeichneBezier(int n, Point P1, Point P2, Point P3, Graphics graphicArea)
        {
            if (n == 0)
            {                
                graphicArea.DrawLine(Pens.Red, P1.xValue, P1.yValue, P2.xValue, P2.yValue);
                graphicArea.DrawLine(Pens.Red, P2.xValue, P2.yValue, P3.xValue, P3.yValue);
            }
            else
            {
                Point P12 = P1 + P2;
                P12.xValue *= 0.5f;
                P12.yValue *= 0.5f;

                Point P23 = P2 + P3;
                P23.xValue *= 0.5f;
                P23.yValue *= 0.5f;

                Point P123 = P12 + P23;
                P123.xValue *= 0.5f;
                P123.yValue *= 0.5f;

                ZeichneBezier(n - 1, P1, P12, P123, graphicArea);
                ZeichneBezier(n - 1, P123, P23, P3, graphicArea);
            }
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
            Point p1;
            Point p2;
            Point p3;
            int n;

            if (Point.TryParse(txtP1.Text, out p1) && Point.TryParse(txtP2.Text, out p2) && Point.TryParse(txtP3.Text, out p3) && int.TryParse(txtN.Text, out n))
            {
                Graphics graphicArea = pictureBox1.CreateGraphics();
                graphicArea.Clear(Color.Gray);
                graphicArea.DrawLine(Pens.Black, p1.xValue, p1.yValue, p2.xValue, p2.yValue);
                graphicArea.DrawLine(Pens.Black, p2.xValue, p2.yValue, p3.xValue, p3.yValue);
                ZeichneBezier(n, p1, p2, p3, pictureBox1.CreateGraphics());
            }
            else
            {
                MessageBox.Show("Bitte prüfen Sie Ihre Eingabe. Formatfehler?", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Die Punkte P1 - P3 sind in die neben anstehenden Textfelder einzugeben.\n"
                + "Dabei muss das Format \"x,y\" eingehalten werden. Beispiel: 10,300.\n"
                + "Alle Textfelder, auch die Anzahl n sind zu befüllen.\n"
                + "es sind nur Zahlen gültig. Buchstaben führen zu einem Fehler.", "Hilfe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
