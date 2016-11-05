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
        IDataConsumer internalDataConsumer;
        public DataLoader(IDataConsumer dataConsumer)
        {
            internalDataConsumer = dataConsumer;
        }

        public void LoadDataFromFile(string pathToFile)
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
            SetDataToPlayGround(result);            
        }

        private void SetDataToPlayGround(string[] rawData)
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
            internalDataConsumer.ResetPlayGround(playground);
        }
    }
}
