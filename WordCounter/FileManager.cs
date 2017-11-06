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
        public IEnumerable<string> GetLines(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File 'data.txt' not found!");
                Task.Delay(2000).Wait();
                return new string[] { };
            }
            return File.ReadLines(filename, Encoding.Default).Where(r => !string.IsNullOrEmpty(r));
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
        }


    }
}
