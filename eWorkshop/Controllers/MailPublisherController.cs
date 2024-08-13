using eWorkshop.MailPublisher.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MailPublisherController
    {
        private readonly IEmailService EmailService;
        public MailPublisherController(IEmailService emailService)
        {
            EmailService = emailService;
        }

        [HttpGet("MailPublisher")]
        public async Task MailPublisher(string poruka)
        {
            try
            {
                await EmailService.SendMessage(poruka);
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
            }


        }
    }
}
