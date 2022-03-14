namespace PotatoUtils.ASCIIImageConverter
{
    internal class CharArrayConverter
    {
        public string GetString(char[,] charArray)
        {
            string convertedString = "";

            for (int i = 0; i < charArray.GetLength(0); i++)
            {
                for (int j = 0; j < charArray.GetLength(1); j++)
                {
                    convertedString += charArray[i, j];
                }
                convertedString += '\n';
            }

            return convertedString;
        }

    }
}
