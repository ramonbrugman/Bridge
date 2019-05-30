using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures a datetime object crossing daylight saving
    /// time zone (this specifically used to fail in pacific time -8h) would
    /// not result three times in 1 PM while incrementing the date.

    /// </summary>
    [TestFixture(TestNameFormat = "#3773 - {0}")]
    public class Bridge3773
    {
        /// <summary>
        /// Tests by issuing a date where daylight saving kicks in in the 
        /// affected time zone and checks whether it reaches 1PM less than
        /// two times. To some time zones (like BRT) it won't reach 1PM at all.
        /// </summary>
        [Test]
        public static void TestDateTimeAddDaysAcrossTZ()
        {
            DateTime dtloc;
            var step = new TimeSpan(0, 15, 0);
            var dateUtc = new DateTime(2018, 11, 4, 7, 45, 0, DateTimeKind.Utc);

            var oneAmCount = 0;

            for (var i = 0; i < 20; i++)
            {
                dtloc = dateUtc.ToLocalTime();

                if (dtloc.Hour == 1 && dtloc.Minute == 0)
                {
                    oneAmCount++;
                }

                dateUtc += step;
            }

            Assert.True(oneAmCount <= 2,
                "Within the increments of DateTime, 1 PM happened at most twice. In this sample, it appeared: " +
                oneAmCount + "x.");
        }
    }
}