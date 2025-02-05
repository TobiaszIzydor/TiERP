$(document).ready(function () {
    $(".toggle-btn").click(function () {
        $(".link-text").toggleClass("hidden");
        $("aside .toggle-size").each(function () {
            var element = $(this);
            if (element.width() === 24 && element.height() === 24) {
                element.css({
                    "width": "48px",
                    "line-height": "48px",
                    "height": "48px"
                });
            } else {
                element.css({
                    "width": "24px",
                    "line-height": "24px",
                    "height": "24px"
                });
            }
        });
        $("aside").toggleClass("p-3").toggleClass("p-1");
        $(".rotate").toggleClass("rotate-180");
        $("aside .navbar-nav").toggleClass("mx-auto");
        $("aside li .collapse").removeClass("show");
        $("aside .nav").each(function () {
            var element = $(this);
            if (element.width() === 250) {
                element.css({
                    "width": "77.6px"
                });
            } else {
                element.css({
                    "width": "250px"
                });
            }
        });
    });
});