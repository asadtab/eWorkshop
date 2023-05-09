using eWorkshop.Model;
using eWorkshop.Model.Helpers;
using eWorkshop.Model.SearchObject;
using eWorkshop.WinUI.Report;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace eWorkshop.WinUI
{
    public partial class frmReportPicker : Form
    {
        public StatusHelper Status { get; set; } = new StatusHelper();
        List<UredjajiStateMachine> states = new List<UredjajiStateMachine>();
        public List<UredjajVM> Uredjaji { get; set; } = new List<UredjajVM>();
        public APIService UredjajiService { get; set; }

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmReportPicker(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;

            UredjajiService = new APIService("Uredjaj", TokenService);
        }

        private void frmReportPicker_Load(object sender, EventArgs e)
        {
            dgvLista.AutoGenerateColumns = false;

            populateCmb();

            cmbStateMachine.DataSource = states;
            cmbStateMachine.ValueMember = "Id";
            cmbStateMachine.DisplayMember = "Opis";
        }

        private void populateCmb()
        {
            for (int i = 0; i < StatusHelper.nizNaziv.Length; i++)
            {
                if (StatusHelper.nizNaziv[i] == "ready" || StatusHelper.nizNaziv[i] == "out")
                {
                    states.Add(new UredjajiStateMachine()
                    {
                        Id = i,
                        Naziv = StatusHelper.nizNaziv[i],
                        Opis = StatusHelper.nizOpis[i]
                    });
                }
            }
        }

        private async void cmbStateMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            UredjajSearchObject search = new UredjajSearchObject();

            search.Status = (cmbStateMachine.SelectedItem as UredjajiStateMachine)?.Naziv;

            var uredjaji = await UredjajiService.Get<List<UredjajVM>>(search);

            dgvLista.DataSource = uredjaji;

            SetSelectedObjects(Uredjaji);
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Check if checkbox cell is clicked
            {
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvLista.Rows[e.RowIndex].Cells["pick"];
                checkbox.Value = !Convert.ToBoolean(checkbox.Value); // Toggle checkbox value

                UredjajVM selectedObject = (UredjajVM)dgvLista.Rows[e.RowIndex].DataBoundItem;

                if (Convert.ToBoolean(checkbox.Value))
                {

                    Uredjaji.Add(selectedObject); // Add to selected objects list
                }
                else
                {

                    Uredjaji.Remove(selectedObject); // Remove from selected objects list
                }
            }
        }

        private void SetSelectedObjects(List<UredjajVM> dataSource)
        {
            foreach (DataGridViewRow row in dgvLista.Rows)
            {
                UredjajVM obj = (UredjajVM)row.DataBoundItem;
                DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)row.Cells["pick"];

                checkbox.Value = dataSource.Contains(obj);
            }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            frmRadniZadatakIzvjestaj childForm = new frmRadniZadatakIzvjestaj(Uredjaji, ServiceProvider, TokenService);
            childForm.Show();
        }
    }
}
