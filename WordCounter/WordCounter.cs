using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter
{
    public class WordCounter
    {
        private ConcurrentDictionary<string, int> words;
       
        private void DoCount(string row)
        {
            Regex regex = new Regex(@"(\w*)");            

            foreach (Match match in regex.Matches(row).Cast<Match>().Where(x => !String.IsNullOrEmpty(x.Value)))
            {
                words.AddOrUpdate(match.Value.ToLower(), 1, (k, v) => v + 1);
            }          
        }

        public void CountWords(IEnumerable<string> rows)
        {
            words = new ConcurrentDictionary<string, int>();
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
