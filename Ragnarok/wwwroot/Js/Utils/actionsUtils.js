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

$('.cpf').change(function () {

    var cpf = $('.cpf').val();

    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf == '') {
        //retorno
        $('.validationCpf').html("Inválido");
        return false;
    }
    // Elimina CPFs invalidos conhecidos	
    if (cpf.length != 11 ||
        cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999") {
        //retorno
        $('.validationCpf').html("Inválido");
        return false;
    }

    // Valida 1o digito	
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11)
        rev = 0;
    if (rev != parseInt(cpf.charAt(9))) {
        //retorno
        $('.validationCpf').html("Inválido");
        return false;
    }

    // Valida 2o digito	
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev == 10 || rev == 11) {
        rev = 0;
    }
    if (rev != parseInt(cpf.charAt(10))) {
        //retorno
        $('.validationCpf').html("Inválido");
        return false;

    }


    if ($('.validationCpf').html() != '') {
        $('.validationCpf').html('');
    }


    $.ajax({
        type: "POST",
        url: "/Service/ValidityInsertCPFEmployee",
        data: { cpf },
        success: function (response) {
            if (response != "Ok") {
                $('.validationCpf').html(response);
                return false;
            }

            $('.validationCpf').html('');
            return true;
        },
    });

});

$('.fullName').change(function () {

    var name = $('.fullName').val();
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

$('.celValidity').change(function () {

    var cel = $('.celValidity').cleanVal();

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

    var cel = $('.telValidity').cleanVal();

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
        $('.span-telValidity').html("Celular inválido");
        return false;
    }

    if (cel.length == 10) {
        $(".span-telValidity").html('');
        return;
    } else {
        $(".span-telValidity").html('Celular inválido');
        return;
    }

});

$('#employeeEmail').change(function () {
    var email = $('#employeeEmail').val();


    if (email.includes("@")) {


        $.ajax({
            type: "POST",
            url: "/Service/ValidityInsertEmailEmployee",
            data: { email },
            success: function (response) {
                if (response != "Ok") {
                    $('.span-validationEmail').html(response);
                    return false;
                }

                $('.span-validationEmail').html('');
                return true;
            },
        });

    }


});


