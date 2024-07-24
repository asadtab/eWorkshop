using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Service;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmUloge : Form
    {
        private FormControl FormControl = new FormControl();


        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;
        public APIService Uloge { get; set; }

        public frmUloge(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            FormControl.OpcijeTabele(dgvListaUloga);

            Uloge = new APIService("AspNetRole", TokenService);
        }

        private async void frmUloge_Load(object sender, EventArgs e)
        {
            dgvListaUloga.DataSource = await Uloge.Get<List<AspNetRoleVM>>();

        }

        private void btnDodajNovogKorisnika_Click(object sender, EventArgs e)
        {
            frmDodajUlogu childForm = ServiceProvider.GetRequiredService<frmDodajUlogu>();
            childForm.ShowDialog();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            AspNetRolesSearchObject search = new AspNetRolesSearchObject();

            search.Name = txtNazivUloge.Text;

            dgvListaUloga.DataSource = await Uloge.Get<List<AspNetRoleVM>>(search);
        }
    }
}
