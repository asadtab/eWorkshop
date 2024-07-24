namespace eWorkshop.WinUI.Report
{
    partial class frmReportViewer
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
            rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // rptViewer
            // 
            rptViewer.Dock = DockStyle.Fill;
            rptViewer.LocalReport.ReportEmbeddedResource = "eWorkshop.WinUI.Report.DokumentacijaServisa.rdlc";
            rptViewer.Location = new Point(0, 0);
            rptViewer.Name = "rptViewer";
            rptViewer.ServerReport.BearerToken = null;
            rptViewer.Size = new Size(800, 450);
            rptViewer.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rptViewer);
            Name = "frmReportViewer";
            Text = "frmReportViewer";
            Load += frmReportViewer_Load;
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}