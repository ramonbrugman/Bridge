using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [TestFixture(TestNameFormat = "#3977 - {0}")]
    public class Bridge3977
    {
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

            System.Linq.Enumerable.Join(
                    inner: table1,
                    outer: table2,
                    innerKeySelector: row1 => true,
                    outerKeySelector: row2 => true,
                    resultSelector: (stringHolder t1Val, stringHolder t2Val) => {
                        if (t2Val._val == null)
                        {
                            Assert.Fail("t2Val._val == null");
                        }

                        if (t1Val._val == null)
                        {
                            Assert.Fail("t1Val._val == null");
                        }

                        Assert.True(t1Val._val == "world" || t1Val._val == "everybody");
                        Assert.True(t2Val._val == "hello" || t2Val._val == "goodbye");
                        return true;
                    }
             ).All(retc => retc == true);
        }
    }
}