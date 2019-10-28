/**
 * @compiler Bridge.NET 17.10.1
 */
Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";

    Bridge.define("Test.BridgeIssues.N3891.App", {
        fields: {
            byteArray: null,
            byteArrayList: null,
            comment: null
        },
        ctors: {
            init: function () {
                this.byteArray = System.Array.init(new Uint8Array(8), System.Byte);
                this.byteArrayList = new (System.Collections.Generic.List$1(Uint8Array)).ctor();
                this.comment = "The line above should contain 'List$1(Uint8Array))'.";
            }
        }
    });
});
