using System.Collections.Concurrent;
using System.Linq;

namespace WordCounter
{
    public class WordCollectionSorter
    {
        public string[] GetLines(ConcurrentDictionary<string, int> words)
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
