using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {      
        static void Main(string[] args)
        {
            var counter = new WordCounter();

            counter.Read("data.txt");
            
            counter.SaveResult("results.txt");           
            
        }
    }
}