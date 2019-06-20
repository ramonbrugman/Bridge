using Bridge.Test.NUnit;
using Bridge.ClientTestHelper;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1563 - {0}")]
    public class Bridge1563
    {
        [Test]
        public static void Run()
        {
            CombineDoesNotAffectOriginal_SPI_1563();
            RemoveDoesNotAffectOriginal_SPI_1563();
            RemoveWorksWithMethodGroupConversion();
            CloningDelegateToTheSameTypeCreatesANewClone();
            EqualityAndInequalityOperatorsAndEqualsMethod();
            TestRemove();
        }

        public static void TestRemove()
        {
            var buffer = "";
            Action a1 = () => buffer += "a1";
            Action a2 = () => buffer += "a2";
            Action a3 = a1 + a2;
            Action a4 = () => buffer += "a4";
            Action a5 = a1 + a4 + a2;

            a5 -= a3;

            a5();
        }

        public static void CombineDoesNotAffectOriginal_SPI_1563()
        {
            // #1563
            C c = new C();
            Action a = c.F1;
            Action a2 = a + c.F2;
            Assert.AreEqual(a.GetInvocationList().Length, 1);
            Assert.AreEqual(a2.GetInvocationList().Length, 2);
        }

        public static void RemoveDoesNotAffectOriginal_SPI_1563()
        {
            // #1563
            C c = new C();
            Action a = c.F1;
            Action a2 = a + c.F2;
            Action a3 = a2 - a;
            Assert.AreEqual(a.GetInvocationList().Length, 1);
            Assert.AreEqual(a2.GetInvocationList().Length, 2);
            Assert.AreEqual(a3.GetInvocationList().Length, 1);
        }

        public static void RemoveWorksWithMethodGroupConversion()
        {
            Action a = () =>
            {
            };
            Action a2 = a + A;
            Action a3 = a2 - A;
            Assert.False(a.Equals(a2));
            Assert.True(a.Equals(a3));
        }

        public static void CloningDelegateToTheSameTypeCreatesANewClone()
        {
            int x = 0;
            D1 d1 = () => x++;
            D1 d2 = new D1(d1);
            d1();
            d2();

            Assert.False(d1 == d2);
            Assert.AreEqual(x, 2);
        }

        public static void EqualityAndInequalityOperatorsAndEqualsMethod()
        {
            C c1 = new C(), c2 = new C();
            Action f11 = c1.F1, f11_2 = c1.F1, f12 = c1.F2, f21 = c2.F1;

            Action m1 = f11 + f21, m2 = f11 + f21, m3 = f21 + f11;

            Assert.True(m1 == m2, "m1 == m2");
            Assert.True(m1.Equals(m2), "m1.Equals(m2)");
            Assert.False(m1 != m2, "m1 != m2");
        }

        public delegate void D1();

        private static void A()
        {
        }

        private class C
        {
            public void F1()
            {
            }

            public void F2()
            {
            }
        }
    }
}