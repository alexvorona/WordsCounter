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
