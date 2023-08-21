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
    public partial class frmDodajKorisnika : Form
    {
        public APIService KorisniciService { get; set; }
        public APIService AspNetUserService { get; set; }
        public APIService Scopes { get; set; }
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;
        public FormControl FormControl { get; set; } = new FormControl();

        List<string> checkedRoles = new List<string>();

        public frmDodajKorisnika(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            KorisniciService = new APIService("Korisnici", TokenService);
            Scopes = new APIService("Scopes", TokenService);
            AspNetUserService = new APIService("AspNetUser", TokenService);
        }

        private async void frmDodajKorisnika_Load(object sender, EventArgs e)
        {

        }

        private bool ValidirajUnos()
        {
            return FormControl.CheckInput(errProvider, txtIme, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPrezime, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtEmail, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPassword, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPasswordPotvrda, FormControl.ObaveznaVrijednost);
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            AspNetUserInsertRequest request = new AspNetUserInsertRequest();

            request.UserName = txtIme.Text.ToLower() + txtPrezime.Text.ToLower();
            request.Email = txtEmail.Text;
            //request.PasswordHash = txtPassword.Text == txtPasswordPotvrda.Text ? txtPasswordPotvrda.Text : "";
            request.NormalizedUserName = request.UserName.ToLower();

            if (txtPassword.Text != txtPasswordPotvrda.Text)
            {
                throw new Exception("Lozinke se ne podudaraju!");
            }

            if (ValidirajUnos())
            {
                AspNetUserService.Post<AspNetUserVM>(request);
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
            
        private void chlbUloge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chlbUloge.SelectedIndex != -1)
            {
                bool isSelected = chlbUloge.GetSelected(chlbUloge.SelectedIndex);

                if (isSelected)
                {
                    // Item is checked
                    foreach (var item in chlbUloge.CheckedItems)
                    {
                        checkedRoles.Add(item.ToString());
                    }
                }
                else
                {
                    // Item is unchecked
                    foreach (var item in chlbUloge.CheckedItems)
                    {
                        checkedRoles.Add(item.ToString());
                    }
                }

                

                string checkedItemsText = string.Join(", ", checkedRoles);
                MessageBox.Show("Checked items: " + checkedItemsText);
            }
        }
    }
}
