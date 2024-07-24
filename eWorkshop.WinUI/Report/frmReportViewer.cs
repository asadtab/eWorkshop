using eWorkshop.WinUI.Service;
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
    public partial class frmReportViewer : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmReportViewer(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            //var uredjajDataTable = new dsServis.UredjajInfoDataTable;

            var uredjaj = new dsServis.UredjajInfoDataTable();
            var servis = new dsServis.ServisInfoDataTable();
            var uposleni = new dsServis.UposleniInfoDataTable();



            for (int i = 0; i < 2; i++)
            {
                uposleni.AddUposleniInfoRow("Asad Tabak", "Enes", "Someone", "Again Someone");

                servis.AddServisInfoRow("pocetak", "zavrsetak", "broj radn", "konto broj");

                uredjaj.AddUredjajInfoRow("253",
                "koda",
                "serijskibroj",
                "1971",
                "KRS");
            }

            var infoDataSource = new ReportDataSource();
            infoDataSource.Name = "ServisInfo";
            infoDataSource.Value = servis;

            var uposleniDataSource = new ReportDataSource();
            uposleniDataSource.Name = "Uposleni";
            uposleniDataSource.Value = uposleni;

            var reportDataSource = new ReportDataSource();
            reportDataSource.Name = "Uredjaj";

            reportDataSource.Value = uredjaj;

            rptViewer.LocalReport.DataSources.Add(reportDataSource);
            rptViewer.LocalReport.DataSources.Add(infoDataSource);
            rptViewer.LocalReport.DataSources.Add(uposleniDataSource);
            
            

            rptViewer.RefreshReport();
        }
    }
}
