using EmailService.Models.DTOs;
using EmailService.Services.ISendMail;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMail mail;
        public MailController(IMail mail)
        {
            this.mail = mail;
        }

        [HttpPost]
        public ActionResult SendMail(SendMailDto dto)
        {
            mail.SendMail(dto);
            return Ok(new { message = "Sikeres email kuldes" });
        }
    }
}
