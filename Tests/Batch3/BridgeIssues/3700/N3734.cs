using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures DateTime value when not bound any value is its
    /// MinValue(), or 1/1/0001 12:00:00 AM.
    /// </summary>
    [TestFixture(TestNameFormat = "#3734 - {0}")]
    public class Bridge3734
    {
#pragma warning disable CS0649
        static DateTime A;  // Not initialized to MinValue
#pragma warning restore CS0649
        static DateTime B = DateTime.MinValue;

        /// <summary>
        /// Tests by checking the static DateTime instances against the value
        /// they assumed.
        /// </summary>
        [Test]
        public static void TestDateTimeInitialize()
        {
            // The format from native .NET app is '1/1/0001 12:00:00 AM'
            var initDateStr = "01/01/0001 00:00:00";
            var aDateStr = A.ToString();
            var bDateStr = B.ToString();

            Assert.AreEqual(initDateStr, aDateStr, "DateTime A (" + aDateStr + ") is '" + initDateStr + "'.");
            Assert.AreEqual(initDateStr, bDateStr, "DateTime B (" + bDateStr + ") is '" + initDateStr + "'.");
            Assert.AreEqual(0L, A.Ticks, "DateTime A has 0 ticks.");
            Assert.AreEqual(0L, B.Ticks, "DateTime B has 0 ticks.");
            Assert.True(A == DateTime.MinValue, "A is min value.");
            Assert.True(B == DateTime.MinValue, "B is min value.");
        }
    }
}