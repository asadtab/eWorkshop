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
    public partial class frmNoviRadniZadatak : Form
    {
        public APIService RadniZadatakService { get; set; } = new APIService("RadniZadatak");
        public FormControl FormControl { get; set; } = new FormControl();
        public frmNoviRadniZadatak()
        {
            InitializeComponent();
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            RadniZadatakUpsertRequest request = new RadniZadatakUpsertRequest();
            request.Naziv = lblNaziv.Text;
            request.Datum = DateTime.Now;

            var zadatak = new RadniZadatakVM();

            try
            {
                zadatak = await RadniZadatakService.Post<RadniZadatakVM>(request);
            }
            catch (Exception)
            {

                throw;
            }

            if (zadatak != null)
            {
                MessageBox.Show("Uspjesno je dodan radni zadatak sa nazivom: " + zadatak.Naziv);
                this.Close();

            }
        }


    }
}
