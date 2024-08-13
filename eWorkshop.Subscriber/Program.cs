using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using eWorkshop.SMTP.Services;

var factory = new ConnectionFactory
{
    HostName = "eworkshop-rabbitmq",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    ClientProvidedName = "Rabbit Test Consumer"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

string exchangeName = "EmailExchange";
string routingKey = "email_queue";
string queueName = "test";

// Declare exchange and queue
channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
channel.QueueDeclare(queueName, true, false, false, null);
channel.QueueBind(queueName, exchangeName, routingKey, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += async (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    try
    {
        EmailService emailService = new EmailService();
        await emailService.SendMailGmail(message);

        // Acknowledge the message after successful processing
        channel.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to send email: {ex.Message}");
        // Optionally: Reject and requeue or discard the message
        // channel.BasicNack(deliveryTag: eventArgs.DeliveryTag, multiple: false, requeue: true);
    }
};

channel.BasicConsume(queueName, autoAck: false, consumer);

Console.WriteLine("Waiting for messages. Press Q to quit.");
while (Console.ReadKey().Key != ConsoleKey.Q) { }

channel.Close();
connection.Close();
