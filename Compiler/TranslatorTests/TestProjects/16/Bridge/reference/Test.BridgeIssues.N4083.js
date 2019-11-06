Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    Bridge.define("Test.BridgeIssues.N4083.N4083", {
        $metadata : function () { return {"nested":[Test.BridgeIssues.N4083.N4083.RedBlackNode$1,Test.BridgeIssues.N4083.N4083.App],"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }
    });

    Bridge.define("Test.BridgeIssues.N4083.N4083.App", {
        $kind: "nested class",
        $metadata : function () { return {"td":Test.BridgeIssues.N4083.N4083,"att":1048578,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Main","is":true,"t":8,"sn":"Main","rt":System.Void}]}; },
        main: function Main () {
            var $t, $t1;
            var c = ($t = new (Test.BridgeIssues.N4083.N4083.RedBlackNode$1(System.Int32))(), $t.Key = "1", $t.Value = 1, $t.Left = ($t1 = new (Test.BridgeIssues.N4083.N4083.RedBlackNode$1(System.Int32))(), $t1.Key = "11", $t1.Value = 11, $t1), $t.Right = ($t1 = new (Test.BridgeIssues.N4083.N4083.RedBlackNode$1(System.Int32))(), $t1.Key = "12", $t1.Value = 12, $t1), $t);

            $t = Bridge.getEnumerator(Test.BridgeIssues.N4083.N4083.RedBlackNode$1(System.Int32).GetPairs(c), System.Collections.Generic.KeyValuePair$2(System.String,System.Int32));
            try {
                while ($t.moveNext()) {
                    var pair = $t.Current;
                    System.Console.WriteLine((pair.key || "") + " - " + pair.value);
                }
            } finally {
                if (Bridge.is($t, System.IDisposable)) {
                    $t.System$IDisposable$Dispose();
                }
            }
        }
    });

    Bridge.define("Test.BridgeIssues.N4083.N4083.RedBlackNode$1", function (V) { return {
        $kind: "nested class",
        $metadata : function () { return {"td":Test.BridgeIssues.N4083.N4083,"att":1048578,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"GetPairs","is":true,"t":8,"pi":[{"n":"root","pt":Test.BridgeIssues.N4083.N4083.RedBlackNode$1(V),"ps":0}],"sn":"GetPairs","rt":System.Collections.Generic.IEnumerable$1(System.Collections.Generic.KeyValuePair$2(System.String,V)),"p":[Test.BridgeIssues.N4083.N4083.RedBlackNode$1(V)]},{"a":2,"n":"Key","t":4,"rt":System.String,"sn":"Key"},{"a":2,"n":"Left","t":4,"rt":Test.BridgeIssues.N4083.N4083.RedBlackNode$1(V),"sn":"Left"},{"a":2,"n":"Right","t":4,"rt":Test.BridgeIssues.N4083.N4083.RedBlackNode$1(V),"sn":"Right"},{"a":2,"n":"Value","t":4,"rt":V,"sn":"Value"}]}; },
        statics: {
            methods: {
                GetPairs: function (root) {
                    return new (Bridge.GeneratorEnumerable$1(System.Collections.Generic.KeyValuePair$2(System.String,V)))(Bridge.fn.bind(this, function (root) {
                        var $step = 0,
                            $jumpFromFinally,
                            $returnValue,
                            stack,
                            node,
                            $async_e;

                        var $enumerator = new (Bridge.GeneratorEnumerator$1(System.Collections.Generic.KeyValuePair$2(System.String,V)))(Bridge.fn.bind(this, function () {
                            try {
                                for (;;) {
                                    switch ($step) {
                                        case 0: {
                                            if (root == null) {
                                                    $step = 1;
                                                    continue;
                                                } 
                                                $step = 2;
                                                continue;
                                        }
                                        case 1: {
                                            return false;
                                        }
                                        case 2: {
                                            stack = new (System.Collections.Generic.Stack$1(Test.BridgeIssues.N4083.N4083.RedBlackNode$1(V))).ctor();
                                                node = root;
                                        }
                                        case 3: {
                                            if (node.Left != null) {
                                                    $step = 4;
                                                    continue;
                                                } 
                                                $step = 5;
                                                continue;
                                        }
                                        case 4: {
                                            stack.Push(node);
                                                node = node.Left;
                                                $step = 3;
                                                continue;
                                        }
                                        case 5: {

                                        }
                                        case 6: {
                                            $enumerator.current = new (System.Collections.Generic.KeyValuePair$2(System.String,V)).$ctor1(node.Key, node.Value);
                                                $step = 7;
                                                return true;
                                        }
                                        case 7: {
                                            if (node.Right != null) {
                                                    $step = 8;
                                                    continue;
                                                } 
                                                $step = 9;
                                                continue;
                                        }
                                        case 8: {
                                            node = node.Right;
                                                $step = 3;
                                                continue;
                                        }
                                        case 9: {
                                            if (stack.Count === 0) {
                                                    $step = 10;
                                                    continue;
                                                } 
                                                $step = 11;
                                                continue;
                                        }
                                        case 10: {
                                            return false;
                                        }
                                        case 11: {
                                            node = stack.Pop();
                                                $step = 6;
                                                continue;

                                        }
                                        default: {
                                            return false;
                                        }
                                    }
                                }
                            } catch($async_e1) {
                                $async_e = System.Exception.create($async_e1);
                                throw $async_e;
                            }
                        }));
                        return $enumerator;
                    }, arguments));
                }
            }
        },
        fields: {
            Key: null,
            Value: Bridge.getDefaultValue(V),
            Left: null,
            Right: null
        }
    }; });
});
