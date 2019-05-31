using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3979 - {0}")]
    public class Bridge3979
    {        
        [Test]
        public static void TestDoubleParse()
        {
            Assert.Throws<FormatException>(() => double.Parse("2+1"));
            Assert.Throws<FormatException>(() => double.Parse("2ee+1"));
            Assert.Throws<FormatException>(() => double.Parse("2e++1"));
            Assert.Throws<FormatException>(() => double.Parse("2e+-1"));
        }
    }
}
