using Bridge.Test.NUnit;
using System.Collections.Generic;

namespace Bridge.ClientTest.Batch3.BridgeIssues
{

    /// <summary>
    /// The tests here ensures dictionaries can contain "hasOwnProperty" string
    /// as keys.
    /// </summary>
    [TestFixture(TestNameFormat = "#4069 - {0}")]
    public class Bridge4069
    {
        /// <summary>
        /// Tests by just assigning dictionary a key named "hasOwnProperty"
        /// (sets it up to break) then add another entry (name doesn't matter,
        /// triggers the issue).
        /// </summary>
        /// <remarks>
        /// Two situations are enough to trigger the issue:
        /// (a) add the "hasOwnProperty" element then add another any element
        /// to the dictionary;
        /// (b) add the "hasOwnProperty" element then fetch it.
        /// This test accumulates the two scenarios.
        /// </remarks>
        [Test]
        public static void TestDictWithHasOwnPropertyKey()
        {
            var dict = new Dictionary<string, bool>();
            dict.Add("hasOwnProperty", true);
            dict.Add("anything_else", true);

            Assert.True(dict["hasOwnProperty"], "Dictionaries can have keys with the \"hasOwnProperty\" string.");
        }
    }
}