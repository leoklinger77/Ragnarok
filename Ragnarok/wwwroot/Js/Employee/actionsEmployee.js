$(document).ready(function () {
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

                    // form validation
                    parsleyForm.validate();

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
                    "', Action:'" + $('#employeeAction').val() +
                    "', PositionNameId:'" + $('#positionNameId').val() + "',";

                var phone = $('#employeePhone').val()

                model += "Contacts:[{TypeNumber:'Celular',DDD:'" + phone.substr(0, 2) + "',Number:'" + phone.substr(2) + "'}";

                var numberFixo = $('#employeeTelePhone').val();
                if (typeof numberFixo !== 'undefined') {

                    model += ",{TypeNumber:'Residencial',DDD:'" + numberFixo.substr(0, 2) + "',Number:'" + numberFixo.substr(2) + "'}";
                }
                model += "],";

                model += "Address:{ZipCode:'" + $('#zipCode').val() +
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

                        if ("Sucess") {
                            window.location.href = "/Employee/Employee/Index";
                        }
                    }
                });
            },
        });
    }



});