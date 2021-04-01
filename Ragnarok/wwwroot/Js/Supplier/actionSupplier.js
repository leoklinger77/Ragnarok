$(document).ready(function () {
    function validityManPhysical() {
        var name = $('.span-nameCompleto').html();
        var cpf = $('.validationCpf').html();;
        var cel = $('#span-supplierPhyCel').html();
        var tel = $('#span-supplierPhyTel').html();
        var email = $('#supplierEmailPhysycal').html();

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
        var companyName = $('.span-fullCompanyName').html();
        var cnpj = $('.validationCnpj').html();;
        var email = $('#supplierEmailjuridical').html();
        var cel = $('#span-supplierJurCel').html();
        var tel = $('#span-supplierJurTel').html();


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

    if ($('#insertSupplier').length > 0) {
        $('#insertSupplier').bootstrapWizard({
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
                    //if (address != 10) {
                    //    return false;
                    //}

                }
            },
            onTabShow: function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;

                // if last button
                if (current >= total) {
                    $('#insertSupplier').find('.pager .next').hide();
                    $('#insertSupplier').find('.pager .last').show().removeClass('disabled');

                    if (type == "Physical") {
                        $('.confirmeJuridical').hide();
                        $('.confirmePhysical').show();

                        $('#confirmName').html($('#supplierFullName').val());
                        $('#confirmBirthDay').html($('#supplierBirthDay').val());
                        $('#confirmCpf').html($('#supplierCpf').val());
                        $('#confirmSexo').html($('#supplierSexo').val());
                        $('#confirmEmail').html($('#supplierEmailPhysycal').val());
                        $('#confirmAction').html($('#supplierActivePhysical').val());

                        $('#confirmPhone').html($('#supplierCelPhysical').val());
                        $('#confirmTel').html($('#supplierTelPhysical').val());

                    } else {
                        $('.confirmeJuridical').show();
                        $('.confirmePhysical').hide();

                        $('#confirmCompanyName').html($('#supplierCompanyName').val());
                        $('#confirmeFantansy').html($('#supplierFantasyName').val());
                        $('#confirmOpeningDate').html($('#supplierOpeningDate').val());
                        $('#confirmeCnpj').html($('#supplierCnpj').val());

                        $('#confirmJuridicalEmail').html($('#supplierEmailjuridical').val());
                        $('#confirmJuridicalAction').html($('#supplierActionJuridical').val());

                        $('#confirmJuridicalPhone').html($('#supplierCelJuridical').val());
                        $('#confirmJuridicalTel').html($('#supplierTelJuridical').val());
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
                    $('#insertSupplier').find('.pager .next').show();
                    $('#insertSupplier').find('.pager .last').hide();
                }
                tab.removeClass('done');
            },
            onLast: function (tab, navigation, index) {

                var model = '{';

                if (type == "Physical") {
                    model += "Email:'" + $('#supplierEmailPhysycal').val() +
                        "',Active:'" + $('#supplierActivePhysical').val() +
                        "',CPF:'" + $('#supplierCpf').val() +
                        "',FullName:'" + $('#supplierFullName').val() +
                        "', BirthDay:'" + $('#supplierBirthDay').val() +
                        "', Sexo:'" + $('#supplierSexo').val() + "',";
                    var phone = $('#supplierCelPhysical').cleanVal()
                    model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                    var numberFixo = $('#supplierTelPhysical').cleanVal();
                    if (numberFixo !== '') {

                        model += ",{TypeNumber:'Residencial',DDD:'" + numberFixo.substr(0, 2) + "',Number:'" + numberFixo.substr(2) + "'}";
                    }
                } else {
                    model += "Email:'" + $('#supplierEmailjuridical').val() +
                        "',Active:'" + $('#supplierActionJuridical').val() +
                        "',CNPJ:'" + $('#supplierCnpj').val() +
                        "',CompanyName:'" + $('#supplierCompanyName').val() +
                        "',FantasyName:'" + $('#supplierFantasyName').val() +
                        "', OpeningDate:'" + $('#supplierOpeningDate').val() + "',";

                    var phone = $('#supplierCelJuridical').cleanVal();
                    model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                    var numberFixo = $('#supplierTelJuridical').cleanVal();
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

                var supplierJuridical;
                var supplierPhysical;
                if (type == "Physical") {
                    supplierPhysical = eval("(" + model + ")");
                } else {
                    supplierJuridical = eval("(" + model + ")");
                }

                $.ajax({
                    type: "POST",
                    url: "/Employee/Supplier/Insert",
                    data: { supplierJuridical: supplierJuridical, supplierPhysical: supplierPhysical },
                    success: function (message) {

                        if (message == "Ok") {
                            window.location.href = "/Employee/Supplier/Index";
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

$('#typeSupplierPhysical').click(function () {
    type = $('#typeSupplierPhysical').val();

    if (type == "Physical") {
        $('#mainJuridical').hide();
        $('#mainPhysical').show();

        document.getElementById("supplierCompanyName").removeAttribute("required");
        document.getElementById("supplierFantasyName").removeAttribute("required");
        document.getElementById("supplierCnpj").removeAttribute("required");
        document.getElementById("supplierOpeningDate").removeAttribute("required");
        document.getElementById("supplierEmailjuridical").removeAttribute("required");
        document.getElementById("supplierActionJuridical").removeAttribute("required");
        document.getElementById("supplierCelJuridical").removeAttribute("required");

        document.getElementById("supplierFullName").required = true;
        document.getElementById("supplierBirthDay").required = true;
        document.getElementById("supplierCpf").required = true;
        document.getElementById("supplierSexo").required = true;
        document.getElementById("supplierEmailPhysycal").required = true;
        document.getElementById("supplierActivePhysical").required = true;
        document.getElementById("supplierCelPhysical").required = true;

    }
})

$('#typeSupplierJuridical').click(function () {
    type = $('#typeSupplierJuridical').val();

    if (type == "Juridical") {
        $('#mainJuridical').show();
        $('#mainPhysical').hide();


        document.getElementById("supplierFullName").removeAttribute("required");
        document.getElementById("supplierBirthDay").removeAttribute("required");
        document.getElementById("supplierCpf").removeAttribute("required");
        document.getElementById("supplierSexo").removeAttribute("required");
        document.getElementById("supplierEmailPhysycal").removeAttribute("required");
        document.getElementById("supplierActivePhysical").removeAttribute("required");
        document.getElementById("supplierCelPhysical").removeAttribute("required");


        document.getElementById("supplierCompanyName").required = true;
        document.getElementById("supplierFantasyName").required = true;
        document.getElementById("supplierCnpj").required = true;
        document.getElementById("supplierOpeningDate").required = true;
        document.getElementById("supplierEmailjuridical").required = true;
        document.getElementById("supplierActionJuridical").required = true;
        document.getElementById("supplierCelJuridical").required = true;
    }
})

$('#supplierCpf').change(function () {

    var cpf = $(this).val();

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
        url: "/Service/ValidityInsertCPFSupplier",
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

$('#supplierCnpj').change(function () {

        var cnpj = $(this).val();
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
        url: "/Service/ValidityInsertCNPJSupplier",
        data: { cnpj },
        success: function (message) {
            if (message != "Ok") {
                $('.validationCnpj').html(message);
                return false;
            }

            $('.validationCnpj').html('');
            return true;
        },
    })

});

$('.emailSupplier').change(function () {
    var email = $(this).val();


    if (email.includes("@")) {


        $.ajax({
            type: "POST",
            url: "/Service/ValidityInsertEmailSupplier",
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