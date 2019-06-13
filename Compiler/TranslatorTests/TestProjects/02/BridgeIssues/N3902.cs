using Bridge;
using System;

namespace Test.BridgeIssues.N3902
{
    public class N3902
    {
        public void UnicodeStringTranslateFormatted()
        {
            string unicode_escaped_string = "\ud8a1\ud8a2\ue681";
            Console.WriteLine(unicode_escaped_string);
        }
    }
}
