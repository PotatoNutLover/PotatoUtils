using System;
using System.Drawing;

namespace PotatoUtils.ASCIIImageConverter.Filters
{
    public class SoftFilter : IFilter
    {
        private string _symbols = " ";
        private float _rangeOfEachSymbol = 1f;

        public char[,] GetSymbolsArray(Color[,] pixelColors, ImageConverterSettings settings)
        {
            _symbols = settings.SymbolSet;
            _rangeOfEachSymbol = 1f / settings.SymbolSet.Length;

            char[,] symbolArray = new char[pixelColors.GetLength(0), pixelColors.GetLength(1)];

            for (int i = 0; i < pixelColors.GetLength(0); i++)
                for (int j = 0; j < pixelColors.GetLength(1); j++)
                {
                    float pixelBrighness = GetPixelBrighness(pixelColors[i, j], settings.BrightnessLevel);
                    symbolArray[i, j] = GetSymbol(pixelBrighness);
                }
            return symbolArray;
        }

        private float GetPixelBrighness(Color pixelColor, float brightnessLevel) => 1.0f - pixelColor.GetBrightness() + brightnessLevel * -1;

        private char GetSymbol(float brightness)
        {
            brightness = Math.Clamp(brightness, 0, 1f);
            int symbolIndex = 0;
            for (int i = 0; i < _symbols.Length; i++)
            {
                if (brightness >= _rangeOfEachSymbol * i && brightness <= _rangeOfEachSymbol * (i + 1))
                {
                    symbolIndex = i;
                    break;
                }
            }

            return _symbols[symbolIndex];
        }
    }
}
