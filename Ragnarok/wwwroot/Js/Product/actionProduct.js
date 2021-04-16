$('#numberPerPage').change(function () {
    var nunber = $(this).val();
    if (nunber > 0) {
        $('#btn-get-produt').click();
    }    
});