using eWorkshop.MailPublisher.Services;
using eWorkshop.MailSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.MailSender.Controllers
{
    public class SendEmailController: ControllerBase
    {
        private readonly IEmailService EmailService;
        private readonly IMailSenderService MailSender;
        public SendEmailController(IEmailService emailService, IMailSenderService mailSenderService)
        {
            EmailService = emailService;
            MailSender = mailSenderService;
        }

        [HttpGet("MailPublisher")]
        public async Task MailPublisher(string poruka, List<string> sendTo)
        {
            try
            {
               await EmailService.SendMessage(poruka, sendTo);
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
            }


        }
    }
}
