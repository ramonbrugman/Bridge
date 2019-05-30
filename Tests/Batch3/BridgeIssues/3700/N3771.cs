using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures a datetime object crossing daylight saving
    /// time zone via .AddDays() retains a DST-independent value in the
    /// resulting math.
    /// </summary>
    [TestFixture(TestNameFormat = "#3771 - {0}")]
    public class Bridge3771
    {
        /// <summary>
        /// Tests by creating a date then removing 7 days, then checking
        /// whether the result is exactly 7 days before it (without hours
        /// shift due to time zone change).
        /// </summary>
        [Test]
        public static void TestDateTimeAddDaysAcrossTZ()
        {
            var time = new DateTime(2018, 11, 04, 0, 0, 0, 0, DateTimeKind.Utc);

            time = time.AddDays(-1 * 7.0);

            Assert.AreEqual("Utc", time.Kind.ToString(), "Time subject to .AddDays() is in UTC.");
            Assert.AreEqual("2018-10-28 00:00:00Z", time.ToString("u"), "Time subject to .AddDays() is '2018-10-28 00:00:00Z'.");
        }
    }
}