using B_ESA_4.Common;
using B_ESA_4.Pawn;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace B_ESA_4.Forms
{
    public partial class frmLabyrinthGame : Form
    {
        const int FRAMES_PER_SECOND = 60;
        const int WS_EX_COMPOSITE_ON = 0x02000000;
        const string AUTOMATIK = "Automatik";
        const string MANUAL = "Manuell";
        const string FILE_OPEN_FILTER = "Labyrinth File (*.dat) |*.dat";
        System.Windows.Forms.Timer renderTimer;
        DataLoader internalDataLoader;
        PlayGround interalPlayground;
        IPawn internalPawn;
        string internalPathToFile;

        public frmLabyrinthGame(string pathToFile)
        {
            InitializeComponent();
            internalDataLoader = new DataLoader();
            internalPathToFile = pathToFile;
            setLabyrinth();

            renderTimer = new Timer()
            {
                Interval = CommonConstants.ONE_SECOND / FRAMES_PER_SECOND,
                Enabled = true
            };
            renderTimer.Tick += OnRenderFrame;
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
                cp.ExStyle |= WS_EX_COMPOSITE_ON;
                return cp;
            }
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
            if (internalPawn != null)
            {
                int x = internalPawn.PawnX;
                int y = internalPawn.PawnY;

                internalPawn.Dispose();

                if (automatikToolStripMenuItem.Text == AUTOMATIK)
                {
                    internalPawn = new ComputerPlayer(interalPlayground, x, y);
                    automatikToolStripMenuItem.Text = MANUAL;
                }
                else
                {
                    internalPawn = new ManualMovingPawn(interalPlayground, x, y);
                    automatikToolStripMenuItem.Text = AUTOMATIK;
                }             
            }
        }

        private void labyrinthLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = FILE_OPEN_FILTER;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                internalPathToFile = openDialog.FileName;
            }
            setLabyrinth();
        }

        private void frmLabyrinthGame_Paint(object sender, PaintEventArgs e)
        {
            if (interalPlayground != null)
            {
                interalPlayground.DrawLab(e.Graphics);
            }            
        }

        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAutor().ShowDialog();
        }

        private void setLabyrinth()
        {
            if (!String.IsNullOrWhiteSpace(internalPathToFile))
            {
                var lab = internalDataLoader.LoadDataFromFile(internalPathToFile);
                if (lab != null)
                {
                    interalPlayground = new PlayGround(lab);
                    this.Height = interalPlayground.Height;
                    this.Width = interalPlayground.Width;
                    internalPawn = new ManualMovingPawn(interalPlayground);
                    automatikToolStripMenuItem.Text = AUTOMATIK;
                }
                else
                {
                    internalPathToFile = String.Empty;
                }
            }
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHelp().ShowDialog();
        }

        private void neuStartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLabyrinth();
        }

        private void frmLabyrinthGame_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.GetKepplerIcon(Application.StartupPath);
        }
    }
}
