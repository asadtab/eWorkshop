using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
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
    public partial class frmListaUredjaja : Form
    {
        public APIService UredjajiService { get; set; }
        List<UredjajiStateMachine> states = new List<UredjajiStateMachine>();
        public StatusHelper Status { get; set; } = new StatusHelper();
        public FormControl FormControl { get; set; } = new FormControl();
        public int SelectedId { get; set; }

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmListaUredjaja(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            FormControl.OpcijeTabele(dgvLista);

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            UredjajiService = new APIService("Uredjaj", TokenService);
        }

        private void populateCmb()
        {
            for (int i = 0; i < Status.nizNaziv.Length; i++)
                states.Add(new UredjajiStateMachine()
                {
                    Id = i,
                    Naziv = Status.nizNaziv[i],
                    Opis = Status.nizOpis[i]
                });
        }

        private async void frmListaUredjaja_Load(object sender, EventArgs e)
        {
            populateCmb();

            cmbStateMachine.DataSource = states;
            cmbStateMachine.ValueMember = "Id";
            cmbStateMachine.DisplayMember = "Opis";
        }

        private async void cmbStateMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            UredjajSearchObject search = new UredjajSearchObject();

            if (cbDeleted.Checked)
            {
                search.isDeleted = true;
            }
            else
            {
                search.isDeleted = false;
            }

            search.Status = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;

            dgvLista.DataSource = await UredjajiService.Get<List<UredjajVM>>(search);
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int evBroj = FormControl.SelektujRedIVratiId(dgvLista, e);

            frmUredjajDetalji childForm = new frmUredjajDetalji(evBroj, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cbDeleted_CheckedChanged(object sender, EventArgs e)
        {
            UredjajSearchObject search = new UredjajSearchObject();

            if (cbDeleted.Checked)
            {
                search.isDeleted = true;
            }
            else
            {
                search.isDeleted = false;
                search.Status = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;
            }

            dgvLista.DataSource = await UredjajiService.Get<List<UredjajVM>>(search);
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int evBroj = 0;

            UredjajSearchObject search = new UredjajSearchObject();

            search.Status = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                evBroj = int.Parse(txtSearch.Text);

            }
            else
            {
                dgvLista.DataSource = await UredjajiService.Get<List<UredjajVM>>(search);
            }

            search.UredjajId = evBroj;

            if (evBroj != 0 && !string.IsNullOrEmpty(txtSearch.Text))
                dgvLista.DataSource = await UredjajiService.Get<List<UredjajVM>>(search);
        }


    }
}
