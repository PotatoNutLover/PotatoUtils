using System.Drawing;

namespace PotatoUtils.ASCIIImageConverter
{
    public interface IFilter
    {
        char[,] GetSymbolsArray(Color[,] pixelColors, ImageConverterSettings settings);
    }
}
