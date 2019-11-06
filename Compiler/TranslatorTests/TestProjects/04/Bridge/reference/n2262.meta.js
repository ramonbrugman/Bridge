Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";


    var $m = Bridge.setMetadata,
        $n = ["TestProject.Issues","System"];
    $m("TestProject.Issues.N2262", function () { return {"nested":[$n[0].N2262.CI2262,$n[0].N2262.I2262],"att":1048576,"a":4,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"DoSomething","t":8,"sn":"DoSomething","rt":$n[1].Void}]}; }, $n);
});
