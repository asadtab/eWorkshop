using Microsoft.AspNetCore.Connections;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using eWorkshop.MailPublisher.Services;
using Newtonsoft.Json;
using eWorkshop.MailSender.Model;

namespace eWorkshop.MailSender.Services
{
    public class MailSenderService : IMailSenderService
    {
        private readonly ILogger<MailSenderService> _logger;
        private IConnection? connection;
        private IModel? channel;

        public MailSenderService(ILogger<MailSenderService> logger)
        {
            _logger = logger;
            _logger.LogInformation("MailSenderService initialized.");
            Connect();
        }

        public void Connect()
        {
            while (true)
            {
                try
                {
                    _logger.LogInformation("Pokušaj uspostavljanja konekcije prema RabbitMQ ...");

                    var factory = new ConnectionFactory
                    {
                        HostName = "eworkshop-rabbitmq",
                        Port = 5672,
                        UserName = "guest",
                        Password = "guest",
                    };

                    connection = factory.CreateConnection();
                    _logger.LogInformation("RabbitMQ konekcija kreirana uspješno.");

                    _logger.LogInformation("Pokušaj kreiranja RabbitMQ kanala ...");
                    channel = connection.CreateModel();
                    _logger.LogInformation("RabbitMQ kanal kreiran uspješno.");

                    string exchangeName = "EmailExchange";
                    string routingKey = "email_queue";
                    string queueName = "test";

                    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                    channel.QueueDeclare(queueName, true, false, false, null);
                    channel.QueueBind(queueName, exchangeName, routingKey, null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (sender, args) =>
                    {
                        var body = args.Body.ToArray();
                        string message = Encoding.UTF8.GetString(body);

                        _logger.LogInformation($"Primljena poruka {message}");
                        await SendEmail(message);

                        channel.BasicAck(args.DeliveryTag, false);
                    };

                    channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

                    break; // Exit loop if connection succeeds
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Ponovni pokušaj nakon 5 sekundi.");
                    Task.Delay(5000).Wait();
                }
            }
        }


        public Task SendEmail(string message)
        {
            try
            {
                _logger.LogInformation($"Šaljem email sa porukom {message}");

                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string fromMail = "asad1tabak@gmail.com";
                string password = "rsjlcokdmnytlqem";


                var emailData = JsonConvert.DeserializeObject<EmailModel>(message);
                
                
                var content = emailData.Body;


                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromMail),
                    Subject = "Prijava smetnje",
                    Body = content
                };

                string[] adrese = new string[] { };

                foreach (var adr in emailData.ToSend)
                {
                    mailMessage.To.Add(adr);
                }

                mailMessage.To.Add("asad.tabak@edu.fit.ba");

                var smtpClient = new SmtpClient
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    Credentials = new NetworkCredential(fromMail, password),
                    EnableSsl = true
                };

                smtpClient.Send(mailMessage);
                _logger.LogInformation("Email poslan uspješno.");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Greška prilikom slanja maila.");
                return Task.FromException(ex);
            }
        }
    }
}
