

//drp_Materiale

function ChangeMateriale(select) {
    var value = select.options[select.selectedIndex].text
    $("#manico").css("background-image", "url(../imgs/mat-metal.jpg)");
}
