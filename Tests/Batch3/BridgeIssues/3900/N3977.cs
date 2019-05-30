using Bridge.Test.NUnit;
using System.Linq;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// Ensures Linq's .Join() extension works for referencing inner and outer
    /// parameter tables.
    /// </summary>
    [TestFixture(TestNameFormat = "#3977 - {0}")]
    public class Bridge3977
    {
        /// <summary>
        /// A simple struct to base the tests with.
        /// </summary>
        struct stringHolder
        {
            public readonly string _val;
            public stringHolder(string val)
            {
                this._val = val;
            }
            public static implicit operator stringHolder(string value)
            {
                return new stringHolder(value);
            }
        }

        /// <summary>
        /// Tests by joining two arrays of stringHolder structs, by inspecting
        /// the individual values. If any happens to be 'null', then the
        /// feature is broken.
        /// </summary>
        [Test]
        public static void TestDirectJoinInvocation()
        {
            var table1 = new stringHolder[] {
                "hello",
                "goodbye"
            };

            var table2 = new stringHolder[] {
                "world",
                "everybody"
            };

            Enumerable.Join(
                inner: table1,
                outer: table2,
                innerKeySelector: row1 => true,
                outerKeySelector: row2 => true,
                resultSelector: (stringHolder t1Val, stringHolder t2Val) =>
                {
                    if (t2Val._val == null)
                    {
                        Assert.Fail("t2Val._val == null");
                    }

                    if (t1Val._val == null)
                    {
                        Assert.Fail("t1Val._val == null");
                    }

                    Assert.True(t1Val._val == "world" || t1Val._val == "everybody", "table 1 element value is '" + t1Val._val + "'.");
                    Assert.True(t2Val._val == "hello" || t2Val._val == "goodbye", "table 2 element value is '" + t2Val._val + "'.");

                    return true;
                }
             ).All(retc => retc == true);
        }
    }
}