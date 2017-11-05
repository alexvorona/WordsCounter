using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public class WordCounter
    {
        static ConcurrentDictionary<string, int> words = new ConcurrentDictionary<string, int>();
        private static char[] separators = new Char[] { ' ', '.', ',', '-', '«', '»', ':' };

        public void Read(string filename)
        {
            Parallel.ForEach(File.ReadLines(filename, Encoding.Default).Where(r => r.ToString() != string.Empty), line =>
            {
                DoCount(line);
            });         
        }
        private static void DoCount(string row)
        {         
            var res = row.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in res)
            {
                words.AddOrUpdate(word.ToLower(), 1, (k,v) => v+1);             
            }
        }
        public void SaveResult(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            var task = Task.Factory.StartNew(() =>
            {
                File.WriteAllLines(fileName,
                 GenerateValues());
            });
            task.Wait();
        }

        private string[] GenerateValues()
        {
            var AllLines = new string[words.Count];

            int i = 0;
            foreach (var item in words.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                AllLines[i]= $"{item.Key} {item.Value}";
                i++;
            }
            return AllLines;
        }
    }
}
