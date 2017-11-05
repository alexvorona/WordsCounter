using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordCounter
{
    public class WordCounter
    {
        static ConcurrentDictionary<string, int> words = new ConcurrentDictionary<string, int>();
        private static char[] separators = new Char[] { ' ', '.', ',', '-', '«', '»', ':' };
        private static void DoCount(string row)
        {
            var res = row.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in res)
            {
                words.AddOrUpdate(word.ToLower(), 1, (k, v) => v + 1);
            }
        }

        public void CountWords(IEnumerable<string> rows)
        {
            Parallel.ForEach(rows, line =>
            {
                DoCount(line);
            });
        }

        public string[] GetLines()
        {
            var AllLines = new string[words.Count];

            int i = 0;
            foreach (var item in words.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                AllLines[i] = $"{item.Key} {item.Value}";
                i++;
            }
            return AllLines;
        }
    }   
}
