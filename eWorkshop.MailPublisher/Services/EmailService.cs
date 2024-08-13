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

        public Task SendMessage(string message)
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
