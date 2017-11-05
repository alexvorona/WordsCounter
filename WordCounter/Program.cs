
namespace WordCounter
{
    class Program
    {      
        static void Main(string[] args)
        {
            var counter = new WordCounter();

            var manager = new FileManager();

            counter.CountWords(manager.GetLines("data.txt"));

            manager.SaveResult("results.txt", counter.GetLines());           
            
        }
    }
}