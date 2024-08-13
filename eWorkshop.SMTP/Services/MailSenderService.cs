using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.SMTP.Model;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using EasyNetQ.Management.Client.Model;
using System.Diagnostics;

namespace eWorkshop.SMTP.Services
{
    public class MailSenderService: IMailSenderService
    {

        private IConnection? Connection;
        private IModel? Channel;

        public MailSenderService()
        {
            Connect();
        }

        private void Connect()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "eworkshop-rabbitmq",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest",
                };

                Connection = factory.CreateConnection();
                Channel = Connection.CreateModel();

                string exchangeName = "EmailExchange";
                string routingKey = "email_queue";
                string queueName = "test";


                Channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
                Channel.QueueDeclare(queueName, true, false, false, null);
                Channel.QueueBind(queueName, exchangeName, routingKey, null);


                var consumer = new AsyncEventingBasicConsumer(Channel);
                consumer.Received += SendMailEventHandler;

                Channel.BasicConsume(
                    queue: queueName,
                    autoAck: true,
                    consumer: consumer
                );
            }
            catch (Exception ex)
            {
                
            }
        }

        private async Task SendMailEventHandler(object? model, BasicDeliverEventArgs eventArgs)
        {
            if (Debugger.IsAttached) return;

            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            await SendEmail(message);
        }
        public Task SendEmail(string message)
        {
            try
            {
                // assumming you have defined environment variables for your SMTP server
                string smtpServer = "smtp.gmail.com";
                int smtpPort =  587;
                string fromMail = "asad1tabak@gmail.com";
                string password = "rsjlcokdmnytlqem";

                // using EmailModelToParse for more simple deserialization process
                // defining sender and recipient email address, subject and content
                /*var emailData = JsonConvert.DeserializeObject<EmailModel>(message);
                var senderEmail = emailData.Sender;
                var recipientEmail = emailData.Recipient;
                var subject = emailData.Subject;
                var content = emailData.Content;*/

                // creating a MailMessage object to specify from, subject, to and body for an email
                MailMessage MailMessageObj = new MailMessage();

                MailMessageObj.From = new MailAddress(fromMail);
                MailMessageObj.Subject = "test";
                MailMessageObj.To.Add("asad.tabak@edu.fit.ba");
                MailMessageObj.Body = message;

                // make sure your SMTP credentials are set up properly
                // for gmail you'll need to use a special app password
                var smtpClient = new SmtpClient()
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    Credentials = new NetworkCredential(fromMail, password),
                    EnableSsl = true
                };

                // using SMTP client to send the email
                smtpClient.Send(MailMessageObj);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
