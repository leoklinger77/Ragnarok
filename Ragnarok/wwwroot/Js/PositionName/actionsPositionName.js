$(document).ready(function () {
    //Insert de novos Cargos
    $('#btnSalvePositionName').click(function () {
        var send = "{Name:'" + $('#positionName').val() + "'}";

        var positionName = eval("(" + send + ")");

        $.ajax({
            type: "POST",
            url: "/Employee/PositionName/Insert",
            data: { positionName: positionName },
            success: function (message) {

                if (message == 'Ok') {
                    window.location.href = "/Employee/PositionName/Index";
                } else {
                    $('#span-insertPosition').html('Carga já existente');
                }
            }
        });
    });

});