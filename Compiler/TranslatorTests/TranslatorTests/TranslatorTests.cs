using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Bridge.Translator.Tests
{
    [TestFixture]
    internal class TranslatorTests
    {
        [Test]
        public void Issue3989()
        {
            var data = Enumerable.Range(0, (int)(1.5 * 1024 * 1024)).Select(i => (byte)(i % 255)).ToArray();
            byte[] dataFromStream;
            using (var stream = new MemoryStream(data))
            {
                dataFromStream = new TestTranslator().TestReadStream(stream);
            }
            Assert.AreEqual(data, dataFromStream);
        }

        private class TestTranslator : Translator
        {
            public TestTranslator() : base("test") { }

            public byte[] TestReadStream(Stream stream) => base.ReadStream(stream);
        }
    }
}