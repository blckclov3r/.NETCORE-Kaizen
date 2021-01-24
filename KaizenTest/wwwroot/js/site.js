

$("#btnLoader").on('click', function () {
  
    $(".loading-icon").removeClass("hide");
    $("btnLoader").prop('disabled', true);

    setTimeout(function () {
        $(".loading-icon").addClass("hide");
        $("#btnLoader").prop("disabled", false);
    }, 3000);
});







