namespace eWorkshop.WinUI.UserControls
{
    partial class RadniZadaciUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbZadatak = new System.Windows.Forms.GroupBox();
            this.cmsDesniKlik = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbUredjaji = new System.Windows.Forms.ListBox();
            this.pbProcenatZavrsenihUredjaja = new System.Windows.Forms.ProgressBar();
            this.gbZadatak.SuspendLayout();
            this.cmsDesniKlik.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbZadatak
            // 
            this.gbZadatak.BackColor = System.Drawing.Color.Transparent;
            this.gbZadatak.ContextMenuStrip = this.cmsDesniKlik;
            this.gbZadatak.Controls.Add(this.lbUredjaji);
            this.gbZadatak.Controls.Add(this.pbProcenatZavrsenihUredjaja);
            this.gbZadatak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbZadatak.Location = new System.Drawing.Point(0, 0);
            this.gbZadatak.Name = "gbZadatak";
            this.gbZadatak.Size = new System.Drawing.Size(130, 202);
            this.gbZadatak.TabIndex = 1;
            this.gbZadatak.TabStop = false;
            this.gbZadatak.Text = "groupBox1";
            // 
            // cmsDesniKlik
            // 
            this.cmsDesniKlik.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdaToolStripMenuItem,
            this.asdToolStripMenuItem});
            this.cmsDesniKlik.Name = "contextMenuStrip1";
            this.cmsDesniKlik.Size = new System.Drawing.Size(99, 48);
            // 
            // asdaToolStripMenuItem
            // 
            this.asdaToolStripMenuItem.Name = "asdaToolStripMenuItem";
            this.asdaToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.asdaToolStripMenuItem.Text = "asda";
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.asdToolStripMenuItem.Text = "asd";
            // 
            // lbUredjaji
            // 
            this.lbUredjaji.BackColor = System.Drawing.SystemColors.Control;
            this.lbUredjaji.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUredjaji.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUredjaji.FormattingEnabled = true;
            this.lbUredjaji.ItemHeight = 15;
            this.lbUredjaji.Location = new System.Drawing.Point(3, 19);
            this.lbUredjaji.Name = "lbUredjaji";
            this.lbUredjaji.Size = new System.Drawing.Size(124, 150);
            this.lbUredjaji.TabIndex = 1;
            // 
            // pbProcenatZavrsenihUredjaja
            // 
            this.pbProcenatZavrsenihUredjaja.Location = new System.Drawing.Point(0, 179);
            this.pbProcenatZavrsenihUredjaja.Name = "pbProcenatZavrsenihUredjaja";
            this.pbProcenatZavrsenihUredjaja.Size = new System.Drawing.Size(130, 23);
            this.pbProcenatZavrsenihUredjaja.TabIndex = 0;
            // 
            // RadniZadaciUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsDesniKlik;
            this.Controls.Add(this.gbZadatak);
            this.Name = "RadniZadaciUserControl";
            this.Size = new System.Drawing.Size(130, 202);
            this.gbZadatak.ResumeLayout(false);
            this.cmsDesniKlik.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gbZadatak;
        private ProgressBar pbProcenatZavrsenihUredjaja;
        private ListBox lbUredjaji;
        private ContextMenuStrip cmsDesniKlik;
        private ToolStripMenuItem asdaToolStripMenuItem;
        private ToolStripMenuItem asdToolStripMenuItem;
    }
}
