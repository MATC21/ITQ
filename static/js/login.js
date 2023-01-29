

    $(document).ready(function () {

        //$.backstretch("static/images/backgrounds/background.png");

        $("#request_pass").click(function (event) {
            event.preventDefault();
            $('#myModalEmail').modal('show');
        });        

        $.backstretch([
           // "static/images/backgrounds/background.png",
            //"static/images/backgrounds/background2.png",
            "static/images/backgrounds/background4.png",
        ], {
            fade: 1000,
            duration: 2000
        });

        LoadName();

        /*LoadLocales();

        $('select').on('change', function () {

            if ($('select').val() != 0) {
                $("#divpuser").attr({ "style": "display: normal" });
                $("#divpass").attr({ "style": "display: normal" });
                $("#grp_btn").attr({ "style": "display: normal" });
            }
            else {
                $("#divpuser").attr({ "style": "display: none" });
                $("#divpass").attr({ "style": "display: none" });
                $("#grp_btn").attr({ "style": "display: none" });
            }
            
        })*/

    });

    /*$(document).keypress(function (e) {
        if (e.which == 13) {
            verify();
        }
    });*/

    
    function sendEmail() {

        var pass = $('#pass_email').val();

        $.ajax({
            type: "POST",
            url: "login.aspx/sendEmail",
            data: "{password:'" + pass + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                var sect = res.d;
                $('#myModalEmail').modal('hide');
                if (sect == "true") {                    

                    $('#textHtmlS').html('Se envió correctamente la contraseña nueva al correo-e del Administrador del Sistema');
                    $('#myModalResponseS').modal('show');

                } else {
                    $('#textHtmlD').html('Ha ocurrido un error...');
                    $('#myModalResponseD').modal('show');
                }
            },
            error: function () {
            }
        });
    }

    function verify() {
        var user = $('#tbuser').val();
        var password = $('#tbpass').val();
        var hfmode = $('#hfmode').val();

        $.ajax({
            type: "POST",
            url: "login.aspx/verify",
            data: "{user:'" + user + "', password:'" + password + "', hfmode:'" + hfmode + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                
            },
            error: function () {
            }
        });
    }

    function msg(message) {
        $('#text-msg').html('<span aria-hidden="true" class="glyphicon glyphicon-info-sign"></span> ' + message);
        $('#alert-msg').show();
        /*$("#divpuser").attr({ "style": "display: normal" });
        $("#divpass").attr({ "style": "display: normal" });
        $("#grp_btn").attr({ "style": "display: normal" });*/
        
        //mode();
        //LoadLocales();
        //$("#selectLocal").val($("#hfmode").val());
    }

    function LoadName() {
        $.ajax({
            type: "POST",
            url: "login.aspx/GetName",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                var sect = res.d;
                
                $("#site_name").html(sect);
            },
            error: function () {
            }
        });
    }
    
    function cancelar() {
        //LoadLocales();
        /*$("#divpuser").attr({ "style": "display: none" });
        $("#divpass").attr({ "style": "display: none" });
        $("#grp_btn").attr({ "style": "display: none" });*/
        $('#tbuser').val('');
        $('#alert-msg').hide();        
    }

    function mode() {
        var mode = $("#selectLocal").val();
        $("#hfmode").val(mode);
    }