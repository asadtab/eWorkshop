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
using eWorkshop.WinUI.Service;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using eWorkshop.Services.IDS;
using Microsoft.AspNetCore.Identity;
using eWorkshop.IdentityServer.Database;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
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
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
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

builder.Services.AddTransient<ISwaggerProvider, SwaggerGenerator>();

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
builder.Services.AddTransient<IStaniceService, StaniceService>();
builder.Services.AddTransient<IStaniceUredjajService, StaniceUredjajService>();
builder.Services.AddTransient<IUlogeService, UlogeService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IApiResourceService, ApiResourceService>();
builder.Services.AddTransient<IScopesService, ScopesService>();
builder.Services.AddTransient<IAspNetUserService, AspNetUserService>();
builder.Services.AddTransient<IAspNetRoleService, AspNetRoleService>();

/*builder.Services.AddScoped<UserManager<IdentityUser>>();*/


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

builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<_190128Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
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

app.Run();
