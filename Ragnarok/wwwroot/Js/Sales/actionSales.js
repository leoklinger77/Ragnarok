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

$(function () {
    setTime();
    function setTime() {
        var date = new Date().getTime();
        var string = date;
        setTimeout(setTime, 1);
        $('#setTime').html(string);
    }
});

var totalUnd = 0.0;
var totaldicount = 0.0


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
        $("#selectProductStock").val('');
        $.ajax({
            type: "POST",
            url: "/Employee/Stock/FindByProduct",
            data: { productBarCode: productBarCode },
            success: function (message) {
                if (message == "Error") {

                } else {
                    var productId = 0;
                    var productName = "";
                    var salesPrice = 0.0;
                    var quantity = parseInt($('#quantity').val());         
                    var discount = 0.0;

                    $('#quantityLabel').html('Quantidade: 1');
                    $('#quantity').val('1');

                    $(message).each(function (index, item) {
                        productId = item.id;
                        productName = item.name;
                        salesPrice = item.priceSale;
                        discount = item.discount;
                        $('#selectedProductId').val(item.id);
                        $('#productLabel').html("Produto selecionado: " + item.name);
                        $('#priceLabel').html("Preço: " + item.priceSale);
                    });                   

                    totalUnd += (salesPrice * quantity);
                    totaldicount += discount;

                    cadeia = "<tr>" +
                        "<td>" + productId + "</td>" +
                        "<td>" + productName + "</td>" +
                        "<td>" + quantity + "</td>" +
                        "<td>" + salesPrice + "</td>" +
                        "<td>" + (salesPrice * quantity).toFixed(2) + "</td>" +
                        "<td><td><a class ='elimina'><button class='btn-danger' id='DeletaLinha' type='button'><span class='icon ion-android-close' ></span></button></a></td></td>" +
                        "</tr> ";
                    $("#invoiceBox tbody").append(cadeia);

                    //$('#totalTop').html('R$ ' + (total - totalDiscont));

                    $('#resultSubTotal').html('R$ ' + totalUnd.toFixed(2)); 
                    
                    $('#totaldicount').html('R$ ' + totaldicount.toFixed(2));
                    $('#resultTotalPayment').html('R$ ' + (totalUnd - totaldicount).toFixed(2));
                    $('#totalPagar').html('R$ ' + (totalUnd - totaldicount).toFixed(2)); 




                }
            }
        });
    }
}

