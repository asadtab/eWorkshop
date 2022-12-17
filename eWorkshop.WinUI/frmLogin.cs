using eWorkshop.Model;
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
                var result = await KorisniciService.Get<dynamic>();
                var form = new mdiPocetna();
                form.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresno korisnicko ime ili password => forma");
            }

            
        }
    }
}
