using eWorkshop.SMTP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEmailService, EmailService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetRequiredService<IEmailService>();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();