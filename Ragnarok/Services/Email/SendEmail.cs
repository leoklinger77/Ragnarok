using Microsoft.Extensions.Configuration;
using Ragnarok.Models;
using System.Net.Mail;

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

        public void SendPasswordEmployee(Employee employee)
        {
            string corpMsg = string.Format("<h2>Contato Loja Virtual</h2>" +
                "<b>Sua senha é : </b><br/>" +
                "<h3>{0}</h3>  <br/>" +
                "<p>E-mail enviado automaticamente do site Loja Virtual</p>", employee.Password);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(employee.Email);
            message.Subject = "Contato - Loja Virtual";
            message.Body = corpMsg;
            message.IsBodyHtml = true; //True caso vc queira que o body seja enviado html

            _smtp.Send(message);
        }
    }
}
