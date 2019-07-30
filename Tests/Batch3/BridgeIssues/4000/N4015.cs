using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#4015 - {0}")]
    public class Bridge4015
    {
        public class SomethingWithExternIndexer
        {
            public extern int this[int index]
            {
                [Template("{this}.Get({index})")]
                get;
            }

            public int Get(int i)
            {
                return i;
            }
        }

        [Test]
        public static void TestExternalIndexer()
        {
            Assert.AreEqual(5, new SomethingWithExternIndexer()[5]);
        }
    }
}