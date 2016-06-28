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

        var a = document.getElementsByClassName('create-button')[0];
        var createPopup = document.getElementById('admin-create');
        a.onclick = function () {
            createPopup.style.display = "block";
            a.style.display = "none";
        }
        var b = document.getElementsByClassName('decline-create')[0];
        b.onclick = function () {
            createPopup.style.display = "none";
            a.style.display = "block"
        }