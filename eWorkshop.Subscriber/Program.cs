    using RabbitMQ.Client.Events;
    using RabbitMQ.Client;
    using System.Text;
    using eWorkshop.SMTP.Services;

    var factory = new ConnectionFactory
    {
        HostName = "eworkshop-rabbitmq",
        Port = 5672,
        UserName = "guest",
        Password = "guest",
    };
    factory.ClientProvidedName = "Rabbit Test Consumer";
    IConnection connection = factory.CreateConnection();
    IModel channel = connection.CreateModel();

    string exchangeName = "EmailExchange";
    string routingKey = "email_queue";
    string queueName = "test";

    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queueName, true, false, false, null);
    channel.QueueBind(queueName, exchangeName, routingKey, null);

    var consumer = new EventingBasicConsumer(channel);

    consumer.Received += (sender, args) =>
    {
        //Task.Delay(TimeSpan.FromSeconds(2)).Wait();
        var body = args.Body.ToArray();
        string message = Encoding.UTF8.GetString(body);

        Console.WriteLine($"Message received: {message}");
        //EmailService emailService = new EmailService();
        //emailService.SendMessage(message);  

        //channel.BasicAck(args.DeliveryTag, false);
    };

    channel.BasicConsume(queueName, false, consumer);

    Console.WriteLine("Waiting for messages. Press Q to quit.");

    // Sleep for a long time to keep the application running
    Thread.Sleep(Timeout.Infinite);

    // Close resources before exiting
    channel.Close();
    connection.Close();