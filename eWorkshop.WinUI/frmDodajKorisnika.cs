using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.WinUI.Service;
using Microsoft.AspNetCore.Mvc;
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
        public APIService IdsRegister { get; set; }

        public APIService Uloge { get; set; }
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
            Uloge = new APIService("AspNetRole", TokenService);
            IdsRegister = new APIService("Account", TokenService, true);
        }

        private async void frmDodajKorisnika_Load(object sender, EventArgs e)
        {
            chlbUloge.DataSource = await Uloge.Get<List<AspNetRoleVM>>();
            chlbUloge.DisplayMember = "name";

            chlbUloge.ItemCheck += checkBoxList_ItemCheck;
        }

        private bool ValidirajUnos()
        {
            return FormControl.CheckInput(errProvider, txtIme, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPrezime, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtEmail, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPassword, FormControl.ObaveznaVrijednost) &&
            FormControl.CheckInput(errProvider, txtPasswordPotvrda, FormControl.ObaveznaVrijednost);
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            AspNetUserInsertRequest request = new AspNetUserInsertRequest();

            request.UserName = txtIme.Text.ToLower() + "." + txtPrezime.Text.ToLower();
            request.Email = txtEmail.Text;
            request.NormalizedUserName = request.UserName.ToLower();
            request.Roles = checkedRoles;

            if (txtPassword.Text != txtPasswordPotvrda.Text)
            {
                throw new Exception("Lozinke se ne podudaraju!");
            }

            request.PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtPassword.Text));

            HttpClient client = new HttpClient();

            if (ValidirajUnos())
            {
                try
                {
                    var result = await IdsRegister.Post<OkObjectResult>(request);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            else
                MessageBox.Show("Polja ne smiju biti prazna");
        }

        private void chbUposlenik_CheckStateChanged(object sender, EventArgs e)
        {
            if (chbUposlenik.Checked)
            {
                chlbUloge.Enabled = false;

                for (int i = 0; i < chlbUloge.Items.Count; i++)
                {
                    chlbUloge.SetItemChecked(i, false);

                    /*                    if (chlbUloge.CheckedItems.Contains(chlbUloge.Items[i]))
                                        {
                                            // Item is checked, add it to the list
                                            checkedRoles.Add(chlbUloge.Items[i].ToString());
                                        }*/
                }



            }
            else
            {
                chlbUloge.Enabled = true;
            }
        }

/*        private void chlbUloge_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            foreach (var item in chlbUloge.Items)
            {
                if (chlbUloge.CheckedItems.Contains(item))
                {
                    // Item is checked, add it to the list
                    checkedRoles.Add(item.ToString());
                    return;
                }
                else
                {
                    if (checkedRoles.Contains(item.ToString()))
                    {
                        checkedRoles.Remove(item.ToString());
                    }
                }
            }

            *//* bool isChecked = (e.NewValue == CheckState.Checked);

             if (isChecked)
             {


                 // Handle item being checked
                 foreach (var item in chlbUloge.CheckedItems)
                 {
                     checkedRoles.Add((item as AspNetRoleVM).Name);
                 }
             }
             else
             {
                 // Handle item being unchecked
                 foreach (var item in chlbUloge.CheckedItems)
                 {
                     checkedRoles.Remove((item as AspNetRoleVM).Name);
                 }
             }*//*

            string checkedItemsText = string.Join(", ", checkedRoles);
            MessageBox.Show("Checked items: " + checkedItemsText);
        }

        private void chlbUloge_SelectedIndexChanged(object sender, EventArgs e)
        {



        }*/

        private void checkBoxList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string itemText = (chlbUloge.Items[e.Index] as AspNetRoleVM).Name;

            // If the item is being checked, add it to the list
            if (e.NewValue == CheckState.Checked)
            {
                checkedRoles.Add(itemText);
            }
            // If the item is being unchecked and exists in the list, remove it
            else if (e.NewValue == CheckState.Unchecked && checkedRoles.Contains(itemText))
            {
                checkedRoles.Remove(itemText);
            }

            // Display the items in a TextBox (for demonstration)
            //UpdateTextBox();
        }
    }
}
