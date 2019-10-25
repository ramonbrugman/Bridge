using Bridge.Test.NUnit;
using X = System.Collections.Generic.List<int>;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures generic types supports being "shorthand" by
    /// the 'using [var] = [full_class_path]'.
    /// </summary>
    [TestFixture(TestNameFormat = "#4076 - {0}")]
    public class Bridge4076
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        static string F<T>(T t)
        {
            return typeof(T).Name;
        }

        /// <summary>
        /// Tests by instantiating the type that is shorthanded by 'using' and
        /// also another generic type that's not shorthanded.
        /// </summary>
        [Test]
        public static void TestTypeAlias()
        {
            var x = new X();
            Assert.AreEqual("List`1", F(x), "Type instantiation expanded from 'using <name> = <full class>' works.");

            var y = new System.Collections.Generic.List<int>();
            Assert.AreEqual("List`1", F(y), "Full class name type instantiation when same type is subject to 'using <name> = <full class>', works.");

            var z = new System.Collections.Generic.Stack<int>();
            Assert.AreEqual("Stack`1", F(z), "Type instantiation from direct class name (not shorthanded by 'using') works.");
        }
    }
}