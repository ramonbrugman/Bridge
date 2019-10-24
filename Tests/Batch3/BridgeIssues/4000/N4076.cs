using Bridge.Test.NUnit;
using System;
using X = System.Collections.Generic.List<int>;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#4076 - {0}")]
    public class Bridge4076
    {
        static string F<T>(T t)
        {
            return typeof(T).Name;
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public static void TestTypeAlias()
        {
            var x = new X();
            Assert.AreEqual("List`1", F(x));
            var y = new System.Collections.Generic.Stack<int>();
            Assert.AreEqual("Stack`1", F(y));
        }
    }
}