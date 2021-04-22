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
                            "<p><span>Email:</span>" + item.email + "</p>" +
                            "<p><span>Phone:</span>" + item.phone + "</p>" +
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

var totalFinish = 0.0;
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
                    var salesOfdicount = 0.0;

                    $('#quantityLabel').html('Quantidade: 1');
                    $('#quantity').val('1');

                    $(message).each(function (index, item) {
                        productId = item.id;
                        productName = item.name;
                        salesPrice = item.priceSale;
                        discount = item.discount;

                        salesOfdicount = salesPrice - discount;

                        $('#selectedProductId').val(item.id);
                        $('#productLabel').html("Produto selecionado: " + item.name);
                        $('#priceLabel').html("Preço: " + salesOfdicount.toFixed(2));
                    });

                    totalFinish += (salesPrice * quantity);
                    totaldicount += (discount * quantity);

                    salesOfdicount = salesOfdicount * quantity;

                    cadeia = "<tr>" +
                        "<td>" + productId + "</td>" +
                        "<td>" + productName + "</td>" +
                        "<td>" + quantity + "</td>" +
                        "<td>" + salesPrice.toFixed(2) + "</td>" +
                        "<td>" + discount.toFixed(2) + "</td>" +
                        "<td>" + salesOfdicount.toFixed(2) + "</td>" +
                        "<td><td><a class ='elimina'><button class='btn-danger' id='DeletaLinha' type='button'><span class='icon ion-android-close' ></span></button></a></td></td>" +
                        "</tr> ";
                    $("#invoiceBox tbody").append(cadeia);

                    //$('#totalTop').html('R$ ' + (total - totalDiscont));

                    $('#resultSubTotal').html('R$ ' + totalFinish.toFixed(2));

                    $('#totaldicount').html('R$ ' + totaldicount.toFixed(2));
                    $('#resultTotalPayment').html('R$ ' + (totalFinish - totaldicount).toFixed(2));
                    $('#totalPagar').html('R$ ' + (totalFinish - totaldicount).toFixed(2));
                }
            }
        });
    }
}

$('#selectPayment').change(function () {

    var type = $(this).val();
    switch (type) {
        case 'Money':
            $('#fiado').hide();
            $('#credit').hide();
            $('#money').show();
            $('#divStatusPayment').show();
            break;

        case 'Credit':
            $('#fiado').hide();
            $('#money').hide();
            $('#credit').show();
            $('#divStatusPayment').show();
            break;

        case 'Fiado':
            $('#credit').hide();
            $('#money').hide();
            $('#fiado').show();
            $('#divStatusPayment').hide();
            break;

        default:
            $('#credit').hide();
            $('#fiado').hide();
            $('#money').hide();


    }

});

function GetMoney() {
    var money = $('#moneyRecebido').val();
    var result = (money - (totalFinish - totaldicount));
    $('#troco').val(result.toFixed(2));
}

$('#finishSales').click(function () {

    if (true) {

    }


    var envioPayment;

    var debit;
    var credit;
    var ticket;
    var money;
    var payLater;

    var select = $('#selectPayment').val();
    switch (select) {
        case 'Debit':
            envioPayment = "{StatusPayment: '" + $('#typePaymentStatus').val() + "', Amount: '" + totalFinish + "'}";
            debit = eval("(" + envioPayment + ")");
            break;

        case 'Credit':
            var invoice = $('#parcels').val();

            if (typeof invoice == 'undefined') {
                return;
            }
            envioPayment = "{StatusPayment: '" + $('#typePaymentStatus').val() + "', Amount: '" + totalFinish + "',Invoice:'" + invoice + "'}";
            credit = eval("(" + envioPayment + ")");
            break;

        case 'Fiado':
            envioPayment = "{StatusPayment: 'Pending', Amount: '" + totalFinish + "',SupposedPaymentDate:'" + $('#supposedPaymentDate').val() + "'}";
            payLater = eval("(" + envioPayment + ")");

            break;

        case 'Money':
            envioPayment = "{StatusPayment: '" + $('#typePaymentStatus').val() + "', Amount: '" + totalFinish + "',GetMoney:'" + $('#moneyRecebido').val() + "',MoneyBack:'" + $('#troco').val() + "'}";
            money = eval("(" + envioPayment + ")");
            break;
        default:
            return;
    }

    var envio = "{Notes:'" + $('#noteSales').val() + "', ClientId:'" + $('#selectClient').val() + "',";

    var i = 0;
    $('#invoiceBox tbody tr').each(function (index) {

        if (i == 0) {
            envio += "SalesItem:[{Quantity:'" + $(this).find('td').eq(2).text() +
                "',Price:'" + $(this).find('td').eq(3).text() +
                "',StockId:'" + $(this).find('td').eq(0).text() +
                "',Discount:'" + $(this).find('td').eq(4).text() + "'}";

        } else {
            envio += ",{Quantity:'" + $(this).find('td').eq(2).text() +
                "',Price:'" + $(this).find('td').eq(3).text() +
                "',StockId:'" + $(this).find('td').eq(0).text() +
                "',Discount:'" + $(this).find('td').eq(4).text() + "'}";
        }
        i = 1
    });
    envio += "]}";


    var salesOrder = eval("(" + envio + ")");


    $.ajax({
        type: "POST",
        url: "/Employee/Sales/InsertSales",
        data: { salesOrder, debit, credit, payLater, money },
        success: function (message) {
            window.location.href = "/Employee/Sales/Box";
        }
    });

});

$('#numberPerPage').change(function () {
    var nunber = $(this).val();
    if (nunber > 0) {
        $('#btn-get-salesReport').click();
    }
});

$(document).ready(function () {

    if ($('body').hasClass('fixed-top-active dashboard')) {
				
		$('#reportrange').daterangepicker({
			startDate: moment().subtract('days', 29),
			endDate: moment(),
			minDate: '01/01/2012',
			maxDate: '12/31/2032',
			dateLimit: { days: 730 },
			showDropdowns: true,
			showWeekNumbers: true,
			timePicker: false,
			timePickerIncrement: 1,
			timePicker12Hour: true,
			ranges: {
				'Hojte': [moment(), moment()],
				'Ontem': [moment().subtract('days', 1), moment().subtract('days', 1)],
				'Últimos 7 Dias': [moment().subtract('days', 6), moment()],
				'Últimos 30 Dias': [moment().subtract('days', 29), moment()],
				'Este Mês': [moment().startOf('month'), moment().endOf('month')],
				'Últimos Mês': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
			},
			opens: 'left',
			applyClass: 'btn btn-small btn-primary',
			cancelClass: 'btn-small',
            format: 'DD/MM/YYYY',
			separator: ' to ',
			locale: {
				applyLabel: 'Ok',
				fromLabel: 'De',
				toLabel: 'Para',
				customRangeLabel: 'Faixa Personalizada',
				daysOfWeek: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
				monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezenbro'],
				firstDay: 1
			}
		},

			function (start, end) {
                console.log("Chamada de retorno foi realizada!");
                $('#reportrange span').html(start.format('D MMMM, YYYY') + ' - ' + end.format('D MMMM, YYYY'));

                $('#start').val(start.format('D MMMM, YYYY'));
                $('#end').val(end.format('D MMMM, YYYY'));
                $('#btn-get-salesReport').click();


			}
		);

		// set the initial state of the picker label
        $('#reportrange span').html(moment().subtract('days', 29).format('D MMMM, YYYY') + ' - ' + moment().format('D MMMM, YYYY'));

	}

});

$("#btnExportSales").click(function (e) {
    window.open('data:application/vnd.ms-excel,' + $('.exportSales').html());
    e.preventDefault();
});