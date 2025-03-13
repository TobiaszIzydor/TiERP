$(document).ready(function () {
    $(".toggle-btn").click(function () {
        $(".dropdown-header, .dropdown-divider, .link-text").toggleClass("hidden");
        $("aside .toggle-size").each(function () {
            var element = $(this);
            if (element.width() === 24 && element.height() === 24) {
                element.css({
                    "width": "40px",
                    "line-height": "40px",
                    "height": "40px"
                });
            } else {
                element.css({
                    "width": "24px",
                    "line-height": "24px",
                    "height": "24px"
                });
            }
        });
        $("aside").toggleClass("p-3").toggleClass("p-1").toggleClass("ps-2");
        $("#sidebar").toggleClass("collapsed");
        $(".rotate").toggleClass("rotate-180");
        $("aside .navbar-nav").toggleClass("mx-auto");
        $("aside li .collapse").removeClass("show").toggleClass("dropdown-menu");
        $("aside .nav").each(function () {
            var element = $(this);
            if (element.width() === 234) {
                element.css({
                    "width": "84px"
                });
            } else {
                element.css({
                    "width": "250px"
                });
            }
        });
        $("aside .nav").toggleClass("p-2").toggleClass("p-1");

        var $buttons = $('.nav-button');
        if ($('#sidebar').hasClass('collapsed')) {
            $buttons.attr("data-bs-toggle", "dropdown")
        }
        else {
            $buttons.attr("data-bs-toggle", "collapse")
        }
    });
    $('[data-bs-toggle="collapse"][data-lock-when-collapsed="true"]').on('click', function (event) {
        if ($('#sidebar').hasClass('collapsed')) {
            event.preventDefault();
        }
    });
});
