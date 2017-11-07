using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public class FileManager
    {
        private const int messageDelay = 2000;
        public IEnumerable<string> GetLines(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} not found!");
                Task.Delay(messageDelay).Wait();
                return new string[] { };
            }
            return File.ReadLines(fileName, Encoding.Default).Where(r => !string.IsNullOrEmpty(r));
        }
        public void SaveResult(string fileName, string[] lines)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            var task = Task.Factory.StartNew(() =>
            {
                File.WriteAllLines(fileName, lines);
            });
            task.Wait();
            Console.WriteLine($"File {fileName} saved successfully");
            Task.Delay(messageDelay).Wait();
        }


    }
}
