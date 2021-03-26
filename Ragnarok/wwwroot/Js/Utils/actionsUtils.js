
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
