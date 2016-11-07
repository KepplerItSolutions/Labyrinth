using B_ESA_4.Common;
using B_ESA_4.Pawn;
using System;
using System.Drawing;
using System.Windows.Forms;
using B_ESA_4.Playground;
using System.Collections.Generic;
using System.Linq;

namespace B_ESA_4.Forms
{
    public partial class frmLabyrinthGame : Form
    {
        const int FONT_SIZE = 25;
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
        private PlaygroundRenderer _playgroundRenderer;

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
                internalPawn.Dispose();

                if (automatikToolStripMenuItem.Text == AUTOMATIK)
                {
                    internalPawn = new ComputerPlayer(interalPlayground);
                    automatikToolStripMenuItem.Text = MANUAL;
                }
                else
                {
                    internalPawn = new ManualMovingPawn(interalPlayground);
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
            if (interalPlayground == null)
                PrintString(e.Graphics, "Kein Labyrinth ausgewählt.");
            else if(interalPlayground.StillContainsItem())
                _playgroundRenderer?.DrawLab(e.Graphics);
            else
                PrintString(e.Graphics, "Ende. Alle Items beseitigt.");

        }
        private void PrintString(Graphics internalGraphic, string message)
        {
            internalGraphic.Clear(Color.LightGray);
            Font drawFont = new Font("Arial", FONT_SIZE);
            SolidBrush brush = new SolidBrush(Color.Black);
            var size = internalGraphic.MeasureString(message, drawFont);
            internalGraphic.DrawString(message, drawFont, brush, new PointF((this.Width - size.Width) / 2,(this.Height - size.Height) / 2));
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHelp().ShowDialog();
        }

        private void neuStartenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setLabyrinth();
        }
        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAutor().Show();
        }

        private void frmLabyrinthGame_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.GetKepplerIcon(Application.StartupPath);
        }

        private void setLabyrinth()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(internalPathToFile))
                    return;
                var lab = internalDataLoader.LoadDataFromFile(internalPathToFile);
                interalPlayground = new PlayGround(lab);
                _playgroundRenderer = new PlaygroundRenderer(interalPlayground);
                internalPawn = new ManualMovingPawn(interalPlayground);
                this.Height = _playgroundRenderer?.Size.Height ?? this.Height;
                this.Width = _playgroundRenderer?.Size.Width ?? this.Width;
            }catch(PawnMissingException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
