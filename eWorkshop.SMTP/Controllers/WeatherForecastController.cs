using EasyNetQ;
using eWorkshop.SMTP.Services;
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

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task Get()
        {
             await EmailService.SendEmail();

         }

        [HttpPost("SendConfirmationEmail")]
        public IActionResult SendConfirmationEmail()
        {
            try
            {
                EmailService.SendMessage("Asad TAbak");
                Thread.Sleep(TimeSpan.FromSeconds(15));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    }

