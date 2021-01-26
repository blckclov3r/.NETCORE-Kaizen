
$('input[type=submit]').click(function () {
    $(this).attr('disabled', 'disabled');
    $(this).parents('form').submit();
});



$("#btnLoader").on('click', function () {
    let old_timestamp = null;

    $("#btnLoader").prop('disabled', true);

    setTimeout(function () {
        $(".loading-icon").addClass("hide");
        $("#btnLoader").prop('disabled', false);
    }, 3000);

    if (old_timestamp == null || old_timestamp + 1000 < event.timeStamp) {

        // code
        $(".loading-icon").removeClass("hide");

        $("form").submit();

        old_timestamp = event.timeStamp;
    }
});








