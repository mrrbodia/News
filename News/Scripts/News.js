        $(".updateNews").on("click", function () {
            var $newsContainer = $(this).parents('.event_holder').first();
            $newsContainer.find('.event_wrapper').eq(0).hide();
            $('.update', $newsContainer).show();
        })

        $(".update-cancel").on("click", function() {
            var $newsContainer = $(this).parents('.event_holder').first();
            $newsContainer.find('.event_wrapper').eq(0).show();
            $('.update', $newsContainer).hide();
        })