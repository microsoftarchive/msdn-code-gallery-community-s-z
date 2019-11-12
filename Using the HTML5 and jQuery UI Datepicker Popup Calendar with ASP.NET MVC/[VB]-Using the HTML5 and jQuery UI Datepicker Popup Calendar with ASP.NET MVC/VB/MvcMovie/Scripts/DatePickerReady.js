

if (!Modernizr.inputtypes.date) {
    $(function () {
        $(".datefield").datepicker();
    });
}


/// Original jQuery popup calendar hookup
///
//$(function () {
//    $(".datefield").datepicker();
//});


/// ------------- This approach uses Chromes native HTML5 datepicker

//var i = document.createElement("input");
//i.setAttribute("type", "date");

//if (!Modernizr.inputtypes.date && i.type != "date") {
//    jQuery(function ($) {
//        $('#datefield').datepicker();
//    })
//}


///// ---- Best script for all browsers
////
//if (!Modernizr.inputtypes.date) {
//    $(function () {
//        $("input[type='date']")
//                    .datepicker()
//                    .get(0)
//                    .setAttribute("type", "text");
//    })
//}
