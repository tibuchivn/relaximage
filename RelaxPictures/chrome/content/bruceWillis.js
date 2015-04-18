// Structure - Yahoo JavaScript Module Pattern
//var bruceWillis = function ()
//{
//    var prefManager = Components.classes["@mozilla.org/preferences-service;1"].getService(Components.interfaces.nsIPrefBranch);
   
//    return {
//        init: function () {
//            gBrowser.addEventListener("load", function ()
//            {
//                var autoRun = prefManager.getBoolPref("extensions.brucewillis.autorun");
//                if (autoRun) {
//                    bruceWillis.run();
//                }
//            }, false);
//        },
//        run: function () {
//			alert("Hello! Old function ^_^");
//            //var iframe = document.getElementById("myframe");
//            //iframe.setAttribute("src", "http://dvd.tibuchivn.com/Home/FirefoxExtension");
//        }
//    };
//}();

// Run when DOM has loaded
//window.addEventListener("DOMContentLoaded", bruceWillis.init, false);

function RunRelaxPictures() {
    //alert("Hello! Tung");
    var iframe = document.getElementById("myframe");
    iframe.setAttribute("src", "http://dvd.tibuchivn.com/Home/FirefoxExtension");
}