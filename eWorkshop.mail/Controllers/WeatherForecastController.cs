using EasyNetQ;
using eWorkshop.MailPublisher.Services;
using eWorkshop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace eWorkshop.SMTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEmailService EmailService;
        public WeatherForecastController(IEmailService emailService)
        {
            EmailService = emailService;
        }


        /*[HttpGet("SendEmailGmail")]
        public async Task SendEmailGmail(string poruka)
        {
            try
            {
                await EmailService.MailPublisher(poruka);
            }
            catch (Exception ex)
            {
                Task.FromException(ex);
            }


        }*/

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

        [HttpPost("SendConfirmationEmail")]
        public IActionResult SendConfirmationEmail(string poruka)
        {
            try
            {
                //EmailService.SendMessage(poruka);
                //Thread.Sleep(TimeSpan.FromSeconds(15));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    }

