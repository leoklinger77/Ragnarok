$('.cep').change(function () {
    var zipCode = $(this).val();
    $.ajax({
        type: "POST",
        url: "/Service/SearchByZipCode",
        data: { zipCode: zipCode },
        success: function (message) {
            if (message == "Cep inválido") {
                $(".span-cep").html('Cep Inválido');
            } else {
                $(message).each(function (index, item) {
                    $(".span-cep").html('');
                    $("#street").val(item.street);
                    $("#state").val(item.state);

                    $("#city").val(item.city);
                    $("#neighborhood").val(item.neighborhood);

                    $("#cityId").val(item.cityId);
                    $("#stateId").val(item.stateId);
                    
                });
            }
        }
    });
});

$(document).ready(function () {
    $('.excluir').click(function (e) {
        var result = confirm("Tem certeza que seja excluir este registro?");

        if (result == true) {
            return;
        }
        e.preventDefault();
    });
});

$

$('.fullName').change(function () {

    var name = $(this).val();
    let regex = /[@!#$%^&*()/\\1-9]/;

    if (regex.test(name)) {
        $(".span-nameCompleto").html('Não é permitido caracter especial ou números');
        return;
    }

    if (name.length > 10 && name.match(" ")) {
        $(".span-nameCompleto").html('');
        return;
    } else {
        $(".span-nameCompleto").html('Nome incompleto');
        return;
    }

});

$('.fullCompanyName').change(function () {

    var name = $(this).val();

    if (name.length > 20 && name.match(" ")) {
        $(".span-fullCompanyName").html('');
        return;
    } else {
        $(".span-fullCompanyName").html('Razão Social incompleto');
        return;
    }

});


$('.celValidity').change(function () {

    var cel = $(this).cleanVal();

    if (cel.length != 11 ||
        cel == "00000000000" ||
        cel == "11111111111" ||
        cel == "22222222222" ||
        cel == "33333333333" ||
        cel == "44444444444" ||
        cel == "55555555555" ||
        cel == "66666666666" ||
        cel == "77777777777" ||
        cel == "88888888888" ||
        cel == "99999999999") {
        //retorno
        $('.span-celValidity').html("Celular inválido");
        return false;
    }

    if (cel.length == 11) {
        $(".span-celValidity").html('');
        return;
    } else {
        $(".span-celValidity").html('Celular inválido');
        return;
    }

});

$('.telValidity').change(function () {

    var cel = $(this).cleanVal();

    if (cel.length == 0) {
        $(".span-telValidity").html('');
        return;
    }

    if (cel.length != 10 ||
        cel == "0000000000" ||
        cel == "1111111111" ||
        cel == "2222222222" ||
        cel == "3333333333" ||
        cel == "4444444444" ||
        cel == "5555555555" ||
        cel == "6666666666" ||
        cel == "7777777777" ||
        cel == "8888888888" ||
        cel == "9999999999") {
        //retorno
        $('.span-telValidity').html("Telefone inválido");
        return false;
    }

    if (cel.length == 10) {
        $(".span-telValidity").html('');
        return;
    } else {
        $(".span-telValidity").html('Telefone inválido');
        return;
    }

});




