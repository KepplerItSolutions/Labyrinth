using System.Drawing;

namespace B_ESA_4.Playground
{
    public class PlaygroundVisual
    {
        private const int OFFSET_ROW = 20;
        private const int OFFSET_COLUMN = 20;
        private const int DISTANCE_BETWEEN_SIGNS = 8;
        private const int FONT_SIZE = 25;
        private readonly PlayGround _playGround;

        public PlaygroundVisual(PlayGround playGround)
        {
            _playGround = playGround;
            Size = new Size((FONT_SIZE + DISTANCE_BETWEEN_SIGNS)*_playGround.Width + 3 * OFFSET_COLUMN,
                                (FONT_SIZE + DISTANCE_BETWEEN_SIGNS)*_playGround.Height + 4 * OFFSET_ROW);
        }

        public void DrawLab(Graphics graphics)
        {
            Bitmap newGraph = new Bitmap(this.Size.Width, this.Size.Height);
            Graphics bitmapGraph = Graphics.FromImage(newGraph);
            graphics.Clear(Color.LightGray);
            Font drawFont = new Font("Arial", FONT_SIZE);

            for (int column = 0; column < _playGround.Width; column++)
            {
                for (int row = 0; row < _playGround.Height; row++)
                {
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    if (_playGround[column, row] is PlayerField)
                    {
                        brush = new SolidBrush(Color.Green);
                    }
                    bitmapGraph.DrawString(_playGround[column, row].Symbol.ToString(), 
                        drawFont, 
                        brush, 
                        new PointF(OFFSET_COLUMN + (drawFont.Size + DISTANCE_BETWEEN_SIGNS) * column,
                                    OFFSET_ROW + (drawFont.Size + DISTANCE_BETWEEN_SIGNS) * row));
                }
            }
            
            graphics.DrawImage(newGraph, new PointF(0, 0));
        }

        private void PrintEnd(Graphics internalGraphic)
        {
            internalGraphic.Clear(Color.LightGray);
            Font drawFont = new Font("Arial", FONT_SIZE);
            SolidBrush brush = new SolidBrush(Color.Black);

            internalGraphic.DrawString("Ende. Alle Items beseitigt.", drawFont, brush, new PointF(200, 200));
        }

        public Size Size { get; private set; }
    }
}