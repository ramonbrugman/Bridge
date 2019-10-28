/**
 * @compiler Bridge.NET 17.10.1
 */
Bridge.assembly("A", function ($asm, globals) {
    "use strict";

    Bridge.define("A.B", {
        statics: {
            fields: {
                C: null
            },
            ctors: {
                init: function () {
                    this.C = "C";
                }
            }
        }
    });
});
