using eWorkshop.Model;
using eWorkshop.WinUI.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI.Report
{
    public partial class frmRadniZadatakIzvjestaj : Form
    {
        private List<RadniZadatakUredjajVM> RadniZadatakAll { get; set; } = new List<RadniZadatakUredjajVM>();
        public List<UredjajVM> Uredjaji { get; set; } = new List<UredjajVM>();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmRadniZadatakIzvjestaj(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        public frmRadniZadatakIzvjestaj(List<RadniZadatakUredjajVM> radniZadatakAll, IServiceProvider serviceProvider, ITokenService tokenService) : this(serviceProvider, tokenService)
        {
            RadniZadatakAll = radniZadatakAll;
            Uredjaji = RadniZadatakAll.Select(x => new UredjajVM()
            {
                UredjajId = x.UredjajId,
                SerijskiBroj = x.UredjajSerijskiBroj,
                Status = x.Uredjaj.Status,
                Koda = x.UredjajKoda,
                Tip = x.Uredjaj.Tip
            }).ToList();
        }

        public frmRadniZadatakIzvjestaj(List<UredjajVM> uredjaji, IServiceProvider serviceProvider, ITokenService tokenService) : this(serviceProvider, tokenService)
        {
            Uredjaji = uredjaji;
        }

        

        private void frmRadniZadatakIzvjestaj_Load(object sender, EventArgs e)
        {
            rptRadniZadatak.LocalReport.ReportEmbeddedResource = "eWorkshop.WinUI.Report.rptRadniZadatak.rdlc";

            var uredjaj = new dsServis.UredjajInfoDataTable();

            foreach (var item in Uredjaji)
            {
                if(item.Status == "ready" || item.Status == "out")
                uredjaj.AddUredjajInfoRow(
                    item.UredjajId.ToString(),
                    item.Koda,
                    item.SerijskiBroj,
                    "",
                    item.TipNaziv);
            }

            var reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Uredjaj";

            reportDataSource.Value = uredjaj;

            rptRadniZadatak.LocalReport.DataSources.Add(reportDataSource);

            rptRadniZadatak.RefreshReport();
        }
    }
}
