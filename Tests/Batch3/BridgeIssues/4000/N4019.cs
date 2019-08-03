using Bridge.Test.NUnit;
using System;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#4019 - {0}")]
    public class Bridge4019
    {
        [Test]
        public static void TestLinqNull()
        {
            int[] values = null;
            Assert.Throws<NullReferenceException>(() => { var arr = values.Take(2).ToArray(); }, "Linq take() throws null reference exception when used against a null array.");
        }
    }
}