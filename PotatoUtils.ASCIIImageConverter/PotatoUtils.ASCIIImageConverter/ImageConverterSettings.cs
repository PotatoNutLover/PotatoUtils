using PotatoUtils.ASCIIImageConverter.Filters;
using System;

namespace PotatoUtils.ASCIIImageConverter
{
    public class ImageConverterSettings
    {
        public string SymbolSet { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public int CompressionLevel
        {
            get => _compressionLevel;
            set
            {
                _compressionLevel = Math.Clamp(value, 1, Int32.MaxValue);
            }
        }
        public float BrightnessLevel
        {
            get => _brightnessLevel;
            set
            {
                _brightnessLevel = Math.Clamp(value, -1.0f, 1.0f);
            }
        }
        public IFilter Filter { get; set; }

        private int _compressionLevel;
        private float _brightnessLevel;

        public ImageConverterSettings(string inputPath)
        {
            SymbolSet = " `.,-~+=0@";
            InputPath = inputPath;
            OutputPath = "output.txt";
            Filter = new SoftFilter();
            _brightnessLevel = 0f;
            _compressionLevel = 1;
        }
    }
}
