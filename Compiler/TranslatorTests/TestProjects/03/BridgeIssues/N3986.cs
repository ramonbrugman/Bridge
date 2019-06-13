using Bridge;
using System;

namespace Test.BridgeIssues.N3986
{
    public class N3986
    {
        public void UnicodeStringTranslateMinified()
        {
            string unicode_escaped_string = "\ud8a1\ud8a2\ue681";
            Console.WriteLine(unicode_escaped_string);
        }
    }
}
