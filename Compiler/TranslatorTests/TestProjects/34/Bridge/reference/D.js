/**
 * @compiler Bridge.NET 17.9.0
 */
Bridge.assembly("D", function ($asm, globals) {
    "use strict";

    Bridge.define("D.E", {
        fields: {
            F: null
        },
        ctors: {
            init: function () {
                this.F = "C";
            }
        }
    });
});
