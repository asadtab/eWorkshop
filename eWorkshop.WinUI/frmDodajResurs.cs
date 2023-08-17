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

namespace eWorkshop.WinUI
{
    public partial class frmDodajResurs : Form
    {

        public readonly IServiceProvider ServiceProvider;

        public readonly ITokenService TokenService;
        public APIService Scopes { get; set; }
        public APIService Resurs { get; set; }


        public frmDodajResurs(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            Scopes = new APIService("Scopes", TokenService);
            Resurs = new APIService("ApiResource", TokenService);
        }

        private async void frmDodajResurs_Load(object sender, EventArgs e)
        {
                var scopes = await Scopes.Get<List<ScopesVM>>();

                foreach (var item in scopes)
                {
                    clbScopes.Items.Add(item.DisplayName + " - " + item.Name);
                }
          
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            var request = new ApiResourceUpsertRequest();

            request.Name = txtResourceName.Text;
            request.DisplayName = txtResourceDescription.Text;
            request.Description = txtResourceDescription.Text;

            var resurs = await Resurs.Post<ApiResourceVM>(request);

            if(resurs is not null)
            {
                Close();
            }

        }
    }
}
