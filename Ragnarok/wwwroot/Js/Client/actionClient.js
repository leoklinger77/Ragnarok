$(document).ready(function () {
    function validityManPhysical() {
        var name = $('.span-nameCompleto').html();
        var cpf = $('.validationCpf').html();;
        var cel = $('#span-clientPhyCel').html();
        var tel = $('#span-clientPhyTel').html();
        var email = $('#validationClientPhyEmail').html();

        var result = 0;
        if (name == '') {
            result += 10;
        }
        if (cpf == '') {
            result += 10;
        }
        if (cel == '') {
            result += 10;
        }
        if (tel == '') {
            result += 10;
        }
        if (email == '') {
            result += 10;
        }

        return result;
    }

    function validityManJuridical() {
        var companyName = $('.span-fullCpmpanyName').html();
        var cnpj = $('.validationCnpj').html();;
        var email = $('#validationClientJurEmail').html();
        var cel = $('#span-clientJurCel').html();
        var tel = $('#span-clientJurTel').html();
        

        var result = 0;
        if (companyName == '') {
            result += 10;
        }
        if (cnpj == '') {
            result += 10;
        }
        if (cel == '') {
            result += 10;
        }
        if (tel == '') {
            result += 10;
        }
        if (email == '') {
            result += 10;
        }

        return result;
    }

    function validationAddress() {
        var zipcode = $('.span-cep').html();

        var result = 0;
        if (zipcode == '') {
            result += 10;
        }
        return result;
    }
    if ($('#insertClient').length > 0) {
        $('#insertClient').bootstrapWizard({
            'tabClass': 'nav nav-pills',
            onTabClick: function () {
                return false;
            },
            onNext: function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;
                var parsleyForm = $('#form-circle-wizard' + index).parsley();

                // if not last tab
                if (current <= total) {
                    tab.addClass('done');


                    var mainPhysical = validityManPhysical();
                    var mainJuridical = validityManJuridical();
                    var address = validationAddress();
                    // form validation
                    parsleyForm.validate();


                    if (!parsleyForm.isValid())
                        return false;

                    if (mainPhysical != 50) {
                        return false;
                    }
                    if (mainJuridical != 50) {
                        return false;
                    }
                    if (address != 10) {
                        return false;
                    }

                }
            },
            onTabShow: function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;

                // if last button
                if (current >= total) {
                    $('#insertClient').find('.pager .next').hide();
                    $('#insertClient').find('.pager .last').show().removeClass('disabled');

                    if (type == "Physical") {
                        $('.confirmeJuridical').hide();
                        $('.confirmePhysical').show();

                        $('#confirmName').html($('#clientName').val());
                        $('#confirmBirthDay').html($('#clientBirthDay').val());
                        $('#confirmCpf').html($('#clientCpf').val());
                        $('#confirmSexo').html($('#clientSexo').val());
                        $('#confirmEmail').html($('#clientEmail').val());
                        $('#confirmAction').html($('#clientAction').val());

                        $('#confirmPhone').html($('#clienPhysicalPhone').val());
                        $('#confirmTel').html($('#clientTelePhone').val());

                    } else {
                        $('.confirmeJuridical').show();
                        $('.confirmePhysical').hide();

                        $('#confirmCompanyName').html($('#clientCompanyName').val());
                        $('#confirmeFantansy').html($('#clientFantasyName').val());
                        $('#confirmOpeningDate').html($('#clientOpeningDate').val());
                        $('#confirmeCnpj').html($('#clientCnpj').val());

                        $('#confirmJuridicalEmail').html($('#ClientJuridicalEmail').val());
                        $('#confirmJuridicalAction').html($('#clientJuridicalActive').val());

                        $('#confirmJuridicalPhone').html($('#clientJurificalPhone').val());
                        $('#confirmJuridicalTel').html($('#clientComercial').val());
                    }


                    $('#confirmZipCode').html($('#zipCode').val());
                    $('#confirmStreet').html($('#street').val());
                    $('#confirmNumber').html($('#number').val());
                    $('#confirmComplement').html($('#complement').val());
                    $('#confirmReference').html($('#reference').val());
                    $('#confirmNeighborhood').html($('#neighborhood').val());
                    $('#confirmCity').html($('#city').val());
                    $('#confirmState').html($('#state').val());

                } else {
                    $('#insertClient').find('.pager .next').show();
                    $('#insertClient').find('.pager .last').hide();
                }
                tab.removeClass('done');
            },
            onLast: function (tab, navigation, index) {

                var model = '{';

                if (type == "Physical") {
                    model += "Email:'" + $('#clientEmail').val() +
                        "',Active:'" + $('#clientAction').val() +
                        "',CPF:'" + $('#clientCpf').val() +
                        "',FullName:'" + $('#clientName').val() +
                        "', BirthDay:'" + $('#clientBirthDay').val() +
                        "', Sexo:'" + $('#clientSexo').val() + "',";
                    var phone = $('#clienPhysicalPhone').cleanVal()
                    model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                    var numberFixo = $('#clientTelePhone').cleanVal();
                    if (numberFixo !== '') {

                        model += ",{TypeNumber:'Residencial',DDD:'" + numberFixo.substr(0, 2) + "',Number:'" + numberFixo.substr(2) + "'}";
                    }
                } else {
                    model += "Email:'" + $('#ClientJuridicalEmail').val() +
                        "',Active:'" + $('#clientJuridicalActive').val() +
                        "',CNPJ:'" + $('#clientCnpj').val() +
                        "',CompanyName:'" + $('#clientCompanyName').val() +
                        "',FantasyName:'" + $('#clientFantasyName').val() +
                        "', OpeningDate:'" + $('#clientOpeningDate').val() + "',";

                    var phone = $('#clientJurificalPhone').cleanVal();
                    model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                    var numberFixo = $('#clientComercial').cleanVal();
                    if (numberFixo !== '') {

                        model += ",{TypeNumber:'Residencial',DDD:'" + numberFixo.substr(0, 2) + "',Number:'" + numberFixo.substr(2) + "'}";
                    }
                }

                
                model += "],";

                model += "Address:{ZipCode:'" + $('#zipCode').cleanVal() +
                    "',Street:'" + $('#street').val() +
                    "',Number:'" + $('#number').val() +
                    "',Complement:'" + $('#complement').val() +
                    "',Reference:'" + $('#reference').val() +
                    "',Neighborhood:'" + $('#neighborhood').val() +
                    "',CityId:'" + $('#cityId').val() + "'}}"

                var clientJuridical;
                var clientPhysical;
                if (type == "Physical") {
                    clientPhysical = eval("(" + model + ")");
                } else {
                    clientJuridical = eval("(" + model + ")");
                }

                $.ajax({
                    type: "POST",
                    url: "/Employee/Client/Insert",
                    data: { clientJuridical: clientJuridical, clientPhysical: clientPhysical },
                    success: function (message) {

                        if (message == "Ok") {
                            window.location.href = "/Employee/Client/Index";
                        }

                        if (message == "Error") {
                            //TODO Implementar regra de erro
                        }
                    }
                });
            },
        });
    }
});
var type = '';

$('#typeClientPhysical').click(function () {
    type = $('#typeClientPhysical').val();

    if (type == "Physical") {
        $('#mainJuridical').hide();
        $('#mainPhysical').show();

        document.getElementById("clientCompanyName").removeAttribute("required");
        document.getElementById("clientFantasyName").removeAttribute("required");
        document.getElementById("clientCnpj").removeAttribute("required");
        document.getElementById("clientOpeningDate").removeAttribute("required");
        document.getElementById("ClientJuridicalEmail").removeAttribute("required");
        document.getElementById("clientJuridicalActive").removeAttribute("required");
        document.getElementById("clientJurificalPhone").removeAttribute("required");

        document.getElementById("clientName").required = true;
        document.getElementById("clientBirthDay").required = true;
        document.getElementById("clientCpf").required = true;
        document.getElementById("clientSexo").required = true;
        document.getElementById("clientEmail").required = true;
        document.getElementById("clientAction").required = true;
        document.getElementById("clienPhysicalPhone").required = true;

    }
})

$('#typeClientJuridical').click(function () {
    type = $('#typeClientJuridical').val();

    if (type == "Juridical") {
        $('#mainJuridical').show();
        $('#mainPhysical').hide();


        document.getElementById("clientName").removeAttribute("required");
        document.getElementById("clientBirthDay").removeAttribute("required");
        document.getElementById("clientCpf").removeAttribute("required");
        document.getElementById("clientSexo").removeAttribute("required");
        document.getElementById("clientEmail").removeAttribute("required");
        document.getElementById("clientAction").removeAttribute("required");
        document.getElementById("clienPhysicalPhone").removeAttribute("required");


        document.getElementById("clientCompanyName").required = true;
        document.getElementById("clientFantasyName").required = true;
        document.getElementById("clientCnpj").required = true;
        document.getElementById("clientOpeningDate").required = true;
        document.getElementById("ClientJuridicalEmail").required = true;
        document.getElementById("clientJuridicalActive").required = true;
        document.getElementById("clientJurificalPhone").required = true;
    }
})

$('#clientCpf').change(function () {

    var cpf = $('#clientCpf').val();

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
        url: "/Service/ValidityInsertCPFClient",
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

$('#clientCnpj').change(function () {

    var cnpj = $('#clientCnpj').val();
    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        $('.validationCnpj').html("Inválido");
        return false;
    }

    if (cnpj.length != 14) {
        $('.validationCnpj').html("Inválido");
        return false;
    }

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999") {
        $('.validationCnpj').html("Inválido");
        return false;
    }

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0)) {
        $('.validationCnpj').html("Inválido");
        return false;
    }

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1)) {
        $('.validationCnpj').html("Inválido");
        return false;
    }

    if ($('.validationCnpj').html() != '') {
        $('.validationCnpj').html('');
    }

    $.ajax({
        type: "POST",
        url: "/Service/ValidityInsertCNPJClient",
        data: { cnpj },
        success: function (message) {
            if (response != "Ok") {
                $('.validationCnpj').html(response);
                return false;
            }

            $('.validationCnpj').html('');
            return true;
        },
    })

});

$('.email').change(function () {
    var email = $(this).val();


    if (email.includes("@")) {


        $.ajax({
            type: "POST",
            url: "/Service/ValidityInsertEmailClient",
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
