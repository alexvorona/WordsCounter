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
            counter.CountWords(rows);
            var lines = counter.GetLines();
            Assert.AreEqual(4, lines.Length);
            Assert.AreEqual("abc 2", lines[0]);
            Assert.AreEqual("and 1", lines[1]);
            Assert.AreEqual("def 1", lines[2]);
            Assert.AreEqual("egh 1", lines[3]);
        }
        [TestMethod]
        public void TestDoCountSample1TwoTimesCountWords()
        {
            var counter = new WordCounter.WordCounter();
            var rows = new string[] { "abc: def, abc and egh" };
            counter.CountWords(rows);
            counter.CountWords(rows);
            var lines = counter.GetLines();           
            Assert.AreEqual("abc 2", lines[0]);           
        }

        [TestMethod]
        public void TestDoCountCaseInsensitiveResult()
        {
            var counter = new WordCounter.WordCounter();
            var rows = new string[] { "abc: def, Abc and egh" };
            counter.CountWords(rows);
            var lines = counter.GetLines();
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
            counter.CountWords(rows);
            var lines = counter.GetLines();
            Assert.AreEqual(4, lines.Length);
            Assert.AreEqual("abc 4", lines[0]);
            Assert.AreEqual("and 2", lines[1]);
            Assert.AreEqual("def 2", lines[2]);
            Assert.AreEqual("egh 2", lines[3]);
        }
    }
}
