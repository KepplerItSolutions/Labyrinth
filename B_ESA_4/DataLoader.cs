using B_ESA_4.Playground;
using System;
using System.IO;
using B_ESA_4.Common;
using B_ESA_4.Playground.Fields;

namespace B_ESA_4
{
    public class DataLoader
    {
        public DataLoader()
        {
        }

        public Field[,] LoadDataFromFile(string pathToFile)
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
            throw new InvalidFormatException();
        }

        private bool IsCorrectFormat(string[] dataToCheck)
        {
            bool result = true;
            int rows = 0;
            int columns = 0;

            if (dataToCheck.Length < 3)
            {
                return false;
            }

            result = int.TryParse(dataToCheck[0], out columns) && int.TryParse(dataToCheck[1], out rows);

            if (result && dataToCheck.Length != rows + 2)
            {
                return false;
            }

            for (int i = 2; i < dataToCheck.Length; i++)
            {
                if (dataToCheck[i].Length != columns)
                {
                    return false;
                }
            }
            return result;
        }

        private Field[,] SetDataToPlayGround(string[] rawData)
        {

            int rows = int.Parse(rawData[1]);
            int columns = int.Parse(rawData[0]);

            Field[,] playground = new Field[columns, rows];

            for (int line = 2; line < rows + 2; line++)
            {
                for (int sign = 0; sign < columns; sign++)
                {
                    Field field = new EmptyField() { Location = new System.Drawing.Point(sign, line - 2) };
                    switch (rawData[line].Substring(sign, 1))
                    {
                        case CommonConstants.POINT: field = new ItemField() { Location = new System.Drawing.Point(sign, line - 2) };
                            break;
                        case CommonConstants.ITEM_SIGN:
                            field = new ItemField() { Location = new System.Drawing.Point(sign, line - 2) };
                            break;
                        case CommonConstants.PAWN:
                            field = new PlayerField() { Location = new System.Drawing.Point(sign, line - 2) };
                            break;
                        case CommonConstants.WALL:
                            field = new WallField() { Location = new System.Drawing.Point(sign, line - 2) };
                            break;
                        default:
                            field = new EmptyField() { Location = new System.Drawing.Point(sign, line - 2) };
                            break;
                    }
                    playground[sign, line - 2] = field;
                }
            }
            return playground;
        }
    }
}
