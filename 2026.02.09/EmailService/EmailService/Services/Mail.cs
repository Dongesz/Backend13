using EmailService.Models.DTOs;
using EmailService.Services.ISendMail;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;


namespace EmailService.Services
{
    public class Mail : IMail
    {
        private readonly IConfiguration _configuration;
        public Mail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendMail(SendMailDto dto)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailSettings:EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(dto.To));
            email.Subject = dto.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = dto.Body };

            using var smtp = new SmtpClient();

            smtp.Connect(_configuration.GetSection("EmailSettings:EmailHost").Value, 587,MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate(_configuration.GetSection("EmailSettings:EmailUserName").Value, _configuration.GetSection("EmailSettings:EmailPassword").Value);
            smtp.Send(email);

            smtp.Disconnect(true);
        }
    }
}
