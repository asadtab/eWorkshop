using eWorkshop.Model;
using eWorkshop.WinUI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    public partial class frmDodajUlogu : Form
    {
        private APIService Uloge { get; set; }

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmDodajUlogu(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            Uloge = new APIService("Uloge", TokenService, true);
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            string uloga = txtUloga.Text.Trim();

            if (string.IsNullOrEmpty(uloga))
            {
                MessageBox.Show("Naziv uloge ne može biti prazan.");
            }

            var result = new AspNetRoleVM();

            try
            {
                 result = await Uloge.Post<AspNetRoleVM>(uloga);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }

            if(result is not null)
            {
                MessageBox.Show($"Uloga {result.Name} je uspješno dodana.");
            }
        }
    }
}
