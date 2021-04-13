$(document).ready(function () {


    //Seleciona Client
    $('#client').change(function () {
        var clientId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Employee/Client/FindByClient",
            data: { clientId: clientId },
            success: function (message) {
                if (message == "Error") {
                    //TODO Corrigir
                    $(".span-cep").html('Cep Inválido');
                } else {
                    $(message).each(function (index, item) {
                        $('#selectClient').val(item.id);
                        $('#companyNameSales').html(item.name);
                        $('#companyDescriptionSale').html(item.street + "," + item.numero +
                            "<br/> " + item.neighborhood + ", " + item.city + ", " + item.state +
                            "<br/>" +
                            "<div class='contact'>" +
                            "<p><span>Email:</span> " + item.email + "</p>" +
                            "<p><span>Phone:</span> " + item.phone + "</p>" +
                            "</div>"
                        );

                    });
                }
            }
        });
    });
})

function selectProductStock() {

    var productBarCode = $('#selectProductStock').val();
    var letra = productBarCode.substr(productBarCode.length - 1, productBarCode.length);
    var quantity = productBarCode.substr(0, productBarCode.length > 1 ? productBarCode.length - 1 : 1)

    if ((letra == 'X' || letra == 'x') && (quantity / quantity == 1)) {
        quantity = (quantity == 0) ? 1 : quantity;
        $('#selectProductStock').val('');
        $('#quantityLabel').html('Quantidade: ' + quantity);
        $('#quantity').val(quantity);
        return;
    }

    if (productBarCode.length == 13) {

        $.ajax({
            type: "POST",
            url: "/Employee/Stock/FindByProduct",
            data: { productBarCode: productBarCode },
            success: function (message) {
                if (message == "Error") {

                } else {
                    $(message).each(function (index, item) {
                        $('#selectedProductId').val(item.id);
                        $('#productLabel').html("Produto selecionado: " + item.name);
                        $('#priceLabel').html("Preço: " + item.priceSale);
                    });
                }
            }
        });
    }
}

