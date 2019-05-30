using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here consists in ensuring DateTime.AddDays() results are
    /// comparable with DateTime instances.
    /// </summary>
    [TestFixture(TestNameFormat = "#3777 - {0}")]
    public class Bridge3777
    {
        /// <summary>
        /// Tests by creating two DateTime instances, one from Now and another
        /// from .AddDays(3) to that instance, then compare whether they are
        /// different.
        /// </summary>
        [Test]
        public static void TestAddDays()
        {
            DateTime d = DateTime.Now;
            DateTime d2 = d.AddDays(3);

            Assert.AreEqual(-1, DateTime.Compare(d, d2), "DateTime value is different than its .AddDays(3) result.");
        }
    }
}