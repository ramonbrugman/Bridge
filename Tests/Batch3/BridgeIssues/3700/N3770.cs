using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures parsing DateTime strings in UTC results in the
    /// exact same date/time in UTC, and UTC setting is preserved.
    /// </summary>
    [TestFixture(TestNameFormat = "#3770 - {0}")]
    public class Bridge3770
    {
        /// <summary>
        /// Tests by parsing a date string, then specifying it is UTC, then
        /// checking the object time zone and value.
        /// </summary>
        [Test]
        public static void TestUtcParseLogic()
        {
            var time = DateTime.Parse("2018-11-04T00:00:00.000Z");

            time = DateTime.SpecifyKind(time, DateTimeKind.Utc);

            Assert.AreEqual("Utc", time.Kind.ToString(), "Parsed time is in UTC.");

            Assert.AreEqual("2018-11-04 00:00:00Z", time.ToString("u"), "Parsed time .ToString(\"u\") is '2018-11-04 00:00:00Z'.");
        }
    }
}