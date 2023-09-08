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
    }
}
