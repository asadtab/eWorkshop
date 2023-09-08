using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI
{

    public partial class frmLogin : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmLogin(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService KorisniciService = new APIService("Korisnici", TokenService);
            APIService KorisniciServiceLogin = new APIService("Korisnici/Login", TokenService);

            APIService.username = txtUsername.Text;
            APIService.password = txtPassword.Text;

            try
            {
                LoginSearchObject login = new LoginSearchObject();

                login.username = APIService.username;
                login.password = APIService.password;

                KorisniciVM korisnik = await KorisniciServiceLogin.Get<KorisniciVM>(login);

                if (korisnik == null)
                {
                    MessageBox.Show("Pogrešni kredencijali!");
                }

                APIService.Korisnik = new KorisniciVM();

                APIService.Korisnik = korisnik;

                if (APIService.Korisnik != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                /*mdiPocetna form = ServiceProvider.GetRequiredService<mdiPocetna>();
                form.Show();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }
    }
}
