using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The test here ensures an extern-marked indexer works when it is subject
    /// to a Bridge Template.
    /// </summary>
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
            Assert.AreEqual(5, new SomethingWithExternIndexer()[5], "Extern Indexer with template attribute works.");
        }
    }
}