$(document).ready(function () {
    //Скрыть PopUp при загрузке страницы    
    PopUpHide();
});


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



        //Функция отображения PopUp
        function PopUpShow() {
            $("#popup1").css("display", "block");
            $("#popup1").show();
        }
        //Функция скрытия PopUp
        function PopUpHide() {
            $("#popup1").hide();
        }
     