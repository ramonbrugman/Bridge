using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures TryParse/Parse behaves correctly in some
    /// situations.
    /// </summary>
    [TestFixture(TestNameFormat = "#3979 - {0}")]
    public class Bridge3979
    {
        /// <summary>
        /// Tests several combinations for float and double.
        /// </summary>
        [Test]
        public static void TestFloatingPointParse()
        {
            var invalid_samples = new string[]
            {
                "2+1",
                "2ee+1",
                "2e++1",
                "2e+-1",
                "2e--1",
                "2-e--1",
                "2+e+1",
                "2++",
                "2-e+-1",
                "-2+",
                "+2-",
                "+2--",
                "+2--++-+-+3+-+-0-9",
                ".2++",
                ".2+2",
                "+.2+",
                "-3.2-",
                "+4.2-",
                "-.2-",
                "+.2-",
                ".2+", // should work for decimal 
                ".2-", // should work for decimal 
                "1.2-" // should work for decimal 
            };

            foreach (var sample in invalid_samples)
            {
                Assert.Throws<FormatException>(() => float.Parse(sample), "float.Parse(\"" + sample + "\") throws FormatException");
                Assert.Throws<FormatException>(() => double.Parse(sample), "double.Parse(\"" + sample + "\") throws FormatException.");
            }
        }
    }
}
