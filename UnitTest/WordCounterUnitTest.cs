using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class WordCounterUnitTest
    {
        [TestMethod]
        public void TestDoCountSample1Result()
        {
            var counter = new WordCounter.WordCounter();
            var rows = new string[] { "abc: def, abc and egh" };
            var words = counter.CountWords(rows);            
            Assert.AreEqual(4, words.Count);
            var sorter = new WordCounter.WordCollectionSorter();
            var lines = sorter.GetLines(words);
            Assert.AreEqual("abc 2", lines[0]);
            Assert.AreEqual("and 1", lines[1]);
            Assert.AreEqual("def 1", lines[2]);
            Assert.AreEqual("egh 1", lines[3]);
        }       

        [TestMethod]
        public void TestDoCountCaseInsensitiveResult()
        {
            var counter = new WordCounter.WordCounter();
            var rows = new string[] { "abc: def, Abc and egh" };
            var words = counter.CountWords(rows);            
            var sorter = new WordCounter.WordCollectionSorter();
            var lines = sorter.GetLines(words);
            Assert.AreEqual(4, lines.Length);
            Assert.AreEqual("abc 2", lines[0]);
            Assert.AreEqual("and 1", lines[1]);
            Assert.AreEqual("def 1", lines[2]);
            Assert.AreEqual("egh 1", lines[3]);
        }

        [TestMethod]
        public void TestDoCountManyRowsResult()
        {
            var counter = new WordCounter.WordCounter();
            var rows = new string[] { "abc: def, Abc and egh", "abc: def, Abc and egh" };
            var words = counter.CountWords(rows);
            var sorter = new WordCounter.WordCollectionSorter();
            var lines = sorter.GetLines(words);
            Assert.AreEqual(4, lines.Length);
            Assert.AreEqual("abc 4", lines[0]);
            Assert.AreEqual("and 2", lines[1]);
            Assert.AreEqual("def 2", lines[2]);
            Assert.AreEqual("egh 2", lines[3]);
        }
    }
}
