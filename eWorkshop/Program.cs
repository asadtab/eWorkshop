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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });

    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("https://localhost:5443/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5443/connect/token"),
                Scopes = new Dictionary<string, string>
            {
                {"weatherapi.read", "Demo API - full access"},
                {"weatherapi.post", "Demo API - full access"},
            }
            }
        }
    });

    options.OperationFilter<AuthorizeCheckOperationFilter>();
});
/*c =>
{
    c.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference{ Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
        },
        new string[]{}
        }
    });
});*/

builder.Services.AddTransient<IUredjajService, UredjajService>();
builder.Services.AddTransient<IReparacijaService, ReparacijaService>();
builder.Services.AddTransient<IRadniZadatakService, RadniZadatakService>();
builder.Services.AddTransient<IKorisniciService, KorisniciService>();
builder.Services.AddTransient<IKomponenteService, KomponenteService>();
builder.Services.AddTransient<IServisIzvrsenService, ServisIzvrsenService>();
//builder.Services.AddTransient<IRadniZadatakService, RadniZadatakService>();
builder.Services.AddTransient<ITipUredjajaService, TipUredjajaService>();
builder.Services.AddTransient<IRadniZadatakUredjajService, RadniZadatakUredjajService>();
builder.Services.AddTransient<ILokacijaService, LokacijaService>();
builder.Services.AddTransient<IServisAdapter, ServisAdapter>();


builder.Services.AddAutoMapper(typeof(UredjajService));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5443";
        options.Audience = "weatherapi";

        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

/*builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);*/

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        options.OAuthClientId("demo_api_swagger");
        options.OAuthAppName("Demo API - Swagger");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
