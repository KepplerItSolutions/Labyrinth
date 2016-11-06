using B_ESA_4.Common;
using B_ESA_4.Pawn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4
{
    public class PlayGround 
    {
        const int offsetRow = 20;
        const int offsetColumn = 20;
        const int distanceBetweenSigns = 8;
        const int fontSize = 25;
        private const string StandardFont = "Arial";
        private const string EndText = "Beendet.";

        public string[,] PlaygroundData { get; set; }

        public int Width { get { return width; } }
        int width;
        public int Height { get { return height; } }
        int height;

        public PlayGround(string[,] playgroundData)
        {
            PlaygroundData = playgroundData;
            SetSize();
        }

        public void DrawLab(Graphics internalGraphic)
        {            
            Bitmap newGraph = new Bitmap(this.Width, this.Height);            
            Graphics bitmapGraph = Graphics.FromImage(newGraph);
            internalGraphic.Clear(Color.LightGray);
            Font drawFont = new Font(StandardFont, fontSize);

            if (!StillContainsItem())
            {
                PrintEnd(internalGraphic);
            }
            else
            {
                for (int column = 0; column < PlaygroundData.GetLength(0); column++)
                {
                    for (int row = 0; row < PlaygroundData.GetLength(1); row++)
                    {
                        SolidBrush brush = new SolidBrush(Color.Blue);
                        PlaygroundData[column, row] = PlaygroundData[column, row].Replace(CommonConstants.Point, CommonConstants.ItemSign);
                        if (PlaygroundData[column, row] == CommonConstants.Wall)
                        {
                            brush = new SolidBrush(Color.Green);
                        }
                        bitmapGraph.DrawString(PlaygroundData[column, row], drawFont, brush, new PointF(offsetColumn + (drawFont.Size + distanceBetweenSigns) * column, offsetRow + (drawFont.Size + distanceBetweenSigns) * row));
                    }
                }
            }
            internalGraphic.DrawImage(newGraph, new PointF(0, 0));
        }

        private void PrintEnd(Graphics internalGraphic)
        {
            internalGraphic.Clear(Color.LightGray);
            Font drawFont = new Font(StandardFont, fontSize);
            SolidBrush brush = new SolidBrush(Color.Black);

            internalGraphic.DrawString(EndText, drawFont, brush, new PointF(50, 50));
        }

        public bool StillContainsItem()
        {
            bool result = false;
            for (int column = 0; column < PlaygroundData.GetLength(0); column++)
            {
                for (int row = 0; row < PlaygroundData.GetLength(1); row++)
                {
                    if (PlaygroundData[column, row] == CommonConstants.ItemSign || PlaygroundData[column, row] == CommonConstants.Point)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        private void SetSize()
        {
            width = (fontSize + distanceBetweenSigns) * PlaygroundData.GetLength(0) + 3 * offsetColumn;
            height = (fontSize + distanceBetweenSigns) * PlaygroundData.GetLength(1) + 4 * offsetRow;
        }
    }  
}
