$(document).ready(function () {
    LoadDivis();
});


function GenerateExcel(idcontrol,nombre) {
    $("#" + idcontrol+"").table2excel({
        exclude: ".noExl",
        name: "Excel Document Name",
        filename: ""+nombre+"",
        exclude_img: true,
        exclude_links: true,
        exclude_inputs: true
    });
}

function upperCase(str) {
    return str.toUpperCase();
}

function convertFirtUpper(str) {
    var firstLetterRx = /(^|\s)[a-z]/g;
    return str.replace(firstLetterRx, upperCase);
}

function calculateLength(text, length, field) {
    var longitud = text.length;
    if (longitud == length) {
        if (field != undefined) {
            $("#" + field.id + "").val(text);
        } else {
            return text;
        }

    } else {
        var diferencia = parseInt(length) - parseInt(longitud);
        var relleno = '';
        if (diferencia == 1) {
            relleno = '0';
        } else {
            var i = 0;
            while (i < diferencia) {
                relleno += '0';
                i++;
            }
        }
        if (field != undefined) {
            $("#" + field.id + "").val(relleno + text);
        } else {
            return relleno + text;
        }

    }
}

function VideoTutorial(tipo) {
    switch(tipo){
        case "PROV":
            LLamarModal(3, "En Construccion.....!!");
            break;
    }
}