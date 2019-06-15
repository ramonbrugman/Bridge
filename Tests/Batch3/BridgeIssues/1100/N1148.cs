using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1148 - {0}")]
    public class Bridge1148
    {
        [Test]
        public static void TestDecimalOverflow()
        {
            var nan = double.NaN;
            var p = double.PositiveInfinity;
            var n = double.NegativeInfinity;
            var max = double.MaxValue;
            var min = double.MinValue;

            // https://msdn.microsoft.com/en-us/library/aa691289(v=vs.71).aspx
            // If the source value is NaN, infinity, or too large to represent as a decimal, a System.OverflowException is thrown.
            Assert.Throws<OverflowException>(() => { var x = (decimal)nan; }, "NaN -> decimal");
            Assert.Throws<OverflowException>(() => { var x = (decimal)p; }, "PositiveInfinity -> decimal");
            Assert.Throws<OverflowException>(() => { var x = (decimal)n; }, "NegativeInfinity -> decimal");
            Assert.Throws<OverflowException>(() => { var x = (decimal)max; }, "MaxValue -> decimal");
            Assert.Throws<OverflowException>(() => { var x = (decimal)min; }, "MinValue -> decimal");
        }
    }
}