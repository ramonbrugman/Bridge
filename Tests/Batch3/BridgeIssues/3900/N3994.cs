using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3994 - {0}")]
    public class Bridge3994
    {
        public enum TestEnum
        {
            Test,
            Test01
        }

        private static TestEnum TestFnc(TestEnum testEnum = TestEnum.Test)
        {
            return testEnum;
        }

        [Test]
        public static void TestEnumOptionalParam()
        {
            Assert.AreEqual(TestEnum.Test, TestFnc());
        }
    }
}
