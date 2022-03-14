using System.IO;

namespace PotatoUtils.ASCIIImageConverter
{
    internal class FileWriter
    {
        public void Write(string path, string outputString)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(outputString);
            }
        }
    }
}
