
using System.IO;

namespace DesignPatterns.Adapter
{
    
    class FileWriter
    {
        private string _filePath = "log.txt";

        public void Write(string text)
        {
            File.AppendAllText(_filePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllLines(_filePath, new[] { text });
        }
    }
}