using Bridge.Test.NUnit;
using System;
using Wrapper = System.Collections.Generic.List<int>;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#4072 - {0}")]
    public class Bridge4072
    {
        private static bool TryGet(out Wrapper x)
        {
            x = new Wrapper();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public static void TestTypeAlias()
        {
            bool c = TryGet(out Wrapper x);
            Assert.True(c);
        }
    }
}