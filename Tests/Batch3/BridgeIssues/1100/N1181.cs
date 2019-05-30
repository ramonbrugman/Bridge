using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1181 - {0}")]
    public class Bridge1181
    {
        [Test]
        public static void TestMinDateTimeUtcConvert()
        {
            var start = DateTime.MinValue;
            var end = start.AddHours(8);
            var difference = (end - start).TotalMinutes;

            Assert.AreEqual(480, difference, "Minutes difference between DateTime.MinValue and itself.AddHours(8) in minutes is 480.");
        }
    }
}