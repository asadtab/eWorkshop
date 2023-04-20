using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
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
        public APIService KorisniciService = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.username = txtUsername.Text;
            APIService.password = txtPassword.Text;

            try
            {
                KorisniciSearchObject search = new KorisniciSearchObject();
                search.KorisnickoIme = APIService.username;

                var result = await KorisniciService.Get<List<KorisniciVM>>(search);

                APIService.Korisnik = new KorisniciVM();

                APIService.Korisnik = result.FirstOrDefault();

                mdiPocetna form = new mdiPocetna();
                form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresno korisnicko ime ili password => forma");
            }


        }
    }
}
