$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');

    $('.ddd').mask('(00)');
    $('.cel').mask('0.0000-0000');
    $('.tel').mask('0000-0000');

    
    $('.cep').mask('00000-000', {placeholder:"00000-000"});
    $('.tel_with_ddd').mask('(00)0000-0000', {placeholder:"(__)____-____"});
    $('.phone_with_ddd').mask('(00)0.0000-0000', {placeholder:"(__)_.____-____"});
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', {placeholder: "000.000.000-00" });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money2').mask("#.##0,00", { reverse: true });
    
    $('.percent').mask('##0,00%', { reverse: true });
    
    
});