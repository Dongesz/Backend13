using EmailService.Models.DTOs;

namespace EmailService.Services.ISendMail
{
    public interface IMail
    {
        void SendMail(SendMailDto dto);
    }
}
