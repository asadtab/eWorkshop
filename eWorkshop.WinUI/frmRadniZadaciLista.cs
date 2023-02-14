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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eWorkshop.WinUI
{
    public partial class frmRadniZadaciLista : Form
    {
        public APIService RadniZadaciService { get; set; } = new APIService("RadniZadatak");
        public APIService RadniZadatakUredjajService { get; set; } = new APIService("RadniZadatakUredjaj");
        public FormControl FormControl { get; set; } = new FormControl();
        public StatusHelper Status{ get; set; } = new StatusHelper();

        public frmRadniZadaciLista()
        {
            InitializeComponent();
        }

        private void frmRadniZadaciLista_Load(object sender, EventArgs e)
        {
            PopulateTable();
            PopulateCmb();
        }

        private void PopulateCmb()
        {
            List<UredjajiStateMachine> states = new List<UredjajiStateMachine>();

            for (int i = 0; i < Status.nizNazivZadatak.Length; i++)
                states.Add(new UredjajiStateMachine()
                {
                    Id = i,
                    Naziv = Status.nizNazivZadatak[i],
                    Opis = Status.nizOpisZadatak[i]
                });

            cmbStateMachine.DataSource = states;
            cmbStateMachine.ValueMember = "Id";
            cmbStateMachine.DisplayMember = "Opis";
        }

        

        private async void PopulateTable()
        {
            FormControl.OpcijeTabele(dgvLista);
            FormControl.OpcijeTabele(dgvUredjaji);
            

            var zadaci = await RadniZadaciService.Get<List<RadniZadatakVM>>();

            dgvLista.DataSource = zadaci;
            
        }

        private async void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int zadatakId = FormControl.SelektujRedIVratiId(dgvLista, e);

            RadniZadatakUredjajSearchObject zadatakSearch = new RadniZadatakUredjajSearchObject();
            zadatakSearch.RadniZadatakId = zadatakId;

            var uredjaji = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(zadatakSearch);

            dgvUredjaji.DataSource = uredjaji;
        }
    }
}
