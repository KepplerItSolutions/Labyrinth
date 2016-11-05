using B_ESA_4.Forms;
using B_ESA_4.Pawn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_ESA_4
{
    public partial class frmLabyrinthGame : Form
    {
        DataLoader internalData;
        PlayGround interalPlayground;
        IPawn internalPawn;
        IDataConsumer internalDataConsumer;
        string internalPathToFile;

        public frmLabyrinthGame(string pathToFile)
        {            
            internalPathToFile = pathToFile;
            InitializeComponent();
        }

        private void InteralPlayground_ResizeWindowRequest(object sender, PlayGroundEnventArgs e)
        {            
            this.Height = e.Height;
            this.Width = e.Width;                   
        }

        private void frmLabyrinthGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    internalPawn.MoveLeft();
                    break;
                case Keys.Up:
                    internalPawn.MoveUp();
                    break;
                case Keys.Right:
                    internalPawn.MoveRight();
                    break;
                case Keys.Down:
                    internalPawn.MoveDown();
                    break;
                default:
                    break;
            }
        }

        private void automatikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = ((PawnBase)internalPawn).PawnX;
            int y = ((PawnBase)internalPawn).PawnY;

            internalPawn.Dispose();

            if (automatikToolStripMenuItem.Text == "Automatik")
            {             
                internalPawn = new ComputerPlayer(interalPlayground, x, y);
                automatikToolStripMenuItem.Text = "Manuell";
            }
            else
            {
                internalPawn = new ManualMovingPawn(interalPlayground, x, y);
                automatikToolStripMenuItem.Text = "Automatik";
            }            
        }

        private void labyrinthLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                internalPathToFile = openDialog.FileName;
            }
            internalData.LoadDataFromFile(internalPathToFile);
        }

        private void frmLabyrinthGame_Shown(object sender, EventArgs e)
        {
            interalPlayground = new PlayGround(this.CreateGraphics());
            interalPlayground.ResizeWindowRequest += InteralPlayground_ResizeWindowRequest;
            internalDataConsumer = interalPlayground;
            internalData = new DataLoader(internalDataConsumer);
            internalData.LoadDataFromFile(internalPathToFile);
            internalPawn = new ManualMovingPawn(interalPlayground);
        }

        private void frmLabyrinthGame_Paint(object sender, PaintEventArgs e)
        {
            interalPlayground.DrawLab();
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAutor().Show();
        }
    }
}
