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
        public APIService RadniZadaciService { get; set; } 
        public APIService RadniZadatakUredjajService { get; set; }
        public FormControl FormControl { get; set; } = new FormControl();
        public StatusHelper Status { get; set; } = new StatusHelper();
        public List<RadniZadatakUredjajVM> ZadatakUredjaji { get; set; } = new List<RadniZadatakUredjajVM>();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmRadniZadaciLista(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            apiCalls();
        }

        private void apiCalls()
        {
            RadniZadaciService = new APIService("RadniZadatak", TokenService);
            RadniZadatakUredjajService = new APIService("RadniZadatakUredjaj", TokenService);
        }

        private void frmRadniZadaciLista_Load(object sender, EventArgs e)
        {
            PopulateTable();
            PopulateCmb();
            PopulateInfo();
        }

        private void PopulateInfo()
        {
            //lblZadatak.Text = ZadatakUredjaji[0].RadniZadatak.Naziv;
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
        }

        private async void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int zadatakId = FormControl.SelektujRedIVratiId(dgvLista, e);

            RadniZadatakUredjajSearchObject zadatakSearch = new RadniZadatakUredjajSearchObject();
            zadatakSearch.RadniZadatakId = zadatakId;

            ZadatakUredjaji = await RadniZadatakUredjajService.Get<List<RadniZadatakUredjajVM>>(zadatakSearch);
            var uredjaji = ZadatakUredjaji.Select(x => x.Uredjaj).ToList();

            for (int  i = 0;  i < uredjaji.Count;  i++)
                uredjaji[i].Status = Status.ProvjeraStatusa(uredjaji[i].Status, Status.nizNaziv, Status.nizOpis);
            

            dgvUredjaji.DataSource = uredjaji;
        }

        private async void cmbStateMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadniZadatakSearchObject search = new RadniZadatakSearchObject();
            search.StateMachine = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;

            dgvLista.DataSource = await RadniZadaciService.Get<List<RadniZadatakVM>>(search);
        }

        private void dgvUredjaji_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int UredjajId = FormControl.SelektujRedIVratiId(dgvUredjaji, e);

            frmUredjajDetalji forma = new frmUredjajDetalji(UredjajId, ServiceProvider, TokenService);
            FormControl.NovaFormaOpcije(forma);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
