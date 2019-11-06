Bridge.assembly("TestProject", function ($asm, globals) {
    "use strict";


    var $m = Bridge.setMetadata,
        $n = ["TestProject.Issues","System"];
    $m("TestProject.Issues.N2262.CI2262", function () { return {"td":$n[0].N2262,"att":1048579,"a":1,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Count","t":16,"rt":$n[1].Int32,"g":{"a":2,"n":"get_Count","t":8,"rt":$n[1].Int32,"fg":"Count","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"a":2,"n":"set_Count","t":8,"p":[$n[1].Int32],"rt":$n[1].Void,"fs":"Count"},"fn":"Count"},{"a":1,"backing":true,"n":"<Count>k__BackingField","t":4,"rt":$n[1].Int32,"sn":"Count","box":function ($v) { return Bridge.box($v, System.Int32);}}]}; }, $n);
});
