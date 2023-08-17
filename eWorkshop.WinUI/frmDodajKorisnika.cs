using eWorkshop.Model;
using eWorkshop.Model.Requests;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace eWorkshop.WinUI
{
    public partial class frmDodajKlijenta : Form
    {
        public APIService KorisniciService { get; set; }
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;
        public FormControl FormControl { get; set; } = new FormControl();

        public frmDodajKlijenta(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            KorisniciService = new APIService("Korisnici", TokenService);
        }

        private void frmDodajKorisnika_Load(object sender, EventArgs e)
        {

        }

        private bool ValidirajUnos()
        {
            return FormControl.CheckInput(errProvider, txtIme, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPrezime, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtEmail, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPassword, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPasswordPotvrda, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtTelefon, FormControl.ObaveznaVrijednost);
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            KorisniciInsertRequest request = new KorisniciInsertRequest();

            request.Ime = txtIme.Text;
            request.Prezime = txtPrezime.Text;
            request.Email = txtEmail.Text;
            request.Password = txtPassword.Text;
            request.PasswordPotvrda = txtPasswordPotvrda.Text;
            request.Telefon = txtTelefon.Text;
            request.KorisnickoIme = request.Ime + "." + request.Prezime;

            if (ValidirajUnos())
            {
                KorisniciService.Post<KorisniciVM>(request);
            }
            else
            {
                MessageBox.Show("Netačna vrijednost!");
            }
        }

        private void chbUposlenik_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbUposlenik.Checked)
            {
                chlbUloge.Enabled = false;

                for (int i = 0; i < chlbUloge.Items.Count; i++)
                {
                    chlbUloge.SetItemChecked(i, false);
                }

                
            }
            else
            {
                chlbUloge.Enabled = true;
            }
        }
    }
}
