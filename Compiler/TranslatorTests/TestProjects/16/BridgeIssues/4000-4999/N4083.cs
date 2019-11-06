using System.Collections.Generic;
using System.Diagnostics;

namespace Test.BridgeIssues.N4083
{
    public class N4083
    {
        public class RedBlackNode<V>
        {
            public string Key;
            public V Value;
            public RedBlackNode<V> Left;
            public RedBlackNode<V> Right;

            public static IEnumerable<KeyValuePair<string, V>> GetPairs(RedBlackNode<V> root)
            {
                if (root == null)
                    yield break;

                Stack<RedBlackNode<V>> stack = new Stack<RedBlackNode<V>>();
                RedBlackNode<V> node = root;

            LStart:
                if (node.Left != null)
                {
                    stack.Push(node);
                    node = node.Left;
                    goto LStart;
                }

            LYieldSelf:
                yield return new KeyValuePair<string, V>(node.Key, node.Value);

                if (node.Right != null)
                {
                    node = node.Right;
                    goto LStart;
                }

                if (stack.Count == 0)
                    yield break;

                node = stack.Pop();
                goto LYieldSelf;
            }
        }

        public class App
        {
            public static void Main()
            {
                var c = new RedBlackNode<int>
                {
                    Key = "1",
                    Value = 1,
                    Left = new RedBlackNode<int>
                    {
                        Key = "11",
                        Value = 11
                    },
                    Right = new RedBlackNode<int>
                    {
                        Key = "12",
                        Value = 12
                    }
                };

                foreach (var pair in RedBlackNode<int>.GetPairs(c))
                {
                    System.Console.WriteLine(pair.Key + " - " + pair.Value);
                }
            }
        }
    }
}