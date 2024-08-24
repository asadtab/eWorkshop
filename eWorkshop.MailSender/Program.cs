using eWorkshop.MailPublisher.Config;
using eWorkshop.MailPublisher.Services;
using eWorkshop.MailSender.Model;
using eWorkshop.MailSender.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)

    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.Configure<SMTPConfiguration>(builder.Configuration.GetSection("Mail"));
builder.Services.Configure<RabbitConfiguration>(builder.Configuration.GetSection("RabbitMQ"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IMailSenderService, MailSenderService>();





var app = builder.Build();

var emailService = app.Services.GetRequiredService<IMailSenderService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
