

//drp_Materiale

function ChangeMateriale(select) {
    var value = select.options[select.selectedIndex].text;
    $("#manico").css("fill", "url(#"+value+")");
}

function ChangeInserto(select) {
    var value = select.options[select.selectedIndex].text;
    if(value === 'rosso')
        $("#inserto").css("fill", "#cc0000");
    else if (value === 'blu')
        $("#inserto").css("fill", "#D9B52B");
}

function ChangeForo(select) {
    var value = select.options[select.selectedIndex].text;
    if (value === 'piccolo') {
        $("#img_foro").removeClass("foro-8");
        $("#img_foro").addClass("foro-5");
    } else if (value === 'grande') {
        $("#img_foro").removeClass("foro-5");
        $("#img_foro").addClass("foro-8");
    }
}

function WriteText(element) {
    var txt = element.value;
    $("#lbl_etichetta").text(txt);
}