using System.Drawing;

namespace PotatoUtils.ASCIIImageConverter
{
    public class ImageConverter
    {
        public void Convert(ImageConverterSettings settings)
        {
            ImageDecoder imageDecoder = new ImageDecoder();
            FileWriter fileWriter = new FileWriter();
            CharArrayConverter charArrayConverter = new CharArrayConverter();

            Color[,] pixelColors = imageDecoder.GetColorArray(settings.InputPath, settings.CompressionLevel);
            char[,] charArray = settings.Filter.GetSymbolsArray(pixelColors, settings);
            string outString = charArrayConverter.GetString(charArray);
            fileWriter.Write(settings.OutputPath, outString);
        }
    }
}
