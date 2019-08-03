using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#4023 - {0}")]
    public class Bridge4023
    {
        [Test]
        public static void TestStringJoinTemplate()
        {
            var ids = new[] { "1", "2", "3" };
            Assert.AreEqual("1;2;3", string.Join(";", ids ?? new string[0]), "Null-coalescing operator works as parameter expression to string.Join().");
        }
    }
}
