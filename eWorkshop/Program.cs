using AutoMapper;
using eWorkshop.Services;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

/*Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();*/

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUredjajService, UredjajService>();
builder.Services.AddTransient<IReparacijaService, ReparacijaService>();
builder.Services.AddTransient<IRadniZadatakService, RadniZadatakService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IKomponenteService, KomponenteService>();
builder.Services.AddTransient<IServisIzvrsenService, ServisIzvrsenService>();
builder.Services.AddTransient<ITipUredjajaService, TipUredjajaService>();
builder.Services.AddTransient<IRadniZadatakUredjajService, RadniZadatakUredjajService>();
builder.Services.AddTransient<ILokacijaService, LokacijaService>();
builder.Services.AddTransient<IServisAdapter, ServisAdapter>();
builder.Services.AddTransient<IUlogeService, UlogeService>();


builder.Services.AddAutoMapper(typeof(UredjajService));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


//var connectionString = "Server=172.19.0.2,1433;Database=eWorkshop;User=sa;Password=nIcxa2eGxjk7vY;Encrypt=False;TrustServerCertificate=True";
builder.Services.AddDbContext<_190128Context>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<Korisnici, Uloge>()
    .AddEntityFrameworkStores<_190128Context>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ActiveDeviceState>();
builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<FixDeviceState>();
builder.Services.AddTransient<IdleDeviceState>();
builder.Services.AddTransient<InitialDeviceState>();
builder.Services.AddTransient<OutDeviceState>();
builder.Services.AddTransient<PartsDeviceState>();
builder.Services.AddTransient<ReadyDeviceState>();
builder.Services.AddTransient<TaskDeviceState>();

builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.BaseState>();
builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.ActiveTaskState>();
builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.DoneTaskState>();
builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.IdleTaskState>();
builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.InitialTaskState>();
builder.Services.AddTransient<eWorkshop.Services.RadniZadatakStateMachine.InvoiceTaskState>();

var secret = builder.Configuration["Jwt:Secret"];
Console.WriteLine("Secret: " + secret);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secret!)),

            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,

            RoleClaimType = ClaimTypes.Role
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("JWT OnAuthenticationFailed:");
                Console.WriteLine($"Type: {context.Exception.GetType().Name}");
                Console.WriteLine($"Message: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("JWT token successfully validated");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();





app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.MapControllers();

app.Run();