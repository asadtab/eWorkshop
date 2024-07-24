using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.WinUI.Service;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IdentityModel.OidcConstants;

namespace eWorkshop.WinUI
{
    public partial class frmDodajKlijent : Form
    {

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;
        public APIService IdsClient;

        public frmDodajKlijent(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private async void Dodaj_Click(object sender, EventArgs e)
        {
            IdsClient = new APIService("Client", TokenService);

            var client = new ClientInsertRequest();



            client.AllowedGrantTypes = new Collection<string> { new string(GrantTypes.AuthorizationCode) };
            client.ProtocolType = GrantTypes.AuthorizationCode;
            client.ClientId = txtClientId.Text;
            client.ClientName = txtClientName.Text;
            client.ClientUri = txtClientUri.Text;
            //client.ClientSecrets.Add();


            try
            {
                await IdsClient.Post<ClientVM>(client);

                ClearForm();
            }
            catch (Exception)
            {
                throw new Exception("Neuspješno dodavanje klijenta!");
            }


        }

        private void ClearForm()
        {
            txtClientId.Text = "";
            txtClientName.Text = "";
            txtClientUri.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipKlijenta.SelectedIndex == 1)
            {
                lblInfo.Text = "Povjerljivi klijenti su aplikacije koje mogu sigurno da pohrane" +
                    " kredencijale. To su uglavnom web aplikacije koje se vrte na serveru " +
                    "ili aplikacije kao što je su Windows forms aplikacije koje mogu " +
                    "sigurno da pohrane kredencijale klijenta.";

                txtClientSecret.Enabled = true;
                txtConfirmClientSecret.Enabled = true;

                EnableDisableTextBox(true);

            }
            else if (cmbTipKlijenta.SelectedIndex == 0)
            {
                lblInfo.Text = "Javni klijenti ne mogu sigurno da pohrane kredencijale. " +
                    "To su uglavnom aplikacije koje se polreću na uređajima gdje se ne mogu " +
                    "na siguran način pohraniti kredencijali, kao što su " +
                    "Single-Page aplikacije(SPA) i mobilne aplikacije.";

                EnableDisableTextBox(false);
            }
        }

        private void EnableDisableTextBox(bool v)
        {
            txtClientSecret.Enabled = v;
            txtConfirmClientSecret.Enabled = v;
        }
    }
}
