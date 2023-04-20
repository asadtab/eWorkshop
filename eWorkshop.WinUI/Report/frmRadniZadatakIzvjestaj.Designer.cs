namespace eWorkshop.WinUI.Report
{
    partial class frmRadniZadatakIzvjestaj
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rptRadniZadatak = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // rptRadniZadatak
            // 
            rptRadniZadatak.Dock = DockStyle.Fill;
            rptRadniZadatak.LocalReport.ReportEmbeddedResource = "eWorkshop.WinUI.Report.rptRadniZadatak.rdlc";
            rptRadniZadatak.Location = new Point(0, 0);
            rptRadniZadatak.Name = "rptRadniZadatak";
            rptRadniZadatak.ServerReport.BearerToken = null;
            rptRadniZadatak.Size = new Size(800, 450);
            rptRadniZadatak.TabIndex = 0;
            // 
            // frmRadniZadatakIzvjestaj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rptRadniZadatak);
            Name = "frmRadniZadatakIzvjestaj";
            Text = "frmRadniZadatakIzvjestaj";
            Load += frmRadniZadatakIzvjestaj_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptRadniZadatak;
    }
}