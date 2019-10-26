using Bridge.Test.NUnit;
using System;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// The tests here ensures math involving delegates works.
    /// </summary>
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#1563 - {0}")]
    public class Bridge1563
    {
        /// <summary>
        /// Tests the scenario provided in gitter.
        /// </summary>
        [Test]
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

            Assert.AreEqual("a1a4a2", buffer, "The delegates' side effects were applied in the expected order.");
        }

        // <summary>
        /// Tests another scenario where actions' subtraction was not working.
        /// This scenario triggered if there was anything between two matches
        /// in the removal.
        /// </summary>
        [Test]
        public static void TestRemove2()
        {
            var buffer = "";
            Action a1 = () => buffer += "a1";
            Action a2 = () => buffer += "a2";
            Action a3 = a1 + a2;
            Action a4 = () => buffer += "a4";
            Action a41 = () => buffer += "a41";
            Action a5 = a4 + a1 + a2 + a41 + a1 + a2 + a4;

            a5 -= a3;

            a5();
            Assert.AreEqual("a4a1a2a41a4", buffer, "The delegates' Side effects were applied in the expected order.");
        }

        /// <summary>
        /// Checks combination
        /// </summary>
        [Test]
        public static void CombineDoesNotAffectOriginal_SPI_1563()
        {
            // #1563
            C c = new C();
            Action a = c.F1;
            Action a2 = a + c.F2;
            Assert.AreEqual(1, a.GetInvocationList().Length, "Invocation list in base delegate has 1 entry.");
            Assert.AreEqual(2, a2.GetInvocationList().Length, "Invocation list in combined delegate has 2 entries.");
        }

        /// <summary>
        /// Checks combination and removal
        /// </summary>
        [Test]
        public static void RemoveDoesNotAffectOriginal_SPI_1563()
        {
            // #1563
            C c = new C();
            Action a = c.F1;
            Action a2 = a + c.F2;
            Action a3 = a2 - a;
            Assert.AreEqual(a.GetInvocationList().Length, 1, "Invocation list in original delegate has 1 entry.");
            Assert.AreEqual(a2.GetInvocationList().Length, 2, "Invocation list in combined delegate has 2 entries.");
            Assert.AreEqual(a3.GetInvocationList().Length, 1, "Invocation list in differentiated delegate has 1 entry.");
        }

        /// <summary>
        /// Checks removal with method group.
        /// </summary>
        [Test]
        public static void RemoveWorksWithMethodGroupConversion()
        {
            Action a = () =>
            {
            };
            Action a2 = a + A;
            Action a3 = a2 - A;
            Assert.False(a.Equals(a2), "Base delegate .Equals() against its aggregate delegate returns false.");
            Assert.True(a.Equals(a3), "Base delegate .Equals() against a differentiate aggregate are equal (when all other aggregated delegates are removed).");
        }

        /// <summary>
        /// Checks cloning deleates
        /// </summary>
        [Test]
        public static void CloningDelegateToTheSameTypeCreatesANewClone()
        {
            int x = 0;
            D1 d1 = () => x++;
            D1 d2 = new D1(d1);
            d1();
            d2();

            Assert.False(d1 == d2, "A delegate is not equal to another delegate cloned from it.");
            Assert.AreEqual(x, 2, "Both the original and cloned delegates' calls side effects works.");
        }

        /// <summary>
        /// Checks equality-related operators
        /// </summary>
        [Test]
        public static void EqualityAndInequalityOperatorsAndEqualsMethod()
        {
            C c1 = new C(), c2 = new C();
            Action f11 = c1.F1, f11_2 = c1.F1, f12 = c1.F2, f21 = c2.F1;

            Action m1 = f11 + f21, m2 = f11 + f21, m3 = f21 + f11;

            Assert.True(m1 == m2, "Two delegates declared with the same aggregation expression are equal via the '==' operator.");
            Assert.True(m1.Equals(m2), "Two delegates declared with the same aggregation expression are equal via the .Equals() call.");
            Assert.False(m1 != m2, "Two delegates declared with the same aggregation expression are not different ('!=' operator works).");
        }

        #region Auxiliary code used to explore the feature/issues in the tests.

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

        #endregion Auxiliary code used to explore the feature/issues in the tests.
    }
}