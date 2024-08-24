using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;
using eWorkshop.IdentityServer;
using eWorkshop.IdentityServer.Data;
using eWorkshop.Model;
using eWorkshop.Services;
using eWorkshop.Services.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

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

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;


builder.Services.AddDbContext<_190128Context>(options =>
{
    options.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly));
});


builder.Services.AddIdentity<Korisnici, Uloge>().AddUserManager<Microsoft.AspNetCore.Identity.UserManager<Korisnici>>()
    .AddRoleManager<Microsoft.AspNetCore.Identity.RoleManager<Uloge>>()
            .AddEntityFrameworkStores<_190128Context>().AddDefaultTokenProviders();


builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    options.EmitStaticAudienceClaim = true;
})
    .AddDeveloperSigningCredential()
.AddAspNetIdentity<Korisnici>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCookiePolicy(new CookiePolicyOptions() { MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax });
}


app.UseIdentityServer();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();


app.Run();
