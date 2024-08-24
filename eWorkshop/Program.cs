using eWorkshop.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Duende.IdentityServer.Test;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using eWorkshop;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using eWorkshop.Services.IDS;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Logging;
using System.Net;
using eWorkshop.MailPublisher.Services;
using eWorkshop.MailPublisher.Config;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddTransient<ISwaggerProvider, SwaggerGenerator>();

builder.Services.AddTransient<IUredjajService, UredjajService>();
builder.Services.AddTransient<IReparacijaService, ReparacijaService>();
builder.Services.AddTransient<IRadniZadatakService, RadniZadatakService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IKomponenteService, KomponenteService>();
builder.Services.AddTransient<IServisIzvrsenService, ServisIzvrsenService>();
builder.Services.AddTransient<IRadniZadatakService, RadniZadatakService>();
builder.Services.AddTransient<ITipUredjajaService, TipUredjajaService>();
builder.Services.AddTransient<IRadniZadatakUredjajService, RadniZadatakUredjajService>();
builder.Services.AddTransient<ILokacijaService, LokacijaService>();
builder.Services.AddTransient<IServisAdapter, ServisAdapter>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IApiResourceService, ApiResourceService>();
builder.Services.AddTransient<IScopesService, ScopesService>();

builder.Services.AddTransient<IUlogeService, UlogeService>();
builder.Services.AddTransient<IClientSecretService, ClientSecretService>();
builder.Services.AddTransient<IClientScopeService, ClientScopeService>();
builder.Services.AddTransient<IClientGrantTypeService, ClientGrantTypeService>();

builder.Services.AddSingleton<IEmailService, EmailService>();





builder.Services.AddAutoMapper(typeof(UredjajService));

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddIdentityServer(x =>
{
    x.IssuerUri = "foo";
});


builder.Services.AddAuthentication(x => 
{ 
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
})
    .AddJwtBearer(options =>
    {
        options.Authority = "http://eworkshop-ids:5443";
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.Audience = "api";
        //options.Audience = "SuperSecretPassword";
        

        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("ApiSettings:IdentityServerMetaDataUrl"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<_190128Context>(options =>
    options.UseSqlServer(connectionString));




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

var app = builder.Build();


// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

    // Configure Swagger to use Identity Server authorization endpoint
    options.OAuthClientId("swagger"); // Client ID registered in Identity Server
    options.OAuthAppName("Swagger UI");
    options.OAuthUsePkce();
    });
}

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<_190128Context>();
    dataContext.Database.Migrate();
}
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
IdentityModelEventSource.ShowPII = true;

app.Run();
