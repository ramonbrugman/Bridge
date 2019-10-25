using Bridge.Test.NUnit;
using Wrapper = System.Collections.Generic.List<int>;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{

    /// <summary>
    /// The tests here consists in ensuring 'out Type variable' syntax is
    /// supported on TryGet.
    /// </summary>
    [TestFixture(TestNameFormat = "#4072 - {0}")]
    public class Bridge4072
    {
        /// <summary>
        /// TryGet() implementation using type 'Wrapper' as parameter.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static bool TryGet(out Wrapper x)
        {
            x = new Wrapper();
            return true;
        }

        /// <summary>
        /// Tests by simply calling the TryGet() implementation in the
        /// required format. Notice if the x variable is declared somewhere
        /// else and used there (as just '(out x)'), the issue related to this
        /// test is not reproduced.
        /// </summary>
        [Test]
        public static void TestTypeAlias()
        {
            bool c = TryGet(out Wrapper x);
            Assert.True(c, "'out <type> <variable>' parameter syntax is supported.");
        }
    }
}