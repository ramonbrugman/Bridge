Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    /** @namespace Test.BridgeIssues.N3745 */

    /**
     * #3745 ensure an extra variable definition line is not output when using
     implicit functions code (not confirmed) C#7 syntax.
     *
     * @public
     * @class Test.BridgeIssues.N3745.N3745
     */
    Bridge.define("Test.BridgeIssues.N3745.N3745", {
        $metadata : function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"f3","is":true,"t":8,"pi":[{"n":"f1","pt":Function,"ps":0}],"sn":"f3","rt":Function,"p":[Function]}]}; },
        statics: {
            methods: {
                f3: function (f1) {
                    // p1 below shouldn't show in both function argument
                    // and variables declaration.
                    return function (p1) {
                        var $step = 0,
                            $task1, 
                            $taskResult1, 
                            $jumpFromFinally, 
                            $asyncBody = Bridge.fn.bind(this, function () {
                                for (;;) {
                                    $step = System.Array.min([0,1], $step);
                                    switch ($step) {
                                        case 0: {
                                            p1 = null;

                                            $task1 = f1();
                                            $step = 1;
                                            if ($task1.isCompleted()) {
                                                continue;
                                            }
                                            $task1.continue($asyncBody);
                                            return;
                                        }
                                        case 1: {
                                            $taskResult1 = $task1.getAwaitedResult();
                                            return;
                                        }
                                        default: {
                                            return;
                                        }
                                    }
                                }
                            }, arguments);

                        $asyncBody();
                    };
                }
            }
        }
    });
});
