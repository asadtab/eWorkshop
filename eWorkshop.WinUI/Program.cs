using eWorkshop.WinUI.Service;
using eWorkshop.WinUI.UserControls;
using eWorkshop.WinUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eWorkshop.WinUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var host = Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, builder) =>
             {
                 // Add other configuration files...
                 builder.AddJsonFile("appsettings.local.json", optional: true);
             })
             .ConfigureServices((context, services) =>
             {
                 ConfigureServices(context.Configuration, services);
             })
             .ConfigureLogging(logging =>
             {
                 // Add other loggers...
             })
             .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            var services = host.Services;
            var loginForm = services.GetRequiredService<frmLogin>();
            var mainForm = services.GetRequiredService<mdiPocetna>();

            if(loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.EnableVisualStyles();
                Application.Run(mainForm);
            } else
            {
                Application.Exit();
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.Configure<AppSettings>
            (configuration.GetSection(nameof(AppSettings)));

            services.Configure<IdentityServerSettings>(configuration.GetSection("IdentityServerSettings"));

            services.AddSingleton<frmLogin>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddTransient<frmMain>();
            services.AddTransient<frmRadniZadatakDetalji>();
            services.AddTransient<frmRadniZadaci>();
            services.AddTransient<mdiPocetna>();
            services.AddTransient<frmDodajKomponentu>();
            services.AddTransient<frmDodajTipUredjaja>();
            services.AddTransient<frmKomponenteEdit>();
            services.AddTransient<frmKomponenteLista>();
            services.AddTransient<frmDodajKorisnika>();
            services.AddTransient<frmKorisnici>();
            services.AddTransient<frmListaUredjaja>();
            services.AddTransient<frmMagacin>();
            services.AddTransient<frmNoviRadniZadatak>();
            services.AddTransient<frmPrijemUredjaja>();
            services.AddTransient<frmReportPicker>();
            services.AddTransient<frmServis>();
            services.AddTransient<frmUredjajDetalji>();
            services.AddTransient<frmRacun>();
            services.AddTransient<frmRadniZadaciLista>();
            services.AddTransient<frmDodajKlijent>();
            services.AddTransient<frmKlijenti>();
            services.AddTransient<frmResursi>();
            services.AddTransient<frmDodajResurs>();
            services.AddTransient<frmUloge>();
            services.AddTransient<frmDodajUlogu>();

        }
    }
}