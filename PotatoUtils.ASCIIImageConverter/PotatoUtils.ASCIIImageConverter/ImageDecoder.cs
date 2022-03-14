using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace PotatoUtils.ASCIIImageConverter
{
    internal class ImageDecoder
    {
        public Color[,] GetColorArray(string imagePath, int compressionLevel)
        {
            if (File.Exists(imagePath) == false)
                return new Color[0, 0];

            Bitmap bitmapTemp = LoadBitmap(imagePath);
            Bitmap bitmap = new Bitmap(bitmapTemp, new Size(bitmapTemp.Width / compressionLevel, bitmapTemp.Height / compressionLevel));
            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
            byte[] rgbaValues = new byte[bytes];
            Marshal.Copy(ptr, rgbaValues, 0, bytes);

            Color[,] pixelColors = new Color[bitmap.Height, bitmap.Width];
            for (int i = 0; i < rgbaValues.Length; i += 4)
            {
                Color color = Color.FromArgb(rgbaValues[i + 3], rgbaValues[i + 2], rgbaValues[i + 1], rgbaValues[i]);
                pixelColors[i / 4 / bitmap.Width, i / 4 - (bitmap.Width * (i / 4 / bitmap.Width))] = color;

            }

            return pixelColors;
        }

        private Bitmap LoadBitmap(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Bitmap bitmap;
                try
                {
                    bitmap = new Bitmap(stream);
                }
                catch
                {
                    bitmap = new Bitmap(0, 0);
                }

                return bitmap;
            }
        }
    }
}
