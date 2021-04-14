using Microsoft.Extensions.Configuration;
using Ragnarok.Models;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Ragnarok.Services.Email
{
    public class SendEmail
    {
        private readonly SmtpClient _smtp;
        private readonly IConfiguration _configuration;

        public SendEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public async Task SendPasswordEmployeeAsync(Employee employee)
        {
            string corpMsg = string.Format(
"<div style='width:100%!important;margin:0;padding:0;background-color:#f4f4f4'>" +
    "<span style='color:transparent;display:none;height:0;max-height:0;max-width:0;opacity:0;overflow:hidden;width:0'></span>" +
    "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation' style='table-layout:fixed'>" +
      "<tbody>" +
        "<tr>" +
          "<td align='center' valign='top'>" +
            "<table class='m_2220419024356087086pc-email-container' width='100%' align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='margin:0 auto;max-width:620px'>" +
              "<tbody>" +
                "<tr>" +
                  "<td align='left' valign='top' style='padding:0 10px'>" +
                    "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                      "<tbody>" +
                        "<tr>" +
                          "<td height='20' style='font-size:1px;line-height:1px'>&nbsp;</td>" +
                        "</tr>" +
                      "</tbody>" +
                    "</table>" +
                    "<table width='100%' border='0' cellspacing='0' cellpadding='0' role='presentation'>" +
                     "<tbody>" +
                        "<tr>" +
                          "<td valign='top'>" +
                            "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                              "<tbody>" +
                                "<tr>" +
                                  "<td class='m_2220419024356087086pc-sm-p-20 m_2220419024356087086pc-xs-p-10' bgcolor='#1B1B1B' valign='top' style='padding:25px 30px;background-color:#1b1b1b'>" +
                                    "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                                      "<tbody>" +
                                        "<tr>" +
                                          "<td align='center' valign='top' style='padding:10px'>" +
                                            "<img src='https://localhost:44359/assets/img/queenadmin-logo.png' width='130' height='' alt='' style='height:auto;max-width:100%;border:0;line-height:100%;outline:0;color:#ffffff;font-size:14px' class='CToWUd'>" +
                                          "</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                    "</table>" +
                                  "</td>" +
                                "</tr>" +
                              "</tbody>" +
                            "</table>" +
                            "<table border='0' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
                              "<tbody>" +
                                "<tr>" +
                                  "<td class='m_2220419024356087086pc-sm-p-30-20 m_2220419024356087086pc-xs-p-25-10' style='padding:40px 30px;background:#ffffff' bgcolor='#ffffff' valign='top'>" +
                                    "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                                      "<tbody>" +
                                       "<tr>" +
                                          "<td class='m_2220419024356087086pc-sm-fs-30' style='font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:36px;font-weight:800;line-height:46px;letter-spacing:-0.6px;color:#151515;padding:0 10px' valign='top'>Seu Login: {0}</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                          "<td class='m_2220419024356087086pc-sm-fs-30' style='font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:36px;font-weight:800;line-height:46px;letter-spacing:-0.6px;color:#151515;padding:0 10px' valign='top'>Sua Senha: {1}</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                          "<td height='15' style='line-height:1px;font-size:1px'>&nbsp;</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                      "<tbody>" +
                                        "<tr>" +
                                          "<td class='m_2220419024356087086pc-sm-fs-18 m_2220419024356087086pc-xs-fs-16' style='font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:18px;font-weight:300;line-height:28px;letter-spacing:-0.2px;color:#9b9b9b;padding:0 10px' valign='top'> Clique no botão abaixo para acessar sua conta </td>" +
                                        "</tr>" +
                                        "<tr>" +
                                          "<td height='25' style='line-height:1px;font-size:1px'>&nbsp;</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                      "<tbody>" +
                                        "<tr>" +
                                          "<td style='padding:5px 10px' valign='top'>" +
                                            "<table border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                                              "<tbody>" +
                                                "<tr>" +
                                                  "<td style='text-align:center;border-radius:8px;padding:14px 19px;background-color:#01a0c6' bgcolor='#01a0c6' valign='top' align='center'>" +
                                                    "<a href='' style='text-decoration:none;line-height:24px;letter-spacing:-0.2px;font-family:'Fira Sans',Helvetica,Arial,sans-serif;font-size:16px;font-weight:500;color:#ffffff;word-break:break-word;display:block' target='_blank' data-saferedirecturl=''>Acessar sua Conta</a>" +
                                                  "</td>" +
                                                "</tr>" +
                                              "</tbody>" +
                                            "</table>" +
                                          "</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                      "<tbody>" +
                                        "<tr>" +
                                          "<td height='25' style='line-height:1px;font-size:1px'>&nbsp;</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                          "<td style='padding:0 10px' valign='top'>" +
                                            "<table border='0' cellpadding='0' cellspacing='0' role='presentation' width='100%'>" +
                                              "<tbody>" +
                                              "</tbody>" +
                                            "</table>" +
                                          "</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                    "</table>" +
                                  "</td>" +
                                "</tr>" +
                              "</tbody>" +
                            "</table>" +
                            "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                              "<tbody>" +
                                "<tr>" +
                                  "<td class='m_2220419024356087086pc-sm-p-21-10-14 m_2220419024356087086pc-xs-p-5-0' style='padding:21px 20px 14px 20px;background-color:#1b1b1b' valign='top' bgcolor='#1B1B1B' role='presentation'>" +
                                    "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                                      "<tbody>" +
                                        "<tr>" +
                                          "<td style='font-size:0' valign='top'>" +
                                            "<div class='m_2220419024356087086pc-sm-mw-100pc' style='display:inline-block;width:100%;max-width:280px;vertical-align:top'>" +
                                              "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                                                "<tbody>" +
                                                  "<tr>" +
                                                    "<td style='padding:20px' valign='top'>" +
                                                      "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                                                        "<tbody>" +
                                                          "<tr>" +
                                                            "<td style='font-family:Fira Sans,Helvetica,Arial,sans-serif;font-size:14px;line-height:20px;letter-spacing:-0.2px;color:#d8d8d8' valign='top'> Este é um e-mail gerado automaticamente. Por favor não responda esse email. <br>&nbsp;</td>" +
                                                          "</tr>" +
                                                          "<tr>" +
                                                            "<td class='m_2220419024356087086pc-sm-h-20' height='56' style='line-height:1px;font-size:1px'>&nbsp;</td>" +
                                                          "</tr>" +
                                                        "</tbody>" +
                                                        "<tbody>" +
                                                        "</tbody>" +
                                                      "</table>" +
                                                    "</td>" +
                                                  "</tr>" +
                                               "</tbody>" +
                                              "</table>" +
                                            "</div>" +
                                            "<div class='m_2220419024356087086pc-sm-mw-100pc' style='display:inline-block;width:100%;max-width:280px;vertical-align:top'>" +
                                              "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                                                "<tbody>" +
                                                  "<tr>" +
                                                    "<td style='padding:20px' valign='top'>" +
                                                      "<table border='0' cellpadding='0' cellspacing='0' width='100%' role='presentation'>" +
                                                        "<tbody>" +
                                                          "<tr>" +
                                                            "<td style='font-family:Fira Sans,Helvetica,Arial,sans-serif;font-size:18px;font-weight:500;line-height:24px;letter-spacing:-0.2px;color:#ffffff' valign='top'> Contato </td>" +
                                                          "</tr>" +
                                                          "<tr>" +
                                                            "<td height='11' style='line-height:1px;font-size:1px'>&nbsp;</td>" +
                                                          "</tr>" +
                                                        "</tbody>" +
                                                        "<tbody>" +
                                                          "<tr>" +
                                                            "<td style='font-family:Fira Sans,Helvetica,Arial,sans-serif;font-size:14px;font-weight:500;line-height:24px' valign='top'>" +
                                                              "<a href='mailto:support@breakoutclips.com' style='text-decoration:none;color:#1595e7' target='_blank'> Leandro.klingeroliveira@gmail.com </a>" +
                                                            "</td>" +
                                                          "</tr>" +
                                                        "</tbody>" +
                                                      "</table>" +
                                                    "</td>" +
                                                  "</tr>" +
                                                "</tbody>" +
                                              "</table>" +
                                            "</div>" +
                                          "</td>" +
                                        "</tr>" +
                                      "</tbody>" +
                                    "</table>" +
                                  "</td>" +
                                "</tr>" +
                              "</tbody>" + 
                            "</table>" +
                          "</td>" +
                        "</tr>" +
                      "</tbody>" +
                    "</table>" +
                    "<table width='100%' border='0' cellpadding='0' cellspacing='0' role='presentation'>" +
                      "<tbody>" +
                        "<tr>" +
                          "<td height='20' style='font-size:1px;line-height:1px'>&nbsp;</td>" +
                        "</tr>" +
                      "</tbody>" +
                    "</table>" +
                  "</td>" +
                "</tr>" +
              "</tbody>" +
            "</table>" +
          "</td>" +
        "</tr>" +
      "</tbody>" +
    "</table>" +
"</div>", employee.Login, employee.Password);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(employee.Email);
            message.Subject = "Contato - Loja Virtual";
            message.Body = corpMsg;
            message.IsBodyHtml = true; //True caso vc queira que o body seja enviado html

            await _smtp.SendMailAsync(message);
        }
    }
}
