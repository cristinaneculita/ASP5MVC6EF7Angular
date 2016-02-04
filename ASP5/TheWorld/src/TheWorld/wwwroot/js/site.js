//site.js
(function () {

    //var ele = $("#username");
    //ele.text("Cristina & Alexandra");

    //var main = $("#main");
    //main.on("mouseenter", function() {
    //    main.style = "background-color: #888";
    //});
    //main.on("mouseleave", function () {
    //    main.style = "background-color: #888";
    //});
    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    var $sidebarAndWrapper = $("#sidebar,#wrapper");

    $("#sidebarToggle").on("click", function() {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $(this).text(" Show sidebar");
        } else {
            $(this).text(" Hide sidebar");
        }
    });

})();