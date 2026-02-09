namespace EmailService.Models.DTOs
{
    public class SendMailDto
    {
        public string To{ get; set; }
        public string Subject{ get; set; }
        public string Body{ get; set; }
    }
}
