using EasyNetQ;
using eWorkshop.SMTP.Model;
using MailKit;
using MailKit.Net.Smtp;
using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Org.BouncyCastle.Cms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace eWorkshop.SMTP.Services
{
    public class EmailService : IEmailService
    {

        private readonly ILogger<EmailService> Logger;
        private IConnection? Connection;
        private IModel? Channel;

        public EmailService(ILogger<EmailService> logger)

        {
            Logger = logger;
        }

        public EmailService() { }
        public void SendMessage(string message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "eworkshop-rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };
            factory.ClientProvidedName = "Rabbit Test";

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            string exchangeName = "EmailExchange";
            string routingKey = "email_queue";
            string queueName = "test";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, true, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            string emailModelJson = JsonConvert.SerializeObject(message);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(emailModelJson);
            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
        }

        public async Task SendMailGmail(string poruka)
        {
            try
            {

                string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER") ?? "smtp.gmail.com";
                int smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT") ?? "587");
                string fromMail = "asad1tabak@gmail.com";
                string password = "bsndokivcjwddido";

                EmailModel model = new EmailModel()
                {
                    Content = "Hello World",
                    Sender = "asad1tabak@gmail.com",
                    Subject = "Test",
                    Recipient = "asad.tabak@edu.fit.ba",
                };

                /*var emailData = JsonConvert.DeserializeObject<EmailModel>(poruka);
                var senderEmail = emailData.Sender;
                var recipientEmail = emailData.Recipient;
                var subject = emailData.Subject;
                var content = emailData.Content;*/

                System.Net.Mail.MailMessage MailMessageObj = new MailMessage();



                MailMessageObj.From = new System.Net.Mail.MailAddress(fromMail);
                MailMessageObj.Subject = model.Subject;
                MailMessageObj.To.Add(model.Recipient);
                MailMessageObj.Body = model.Content;

                var smtpClient = new System.Net.Mail.SmtpClient()
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    Credentials = new NetworkCredential(fromMail, password),
                    EnableSsl = true
                };

                smtpClient.Send(MailMessageObj);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Send Error GMail exception");
            }

        }


            public async Task SendMail(string poruka)
        {
            try
            {
                var config = new Configuration();

                config.ApiKey.Add("x-api-key", "b3950e6b3d75bb001cf8a943a16a416574ab75627679a9e2fbfb0f3aef490e3b");

                var inboxControllerApi = new InboxControllerApi(config);

                var inboxController = new InboxControllerApi(config);
                var inbox = inboxControllerApi.CreateInbox();


                //Assert.IsTrue(inbox.EmailAddress.Contains("@mailslurp"));

                inboxControllerApi.SendEmail(inbox.Id, new SendEmailOptions(
    to: new List<string> { "asad.tabak@edu.fit.ba" },
    subject: "Test CSharp",
    body: "<span>Hello</span>",
    isHTML: true
));

                //var sentEmail = inboxControllerApi.SendEmailAndConfirm(inboxControllerApi.i, sendEmailOptions);
                Logger.LogInformation("Email sent to asad.tabak@edu.fit.ba");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Send Error Mail exception");
            }
        }

    }
}