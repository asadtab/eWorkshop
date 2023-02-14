using eWorkshop.Model;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Helper_classes;
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
    public partial class frmListaUredjaja : Form
    {
        public APIService UredjajiService { get; set; } = new APIService("Uredjaj");
        List<UredjajiStateMachine> states = new List<UredjajiStateMachine>();
        public StatusHelper Status { get; set; } = new StatusHelper();
        public FormControl FormControl { get; set; } = new FormControl();
        public frmListaUredjaja()
        {
            InitializeComponent();

            FormControl.OpcijeTabele(dgvLista);
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
            search.Status = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;

            dgvLista.DataSource = await UredjajiService.Get<List<UredjajVM>>(search);
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int evBroj = FormControl.SelektujRedIVratiId(dgvLista, e);

            frmUredjajDetalji childForm = new frmUredjajDetalji(evBroj);
            FormControl.NovaFormaOpcije(childForm);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
