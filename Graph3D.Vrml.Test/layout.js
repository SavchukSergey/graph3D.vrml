(function () {
    var sticky = new StickyLayout();;
    var fullWidth = new FullWidthLayout();

    $(document).ready(function () {
        fullWidth.refresh();
        sticky.init();
        sticky.refresh();

        $('[data-full-width-large], [data-full-width-small], .mb-full-width').css('visibility', '');
    });

    $(window).scroll(function() {
        sticky.refresh();
    });

    $(window).resize(function () {
        fullWidth.refresh();
        sticky.onResize();
        sticky.refresh();
    });

    Harvey.attach('only screen and (max-width: 767px)', {
        on: function () {
            fullWidth.applyFullWidth('small');
            sticky.onResize();
            sticky.refresh();
        }
    });
    Harvey.attach('only screen and (min-width: 768px)', {
        on: function () {
            fullWidth.applyFullWidth('large');
            sticky.onResize();
            sticky.refresh();
        }
    });
})();