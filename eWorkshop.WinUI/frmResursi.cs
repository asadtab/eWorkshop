using eWorkshop.Model;
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
    public partial class frmResursi : Form
    {
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;

        public readonly ITokenService TokenService;
        public APIService Resurs { get; set; }


        public frmResursi(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            FormControl.OpcijeTabele(dgvResursi);

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            Resurs = new APIService("ApiResource", TokenService);
        }

        private void btnDodajNoviResurs_Click(object sender, EventArgs e)
        {
            frmDodajResurs childForm = ServiceProvider.GetRequiredService<frmDodajResurs>();
            childForm.ShowDialog();
            //FormControl.NovaFormaOpcije(childForm);
        }

        private async void frmResursi_Load(object sender, EventArgs e)
        {
            dgvResursi.DataSource = await Resurs.Get<List<ApiResourceVM>>();
        }
    }
}
