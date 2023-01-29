
$(document).ready(function () {
    verifySession();
    
});

function verifySession() {
    $.ajax({
        type: "POST",
        url: "../../../../../../../index.aspx/sessionActive",
        data: "{id: 0 }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res.d == "false") {
                // setTimeout("verifySession()",30000);
                setTimeout("verifySession()", 2500);
            } else {
                window.location.href = "../../../../../../../login.aspx";
            }  
        },
        error: function (s) {
            window.location.href = "../../../../../../../login.aspx";
        }
    });
}

function tamNumeros(input, num) {
    $("#" + input + "").numeric({ nocaps: true });
    $("#" + input + "").keyup(function (event) {
        if ($("#" + input + "").val().length >= num) {
            var aux = $("#" + input + "").val().slice(0, num);
            $("#" + input + "").val(aux);
        }
    });
    
}

function Email(input) {
    var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
    if (regex.test($("#" + input + "").val().trim()));
    else ViewError("El formato del correo no es valida");
    // else alert('El formato del correo no es valida');

}

function Url(input) {
    patron = /^www.\w+.\w+$/gi;
    if (patron.test($("#" + input + "").val().trim()));
    else ViewError("El formato del la  url no es invalida");
    // else alert("El formato del la  url no es invalida");
}

function tam(input,num) {
    $("#" + input + "").keyup(function (event) {
        if ($("#" + input + "").val().length >= num) {
            var aux = $("#" + input + "").val().slice(0, num);
            $("#" + input + "").val(aux);
        }
    });
}

function tamTexto(input, num) {
    $("#" + input + "").alpha({ nocaps: true });
    $("#" + input + "").keyup(function (event) {
        if ($("#" + input + "").val().length >= num) {
            var aux = $("#" + input + "").val().slice(0, num);
            $("#" + input + "").val(aux);
        }
    });
}

function Texto(input) {
    $("#" + input + "").alpha({ nocaps: true });   
}

function Requeridos(input,modal,msm) {

    if ($("#" + input + "").val().length > 0) $("#" + input + "").css("border-color", "#5cb85c");
    else {
        $("#" + input + "").css("border-color", "#a94442");
        LLamarModal(modal, msm);
    }   
}

function PopupModalImg(img) {
    var img = $("#" + img + "").attr("src");
    $('#myModal0').modal({
        show: 'false'
    });

    $("#myModalLabel").html("<table class='table table-bordered table-striped table-condensend table-hover'><tr><td><img src='" + img + "' Width='500px' height='400px' /></td></tr></table>");
}

function LLamarModal(num,msm) {
    switch (num) {
        case 0://normal
            ViewNormal(msm);
            break;
        case 1://ok
            ViewOk(msm);
            break;
        case 2://error
            ViewError(msm);
            break;
        case 3://Warnig
            ViewWarnig(msm);
            break;
        case 4://info
            ViewInfo(msm);
            break;
    }
}

function ViewNormal(msm) {
    $('#myModal0').modal({
        show: 'false'
    });
    $("#myModalLabel").html("" + msm + "");
}

function ViewError(msm) {
    $('#myModal').modal({
        show: 'false'
    });
    $("#textHtmlDanger").html("" + msm + "");
}

function ViewOk(msm) {
    $('#myModal1').modal({
        show: 'false'
    });
    $("#textHtml").html("" + msm + "");
}

function ViewWarnig(msm) {
    $('#myModal2').modal({
        show: 'false'
    });
    $("#textHtmlW").html("" + msm + "");
}

function ViewInfo(msm) {
    $('#myModal3').modal({
        show: 'false'
    });
    $("#textHtmlI").html("" + msm + "");
}

function LoadDivis() {
    if ($(".mydivs").html()) {
        $(".mydivs").html("<div class='modal fade' id='myModal1' style='z-index:99999;' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true' > <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header modal-header-success'> <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>&times;</span><span class='sr-only'></span> </button> <h4 class='modal-title' >Información</h4> </div> <div class='modal-body'> <p id='textHtml'></p> </div> </div> </div> </div> <div class='modal fade' id='myModal' style='z-index:99999;' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'> <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header modal-header-danger'> <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>&times;</span><span class='sr-only'></span> </button> <h4 class='modal-title' >Informacion</h4> </div> <div class='modal-body'> <p id='textHtmlDanger'></p> </div> </div> </div> </div>      <div class='modal fade' id='myModal0' style='z-index:99999;' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'> <div class='modal-dialog' role='document'> <div class='modal-content'> <div class='modal-header'> <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <h4 class='modal-title' id='myModalLabel'>Modal title</h4> </div> <div class='modal-body'> <div class='contenido'></div> </div> </div> </div> </div>  <div class='modal fade' id='myModal2' style='z-index:99999;'  tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'> <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header modal-header-warning'> <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>&times;</span><span class='sr-only'></span> </button> <h4 class='modal-title' >Informacion</h4> </div> <div class='modal-body'> <p id='textHtmlW'></p> </div> </div> </div> </div>      <div class='modal fade' id='myModal3' style='z-index:99999;'  tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'> <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header modal-header-info'> <button type='button' class='close' data-dismiss='modal'><span aria-hidden='true'>&times;</span><span class='sr-only'></span> </button> <h4 class='modal-title' >Informacion</h4> </div> <div class='modal-body'> <p id='textHtmlI'></p> </div> </div> </div> </div>");

        $('.modal').on('hidden.bs.modal', function () {
            $("body").css("padding-right", "0px");
            $(".container-fluid").css("width", "100%");
        });

    } else {
        alert("Agrege el div mydivs");
    }
}

