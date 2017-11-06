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
        private void DoCount(string row, ref ConcurrentDictionary<string, int> words)
        {
            Regex regex = new Regex(@"(\w*)");            

            foreach (Match match in regex.Matches(row).Cast<Match>().Where(x => !String.IsNullOrEmpty(x.Value)))
            {
                words.AddOrUpdate(match.Value.ToLower(), 1, (k, v) => v + 1);
            }          
        }

        public ConcurrentDictionary<string, int> CountWords(IEnumerable<string> rows)
        {
            ConcurrentDictionary<string, int> words = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(rows, line =>
            {
                DoCount(line, ref words);
            });
            return words;
        }       
    }   
}
