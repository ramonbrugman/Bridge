using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures default value in method parameters for enum works.
    /// </summary>
    [TestFixture(TestNameFormat = "#3994 - {0}")]
    public class Bridge3994
    {
        /// <summary>
        /// An enum to use as default parameter to the test method.
        /// </summary>
        public enum TestEnum
        {
            Test,
            Test01
        }

        /// <summary>
        /// A test method taking as parameter the enum above, and choosing
        /// its first value as the default.
        /// </summary>
        /// <param name="testEnum">Enum parameter taking a default.</param>
        /// <returns>THe specified (or default) enum.</returns>
        private static TestEnum TestFnc(TestEnum testEnum = TestEnum.Test)
        {
            return testEnum;
        }

        /// <summary>
        /// Tests by calling the method without providing the value, so the
        /// return is the default enum value.
        /// </summary>
        [Test]
        public static void TestEnumOptionalParam()
        {
            Assert.AreEqual(TestEnum.Test, TestFnc(), "Method with enum parameter's default value works.");
        }
    }
}
