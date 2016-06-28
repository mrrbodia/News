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

        var createButton = document.getElementsByClassName('create-button')[0];
        var createPopup = document.getElementById('admin-create');
        createButton.onclick = function () {
            debugger;
            createPopup.style.display = "block";
            createButton.style.display = "none";
        }
        var declineButton = document.getElementsByClassName('decline-create')[0];
        declineButton.onclick = function () {
            debugger;
            createPopup.style.display = "none";
            createButton.style.display = "block"
        }
     