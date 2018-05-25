<script>
    $(document).ready(function(e) {

        $("#button_intro").click(function () {
            $("#popup_intro").fadeIn();
            $(".main").fadeOut();
            $("sfondo").css("filter")
            $(".sfondo").addClass("sfocatura");
            $(".sfondo").css("filter", "blur(3px)");
        });

    $("#button_work").click(function(){
        $("#popup_work").fadeIn();
    $(".main").fadeOut();
    $(".sfondo").addClass("sfocatura");
    $(".sfondo").css("filter","blur(3px)")
    });

	$("#button_about").click(function(){
        $("#popup_about").fadeIn();
    $(".main").fadeOut();
    $(".sfondo").addClass("sfocatura");
    $(".sfondo").css("filter","blur(3px)")
    });

	$("#button_contact").click(function(){
        $("#popup_contact").fadeIn();
    $(".main").fadeOut();
    $(".sfondo").addClass("sfocatura");
    $(".sfondo").css("filter","blur(3px)")
    });

	$(".chiudi,.sfondo").click(function(){
        $(".popup").fadeOut();
    $(".main").fadeIn();
    $(".sfondo").removeClass("sfocatura");
    $(".sfondo").css("filter","blur(0px)")
     });

});

</script>