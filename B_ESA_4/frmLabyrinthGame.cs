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
        const int FRAMES_PER_SECOND = 60;
        Timer renderTimer;
        DataLoader internalDataLoader;
        PlayGround interalPlayground;
        IPawn internalPawn;
        string internalPathToFile;

        public frmLabyrinthGame(string pathToFile)
        {
            internalDataLoader = new DataLoader();
            if (!String.IsNullOrWhiteSpace(pathToFile))
            {
                internalPathToFile = pathToFile;
                setLabyrinth();
            }

            renderTimer = new Timer()
            {
                Interval = 1000 / FRAMES_PER_SECOND ,
                Enabled = true                               
            };
            renderTimer.Tick += OnRenderFrame;
            InitializeComponent();
        }

        private void OnRenderFrame(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
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

            internalPawn?.Dispose();

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
            setLabyrinth();
        }
        
        private void frmLabyrinthGame_Paint(object sender, PaintEventArgs e)
        {
            interalPlayground?.DrawLab(e.Graphics);
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAutor().Show();
        }

        private void resetLabyrinthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLabyrinth();
        }

        private void setLabyrinth()
        {
            if (interalPlayground != null)
                interalPlayground.ResizeWindowRequest -= InteralPlayground_ResizeWindowRequest;

            var lab = internalDataLoader.LoadDataFromFile(internalPathToFile);
            interalPlayground = new PlayGround(lab);
            interalPlayground.ResizeWindowRequest += InteralPlayground_ResizeWindowRequest;

            internalPawn = new ManualMovingPawn(interalPlayground);
        }
    }
}
