using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_4
{
    public class DataLoader
    {
        public DataLoader()
        {
        }

        public string[,] LoadDataFromFile(string pathToFile)
        {
            string[] result = new string[0];

            if (File.Exists(pathToFile))
            {
                StreamReader dataReader = new StreamReader(pathToFile);

                string data = dataReader.ReadToEnd();

                string[] lines = data.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                result = lines;
                dataReader.Close();
            }
            if (IsCorrectFormat(result))
            {
                return SetDataToPlayGround(result);
            }
            System.Windows.Forms.MessageBox.Show("Das Format der angegebnene Datei ist nicht korrekt");
            return null;          
        }

        private bool IsCorrectFormat(string[] dataToCheck)
        {
            bool result = true;
            int rows = 0;
            int columns = 0;

            if (dataToCheck.Length < 3)
            {
                result = false;
            }

            result = int.TryParse(dataToCheck[0], out columns) && int.TryParse(dataToCheck[1], out rows);

            if (result && !(dataToCheck.Length == rows + 2))
            {
                result = false;
            }

            for (int i = 2; i < dataToCheck.Length; i++)
            {
                if (dataToCheck[i].Length != columns)
                {
                    result = false;
                }
            }
            return result;
        }

        private string[,] SetDataToPlayGround(string[] rawData)
        {
            string[,] playground;

            int rows = int.Parse(rawData[1]);
            int columns = int.Parse(rawData[0]);

            playground = new string[columns, rows];

            for (int line = 2; line < rows + 2; line++)
            {
                for (int sign = 0; sign < columns; sign++)
                {
                    playground[sign, line - 2] = rawData[line].Substring(sign, 1);
                }
            }
            return playground;
        }
    }
}
