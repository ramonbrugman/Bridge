Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";


    var $m = Bridge.setMetadata,
        $n = ["TestProject.Issues","System"];
    $m("TestProject.Issues.N2262.I2262", function () { return {"td":$n[0].N2262,"att":163,"a":1,"m":[{"ab":true,"a":2,"n":"Count","t":16,"rt":$n[1].Int32,"g":{"ab":true,"a":2,"n":"get_Count","t":8,"rt":$n[1].Int32,"fg":"TestProject$Issues$N2262$I2262$Count","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"ab":true,"a":2,"n":"set_Count","t":8,"p":[$n[1].Int32],"rt":$n[1].Void,"fs":"TestProject$Issues$N2262$I2262$Count"},"fn":"TestProject$Issues$N2262$I2262$Count"},{"a":1,"backing":true,"n":"<Count>k__BackingField","t":4,"rt":$n[1].Int32,"sn":"TestProject$Issues$N2262$I2262$Count","box":function ($v) { return Bridge.box($v, System.Int32);}}]}; }, $n);
});
