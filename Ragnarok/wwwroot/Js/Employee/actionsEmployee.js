$(document).ready(function () {
    function validityMan() {
        var name = $('.span-nameCompleto').html();
        var cpf = $('.validationCpf').html();;
        var cel = $('.span-celValidity').html();
        var tel = $('.span-telValidity').html();
        var email = $('.span-validationEmail').html();

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

    if ($('#insertEmployee').length > 0) {
        $('#insertEmployee').bootstrapWizard({
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

                    var man = validityMan();

                    // form validation
                    parsleyForm.validate();

                    if (man != 50) {
                        return false;
                    }
                    if (!parsleyForm.isValid())
                        return false;
                }
            },
            onTabShow: function (tab, navigation, index) {
                var total = navigation.find('li').length;
                var current = index + 1;

                // if last button
                if (current >= total) {
                    $('#insertEmployee').find('.pager .next').hide();
                    $('#insertEmployee').find('.pager .last').show().removeClass('disabled');

                    // show confirmation info
                    $('#confirmName').html($('#employeeName').val());
                    $('#confirmBirthDay').html($('#employeeBirthDay').val());
                    $('#confirmCpf').html($('#employeeCpf').val());
                    $('#confirmSexo').html($('#employeeSexo').val());
                    $('#confirmEmail').html($('#employeeEmail').val());
                    $('#confirmPositionName').html($('#positionNameId').val());
                    $('#confirmAction').html($('#employeeAction').val());

                    $('#confirmPhone').html($('#employeePhone').val());
                    $('#confirmTel').html($('#employeeTelePhone').val());


                    $('#confirmZipCode').html($('#zipCode').val());
                    $('#confirmStreet').html($('#street').val());
                    $('#confirmNumber').html($('#number').val());
                    $('#confirmComplement').html($('#complement').val());
                    $('#confirmReference').html($('#reference').val());
                    $('#confirmNeighborhood').html($('#neighborhood').val());
                    $('#confirmCity').html($('#city').val());
                    $('#confirmState').html($('#state').val());

                } else {
                    $('#insertEmployee').find('.pager .next').show();
                    $('#insertEmployee').find('.pager .last').hide();
                }
                tab.removeClass('done');
            },
            onLast: function (tab, navigation, index) {

                var model = "{Name:'" + $('#employeeName').val() +
                    "',BirthDay:'" + $('#employeeBirthDay').val() +
                    "',CPF:'" + $('#employeeCpf').val() +
                    "',Email:'" + $('#employeeEmail').val() +
                    "', Sexo:'" + $('#employeeSexo').val() +
                    "', Active:'" + $('#employeeAction').val() +
                    "', PositionNameId:'" + $('#positionNameId').val() + "',";

                var phone = $('#employeePhone').cleanVal()

                model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                var numberFixo = $('#employeeTelePhone').cleanVal();
                if (numberFixo !== '') {

                    model += ",{TypeNumber:'Residencial',DDD:'" + numberFixo.substr(0, 2) + "',Number:'" + numberFixo.substr(2) + "'}";
                }
                model += "],";

                model += "Address:{ZipCode:'" + $('#zipCode').cleanVal() +
                    "',Street:'" + $('#street').val() +
                    "',Number:'" + $('#number').val() +
                    "',Complement:'" + $('#complement').val() +
                    "',Reference:'" + $('#reference').val() +
                    "',Neighborhood:'" + $('#neighborhood').val() +
                    "',CityId:'" + $('#cityId').val() + "'}}"

                var employee = eval("(" + model + ")");


                $.ajax({
                    type: "POST",
                    url: "/Employee/Employee/Insert",
                    data: { employee: employee },
                    success: function (message) {

                        if (message == "Ok") {
                            window.location.href = "/Employee/Employee/Index";
                        }

                        if (message == "Error") {
                            //TODO Implementar regra de erro
                        }
                    }
                });
            },
        });
    }

    $('.input-file-employee').click(function () {
        $('#input-file').trigger('click');
    });


    $('#input-file').change(function () {

        var image = $('#input-file')[0].files[0];

        if (typeof image == 'undefined') {
            return;
        }

        var file = new FormData();
        file.append('file', $('#input-file')[0].files[0]);
        file.append('employeeId', $('#employeeId').val());



        $.ajax({
            type: "POST",
            url: "/Employee/Employee/InsertImage",
            data: file,
            contentType: false,
            processData: false,
            error: function () {

            },
            success: function (item) {
                $('.avatar').attr('src', item.path);
                $('.avatarHome').attr('src', item.path);
            }
        });


    });
});


$('#employeeCpf').change(function () {

    var cpf = $('#employeeCpf').val();

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


