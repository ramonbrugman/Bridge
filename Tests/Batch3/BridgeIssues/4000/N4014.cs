using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Specify Kind on DateTime
    /// </summary>
    [TestFixture(TestNameFormat = "#4014 - {0}")]
    public class Bridge4014
    {
        /// <summary>
        /// Checks whether specifying Kind on DateTime then getting Date.Kind is the same
        /// </summary>
        [Test]
        public static void TestDateTimeHasKindForDateProperty()
        {
            DateTime date1 = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc);
            DateTime date2 = date1.Date;

            Assert.AreEqual(date1.Kind, DateTimeKind.Utc, "Kind is Utc");
            Assert.AreEqual(date2.Kind, DateTimeKind.Utc, "Kind is Utc");
            Assert.AreEqual(date1.Kind, date2.Kind, "Kind are the same");
        }
    }
}