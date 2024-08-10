using EasyNetQ;
using mailslurp.Api;
using mailslurp.Client;
using mailslurp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
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

    }
}