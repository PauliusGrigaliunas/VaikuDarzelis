using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VaikuDarzelis;

namespace VaikuDarzelisTest
{
    [TestClass]
    public class ReadTest
    {
        [TestMethod]
        public void TestReadTransaction()
        {
            var read = new ReadFromFile(@"C:\Users\Paulius\Documents\GitHub\VaikuDarzelis\DarzelioVaikai.csv");

            Assert.ThrowsException<FormatException>(() => read.ReadTransaction(false));
        }
    }
}
