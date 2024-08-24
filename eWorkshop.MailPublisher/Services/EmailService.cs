﻿using eWorkshop.MailPublisher.Config;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.MailPublisher.Services
{
    public class EmailService: IEmailService
    {
        private readonly RabbitConfiguration _RabbitConfiguration;
        IOptions<RabbitConfiguration> rabbitConf;

        public EmailService(
            IOptions<RabbitConfiguration> rabbitConfiguration)
        {
            rabbitConf = rabbitConfiguration;
            _RabbitConfiguration = rabbitConfiguration.Value;
        }

        public Task SendMessage(string message, List<string> sendTo)
        {

            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _RabbitConfiguration.Host,
                    Port = _RabbitConfiguration.Port,
                    UserName = _RabbitConfiguration.User,
                    Password = _RabbitConfiguration.Password,
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

                var jsonObj = new {
                Body = message,
                ToSend = sendTo.ToArray()
                };

                string emailModelJson = JsonConvert.SerializeObject(jsonObj);
                byte[] messageBodyBytes = Encoding.UTF8.GetBytes(emailModelJson);
                channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                return Task.FromException(e);
                throw;
            }
        } 
    }
}
