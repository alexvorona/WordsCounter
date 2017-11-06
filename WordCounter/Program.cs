
namespace WordCounter
{
    class Program
    {      
        static void Main(string[] args)
        {
            var counter = new WordCounter();

            var manager = new FileManager();           

            var words = counter.CountWords(manager.GetLines("data.txt"));

            var sorter = new WordCollectionSorter();            

            manager.SaveResult("results.txt", sorter.GetLines(words));            
        }
    }
}