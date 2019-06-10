using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Threading.Tasks;
using Bridge.Test.NUnit;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{
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

        [Test]
        public static void TestMakeGenericMethod()
        {
            Type ex = typeof(Example);
            MethodInfo mi = ex.GetMethod("Generic");
            Assert.NotNull(mi);
            Assert.True(mi.IsGenericMethodDefinition);
            Assert.True(mi.IsGenericMethod);
            Assert.True(mi.ContainsGenericParameters);

            Type[] typeArguments = mi.GetGenericArguments();
            Assert.AreEqual(1, typeArguments.Length);
            Assert.True(typeArguments[0].IsGenericParameter);
            Assert.AreEqual(0, typeArguments[0].GenericParameterPosition);
            Assert.True(typeArguments[0].DeclaringMethod == mi);

            MethodInfo miConstructed = mi.MakeGenericMethod(typeof(int));
            Assert.NotNull(miConstructed);
            Assert.False(miConstructed.IsGenericMethodDefinition);
            Assert.True(miConstructed.IsGenericMethod);
            Assert.False(miConstructed.ContainsGenericParameters);

            typeArguments = miConstructed.GetGenericArguments();
            Assert.AreEqual(1, typeArguments.Length);
            Assert.False(typeArguments[0].IsGenericParameter);


            Example.arg = null;
            object[] args = { 42 };
            miConstructed.Invoke(null, args);
            Assert.AreEqual("42", Example.arg);

            Example.arg = null;
            Example.Generic<int>(42);
            Assert.AreEqual("42", Example.arg);

            MethodInfo miDef = miConstructed.GetGenericMethodDefinition();
            Assert.True(miDef == mi);

        }
    }
}