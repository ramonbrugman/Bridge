using System;
using System.Reflection;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
    /// <summary>
    /// This test ensures the basic definition of MethodInfo.MakeGenericMethod
    /// is consistent.
    /// </summary>
    [Category(Constants.MODULE_ISSUES)]
    [TestFixture(TestNameFormat = "#2894 - {0}")]
    public class Bridge2894
    {
        [Reflectable]
        public class Example
        {
            public static string arg;

            public static void Generic<T>(T toDisplay)
            {
                arg = toDisplay.ToString();
            }
        }

        /// <summary>
        /// Tests based in the MSDN documentation for MethodInfo.MakeGenericMethod:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodinfo.makegenericmethod
        /// </summary>
        /// <remarks>
        /// The '.ToString()' tests are commented out until this aspect of the
        /// feature is implemented.
        /// </remarks>
        [Test]
        public static void TestMakeGenericMethod()
        {
            Type tParam;

            Type ex = typeof(Example);
            MethodInfo mi = ex.GetMethod("Generic");
            Assert.NotNull(mi, "MethodInfo is not null.");
            //Assert.AreEqual("Void Generic[T](T)", mi.ToString(), "Generic method being examined is 'Void Generic[T](T)'.");
            Assert.True(mi.IsGenericMethodDefinition, "Is this a generic method definition? true");
            Assert.True(mi.IsGenericMethod, "Is it a generic method? true");
            Assert.True(mi.ContainsGenericParameters, "Does it have unassigned generic parameters? true");

            Type[] typeArguments = mi.GetGenericArguments();
            Assert.AreEqual(1, typeArguments.Length, "List type arguments (1)");

            // Skip these tests if the typeArguments are not 1 (the assertion
            // above should point the test failed anyway)
            if (typeArguments.Length > 0)
            {
                tParam = typeArguments[0];
                Assert.True(tParam.IsGenericParameter, "Is the argument a generic parameter? true");
                //Assert.AreEqual("T", tParam.ToString(), "Parameter is 'T'");
                Assert.AreEqual(0, tParam.GenericParameterPosition, "parameter position 0");
                Assert.True(tParam.DeclaringMethod == mi, "declaring method is correct");
                //Assert.AreEqual("Void Generic[T](T)", tParam.DeclaringMethod, "Generic method being examined is 'Void Generic[T](T)'.");
            }

            MethodInfo miConstructed = mi.MakeGenericMethod(typeof(int));
            Assert.NotNull(miConstructed, "Constructed generic method is not null.");
            //Assert.AreEqual("Void Generic[Int32](Int32)", miConstructed.ToString(), "Constructed generic method is 'Void Generic[Int32](Int32)'");
            Assert.False(miConstructed.IsGenericMethodDefinition, "Is this a generic method definition? False");
            Assert.True(miConstructed.IsGenericMethod, "Is it a generic method? True");
            Assert.False(miConstructed.ContainsGenericParameters, "Does it have unassigned generic parameters? False");

            typeArguments = miConstructed.GetGenericArguments();
            Assert.AreEqual(1, typeArguments.Length, "List type arguments (1)");

            if (typeArguments.Length > 0)
            {
                tParam = typeArguments[0];
                Assert.False(tParam.IsGenericParameter, "Is the argument a generic parameter? false");
                //Assert.AreEqual("System.Int32", tParam.ToString(), "Constructed generic method's parameter is 'System.Int32'");
            }

            Example.arg = null;
            object[] args = { 42 };
            miConstructed.Invoke(null, args);
            // We are mimicking output from the original documentation test code.
            Assert.AreEqual("42", Example.arg, "Here it is: 42");

            Example.arg = null;
            Example.Generic<int>(42);
            Assert.AreEqual("42", Example.arg, "Here it is: 42");

            MethodInfo miDef = miConstructed.GetGenericMethodDefinition();
            Assert.True(miDef == mi, "GetGenericMethodDefinition returns the correct reference.");
        }
    }
}