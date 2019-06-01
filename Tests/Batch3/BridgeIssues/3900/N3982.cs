using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures TryParse/Parse behaves correctly in some
    /// situations with Decimals.
    /// </summary>
    [TestFixture(TestNameFormat = "#3982 - {0}")]
    public class Bridge3982
    {
        /// <summary>
        /// Tests some combinations for decimal.
        /// </summary>
        [Test]
        public static void TestFloatingPointParse()
        {
            decimal tmpm;

            var invalid_samples = new string[]
            {
                "2ee+1",
                "2+e+1",
                "-2+",
                "+2-"
            };

            var valid_samples = new Tuple<decimal, string>[]
            {
                new Tuple<decimal, string>(0.2m, ".2+"),
                new Tuple<decimal, string>(-0.2m, ".2-"),
                new Tuple<decimal, string>(-1.2m, "1.2-"),
                new Tuple<decimal, string>(0.2m, "+.2"),
                new Tuple<decimal, string>(1.2m, "+1.2")
            };

            foreach (var sample in invalid_samples)
            {
                Assert.Throws<FormatException>(() => decimal.Parse(sample), "decimal.Parse(\"" + sample + "\") throws FormatException");
            }

            foreach (var st in valid_samples)
            {
                var sample = st.Item2;
                var assertMsg = "decimal.TryParse(\"" + sample + "\") succeeds.";
                if (decimal.TryParse(sample, out tmpm))
                {
                    Assert.True(true, assertMsg);
                    Assert.AreEqual(st.Item1, tmpm, "Parsed value is " + st.Item1 + ".");
                }
                else
                {
                    Assert.Fail(assertMsg);
                }
            }
        }
    }
}
