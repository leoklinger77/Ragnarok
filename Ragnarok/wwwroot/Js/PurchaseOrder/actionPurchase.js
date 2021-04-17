$(document).ready(function () {

    //Seleciona Supplier
    $('#supplier').change(function () {
        var supplierId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Employee/Supplier/FindBySupplier",
            data: { supplierId: supplierId },
            success: function (message) {
                if (message == "Error") {
                    $(".span-cep").html('Cep Inválido');
                } else {
                    $(message).each(function (index, item) {
                        $('#selectProvider').val(item.id);
                        $('#companyNamePurchase').html(item.name);
                        $('#companyDescriptionPurchase').html(item.street + "," + item.numero +
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

    //Select Product
    $('#selectProduct').change(function () {
        var productId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Employee/Product/FindByProduct",
            data: { productId: productId },
            success: function (message) {
                if (message == "Error") {

                } else {
                    $(message).each(function (index, item) {
                        $('#selectedProductId').val(item.id);
                        $('#selectedProduct').val(item.name + " - " + item.barCode);
                    });
                }
            }
        });
    });

    //Finalizar Compra
    $('#finishPurchase').click(function (e) {
            var supplierId = $('#selectProvider').val();

        if (supplierId == '') {
            alert("Selecione um fornecedor")
            e.preventDefault();
            return;
        }

        var envio = "{SupplierId:'" + $('#selectProvider').val() + "',Notes:'" + $('#notes').val() +"',";

        var i = 0;
        
        $('#invoicePurchase tbody tr').each(function (index) {

            if (i == 0) {
                envio += "PurchaseItemOrder:[{ProductId:'" + $(this).find('td').eq(0).text() +
                    "',PurchasePrice:'" + $(this).find('td').eq(3).text() +
                    "',SalesPrice:'" + $(this).find('td').eq(4).text() +
                    "',Quantity:'" + $(this).find('td').eq(2).text() +
                    "',Discount:'" + $(this).find('td').eq(5).text() +
                    "',ValidationDate:'" + $(this).find('td').eq(7).text() + "'}"
                
            } else {
                envio += ",{ProductId:'" + $(this).find('td').eq(0).text() +
                    "',PurchasePrice:'" + $(this).find('td').eq(3).text() +
                    "',SalesPrice:'" + $(this).find('td').eq(4).text() +
                    "',Quantity:'" + $(this).find('td').eq(2).text() +
                    "',Discount:'" + $(this).find('td').eq(5).text() +
                    "',ValidationDate:'" + $(this).find('td').eq(7).text() + "'}"
                
            }
            i = 1;
        });
        envio += "]}";


        var order = eval("(" + envio + ")")

        $.ajax({
            type: "POST",
            url: "/Employee/Purchase/Insert",
            data: { order: order },
            success: function (message) {
                if (message == "Error") {

                } else {
                    window.location.href = "/Employee/Purchase/Insert";
                }
            }
        });

    })

    
});


//Add Product Table
var total = 0.0;
var totalDiscont = 0.0;
var totalPayment = 0.0;

var deleteQuantity = 0.0;
var deletePrice = 0.0;
var deleteDiscont = 0.0;

function addProductList() {
    var productId = $('#selectedProductId').val();
    var productName = $('#selectedProduct').val();
    var salesPrice = parseFloat($('#purchasePrice').val());
    var purchasePrice = parseFloat($('#salesPrice').val());
    var quantity = parseInt($('#quantity').val());
    var discont = parseFloat($('#discont').val());
    var validition = $('#validition').val();

    total += (salesPrice * quantity);
    totalDiscont += discont;

    var discontPrice = (salesPrice * quantity) - discont;
    cadeia = "<tr>" +
        "<td>" + productId + "</td>" +
        "<td>" + productName + "</td>" +
        "<td>" + quantity + "</td>" +
        "<td>" + salesPrice + "</td>" +
        "<td>" + purchasePrice + "</td>" +
        "<td>" + discont + "</td>" +
        "<td>" + discontPrice + "</td>" +
        "<td>" + validition + "</td>" +
        "<td><td><a class ='elimina'><button class='btn btn-danger' id='DeletaLinha' type='button'><span class='icon ion-android-close' ></span></button></a></td></td>" +
        "</tr> ";
    $("#invoicePurchase tbody").append(cadeia);



    $('#totalTop').html('R$ ' + (total - totalDiscont));

    $('#resultSubTotal').html('R$ ' + total);
    $('#resultDiscont').html('R$ ' + totalDiscont);
    $('#resultTotalPayment').html('R$ ' + (total - totalDiscont));
    deletarlinha();
    cleanImput();
};


function deletarlinha() {
    $("a.elimina").click(function () {
        deleteQuantity = $(this).parents("tr").find("td").eq(2).html();
        deletePrice = $(this).parents("tr").find("td").eq(3).html();
        deleteDiscont = $(this).parents("tr").find("td").eq(5).html();

        $(this).parents("tr").fadeOut("normal", function () {
            $(this).remove();
            restar();
        });
    });
}

function restar() {
    total -= (deletePrice * deleteQuantity);
    totalDiscont -= deleteDiscont;

    $('#totalTop').html('R$ ' + (total - totalDiscont));
    $('#resultSubTotal').html('R$ ' + total);
    $('#resultDiscont').html('R$ ' + totalDiscont);
    $('#resultTotalPayment').html('R$ ' + (total - totalDiscont));
}

function cleanImput() {

    $('#selectedProductId').val('');
    $('#selectedProduct').val('');
    $('#purchasePrice').val('');
    $('#salesPrice').val('');
    $('#quantity').val('1');
    $('#discont').val('0');
    $('#validition').val('');
    $('#selectProduct').val('Selecione');
}

