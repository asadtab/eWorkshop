namespace eWorkshop.WinUI
{
    partial class mdiPocetna
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
            panel1 = new Panel();
            btnStatistika = new Button();
            btnIzvjestaj = new Button();
            pnlUredjaj = new Panel();
            btnLista = new Button();
            btnPrijemUredjaja = new Button();
            button1 = new Button();
            panel4 = new Panel();
            btnMain = new Button();
            tblLayoutPanel = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            radniZadaciToolStripMenuItem = new ToolStripMenuItem();
            detaljiToolStripMenuItem = new ToolStripMenuItem();
            listaRadnihZadatakaToolStripMenuItem = new ToolStripMenuItem();
            korisniciToolStripMenuItem = new ToolStripMenuItem();
            dodajNovogKorisnikaToolStripMenuItem = new ToolStripMenuItem();
            detaljiToolStripMenuItem2 = new ToolStripMenuItem();
            mojRačunToolStripMenuItem = new ToolStripMenuItem();
            odjaviSeToolStripMenuItem = new ToolStripMenuItem();
            magacinToolStripMenuItem = new ToolStripMenuItem();
            komponenteToolStripMenuItem = new ToolStripMenuItem();
            dodajToolStripMenuItem = new ToolStripMenuItem();
            vidiSveToolStripMenuItem = new ToolStripMenuItem();
            uređajToolStripMenuItem = new ToolStripMenuItem();
            administratorToolStripMenuItem = new ToolStripMenuItem();
            klijentiToolStripMenuItem = new ToolStripMenuItem();
            claimTypesToolStripMenuItem = new ToolStripMenuItem();
            ulogeToolStripMenuItem = new ToolStripMenuItem();
            resursiToolStripMenuItem = new ToolStripMenuItem();
            korisniciToolStripMenuItem2 = new ToolStripMenuItem();
            scopesToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            pnlUredjaj.SuspendLayout();
            panel4.SuspendLayout();
            tblLayoutPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(6, 40, 61);
            panel1.Controls.Add(btnStatistika);
            panel1.Controls.Add(btnIzvjestaj);
            panel1.Controls.Add(pnlUredjaj);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(228, 623);
            panel1.TabIndex = 10;
            // 
            // btnStatistika
            // 
            btnStatistika.Dock = DockStyle.Top;
            btnStatistika.FlatAppearance.BorderSize = 0;
            btnStatistika.FlatStyle = FlatStyle.Flat;
            btnStatistika.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnStatistika.ForeColor = SystemColors.ButtonFace;
            btnStatistika.Location = new Point(0, 300);
            btnStatistika.Name = "btnStatistika";
            btnStatistika.Padding = new Padding(10, 0, 0, 0);
            btnStatistika.Size = new Size(228, 44);
            btnStatistika.TabIndex = 7;
            btnStatistika.Text = "Statistika";
            btnStatistika.TextAlign = ContentAlignment.MiddleLeft;
            btnStatistika.UseVisualStyleBackColor = true;
            // 
            // btnIzvjestaj
            // 
            btnIzvjestaj.Dock = DockStyle.Top;
            btnIzvjestaj.FlatAppearance.BorderSize = 0;
            btnIzvjestaj.FlatStyle = FlatStyle.Flat;
            btnIzvjestaj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIzvjestaj.ForeColor = SystemColors.ButtonFace;
            btnIzvjestaj.Location = new Point(0, 256);
            btnIzvjestaj.Name = "btnIzvjestaj";
            btnIzvjestaj.Padding = new Padding(10, 0, 0, 0);
            btnIzvjestaj.Size = new Size(228, 44);
            btnIzvjestaj.TabIndex = 6;
            btnIzvjestaj.Text = "Izvještaj";
            btnIzvjestaj.TextAlign = ContentAlignment.MiddleLeft;
            btnIzvjestaj.UseVisualStyleBackColor = true;
            btnIzvjestaj.Click += btnIzvjestaj_Click;
            // 
            // pnlUredjaj
            // 
            pnlUredjaj.Controls.Add(btnLista);
            pnlUredjaj.Controls.Add(btnPrijemUredjaja);
            pnlUredjaj.Dock = DockStyle.Top;
            pnlUredjaj.Location = new Point(0, 165);
            pnlUredjaj.Name = "pnlUredjaj";
            pnlUredjaj.Size = new Size(228, 91);
            pnlUredjaj.TabIndex = 5;
            // 
            // btnLista
            // 
            btnLista.Dock = DockStyle.Top;
            btnLista.FlatAppearance.BorderSize = 0;
            btnLista.FlatStyle = FlatStyle.Flat;
            btnLista.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista.ForeColor = SystemColors.ButtonFace;
            btnLista.Location = new Point(0, 44);
            btnLista.Name = "btnLista";
            btnLista.Padding = new Padding(30, 0, 0, 0);
            btnLista.Size = new Size(228, 44);
            btnLista.TabIndex = 3;
            btnLista.Text = "Lista uređaja";
            btnLista.TextAlign = ContentAlignment.MiddleLeft;
            btnLista.UseVisualStyleBackColor = true;
            btnLista.Click += btnLista_Click;
            // 
            // btnPrijemUredjaja
            // 
            btnPrijemUredjaja.Dock = DockStyle.Top;
            btnPrijemUredjaja.FlatAppearance.BorderSize = 0;
            btnPrijemUredjaja.FlatStyle = FlatStyle.Flat;
            btnPrijemUredjaja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrijemUredjaja.ForeColor = SystemColors.ButtonFace;
            btnPrijemUredjaja.Location = new Point(0, 0);
            btnPrijemUredjaja.Name = "btnPrijemUredjaja";
            btnPrijemUredjaja.Padding = new Padding(30, 0, 0, 0);
            btnPrijemUredjaja.Size = new Size(228, 44);
            btnPrijemUredjaja.TabIndex = 0;
            btnPrijemUredjaja.Text = "Prijem uređaja";
            btnPrijemUredjaja.TextAlign = ContentAlignment.MiddleLeft;
            btnPrijemUredjaja.UseVisualStyleBackColor = true;
            btnPrijemUredjaja.Click += btnPrijemUredjaja_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(0, 121);
            button1.Name = "button1";
            button1.Padding = new Padding(10, 0, 0, 0);
            button1.Size = new Size(228, 44);
            button1.TabIndex = 0;
            button1.Text = "Uređaji";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources.LogoTab;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(btnMain);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(228, 121);
            panel4.TabIndex = 15;
            // 
            // btnMain
            // 
            btnMain.Location = new Point(71, 59);
            btnMain.Name = "btnMain";
            btnMain.Size = new Size(75, 23);
            btnMain.TabIndex = 0;
            btnMain.Text = "Main";
            btnMain.UseVisualStyleBackColor = true;
            btnMain.Click += btnMain_Click;
            // 
            // tblLayoutPanel
            // 
            tblLayoutPanel.ColumnCount = 2;
            tblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.60241F));
            tblLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.39759F));
            tblLayoutPanel.Controls.Add(menuStrip1, 0, 0);
            tblLayoutPanel.Dock = DockStyle.Top;
            tblLayoutPanel.Location = new Point(228, 0);
            tblLayoutPanel.Name = "tblLayoutPanel";
            tblLayoutPanel.RowCount = 1;
            tblLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLayoutPanel.Size = new Size(727, 24);
            tblLayoutPanel.TabIndex = 12;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { radniZadaciToolStripMenuItem, korisniciToolStripMenuItem, magacinToolStripMenuItem, administratorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(367, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // radniZadaciToolStripMenuItem
            // 
            radniZadaciToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { detaljiToolStripMenuItem, listaRadnihZadatakaToolStripMenuItem });
            radniZadaciToolStripMenuItem.Name = "radniZadaciToolStripMenuItem";
            radniZadaciToolStripMenuItem.Size = new Size(85, 20);
            radniZadaciToolStripMenuItem.Text = "Radni zadaci";
            // 
            // detaljiToolStripMenuItem
            // 
            detaljiToolStripMenuItem.Name = "detaljiToolStripMenuItem";
            detaljiToolStripMenuItem.Size = new Size(184, 22);
            detaljiToolStripMenuItem.Text = "Opcije";
            detaljiToolStripMenuItem.Click += detaljiToolStripMenuItem_Click;
            // 
            // listaRadnihZadatakaToolStripMenuItem
            // 
            listaRadnihZadatakaToolStripMenuItem.Name = "listaRadnihZadatakaToolStripMenuItem";
            listaRadnihZadatakaToolStripMenuItem.Size = new Size(184, 22);
            listaRadnihZadatakaToolStripMenuItem.Text = "Lista radnih zadataka";
            listaRadnihZadatakaToolStripMenuItem.Click += listaRadnihZadatakaToolStripMenuItem_Click;
            // 
            // korisniciToolStripMenuItem
            // 
            korisniciToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajNovogKorisnikaToolStripMenuItem, detaljiToolStripMenuItem2, mojRačunToolStripMenuItem, odjaviSeToolStripMenuItem });
            korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            korisniciToolStripMenuItem.Size = new Size(64, 20);
            korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // dodajNovogKorisnikaToolStripMenuItem
            // 
            dodajNovogKorisnikaToolStripMenuItem.Name = "dodajNovogKorisnikaToolStripMenuItem";
            dodajNovogKorisnikaToolStripMenuItem.Size = new Size(192, 22);
            dodajNovogKorisnikaToolStripMenuItem.Text = "Dodaj novog korisnika";
            dodajNovogKorisnikaToolStripMenuItem.Click += dodajNovogKorisnikaToolStripMenuItem_Click;
            // 
            // detaljiToolStripMenuItem2
            // 
            detaljiToolStripMenuItem2.Name = "detaljiToolStripMenuItem2";
            detaljiToolStripMenuItem2.Size = new Size(192, 22);
            detaljiToolStripMenuItem2.Text = "Detalji";
            // 
            // mojRačunToolStripMenuItem
            // 
            mojRačunToolStripMenuItem.Name = "mojRačunToolStripMenuItem";
            mojRačunToolStripMenuItem.Size = new Size(192, 22);
            mojRačunToolStripMenuItem.Text = "Moj račun";
            mojRačunToolStripMenuItem.Click += mojRačunToolStripMenuItem_Click;
            // 
            // odjaviSeToolStripMenuItem
            // 
            odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            odjaviSeToolStripMenuItem.Size = new Size(192, 22);
            odjaviSeToolStripMenuItem.Text = "Odjavi se";
            odjaviSeToolStripMenuItem.Click += odjaviSeToolStripMenuItem_Click;
            // 
            // magacinToolStripMenuItem
            // 
            magacinToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { komponenteToolStripMenuItem, uređajToolStripMenuItem });
            magacinToolStripMenuItem.Name = "magacinToolStripMenuItem";
            magacinToolStripMenuItem.Size = new Size(65, 20);
            magacinToolStripMenuItem.Text = "Magacin";
            // 
            // komponenteToolStripMenuItem
            // 
            komponenteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dodajToolStripMenuItem, vidiSveToolStripMenuItem });
            komponenteToolStripMenuItem.Name = "komponenteToolStripMenuItem";
            komponenteToolStripMenuItem.Size = new Size(143, 22);
            komponenteToolStripMenuItem.Text = "Komponente";
            // 
            // dodajToolStripMenuItem
            // 
            dodajToolStripMenuItem.Name = "dodajToolStripMenuItem";
            dodajToolStripMenuItem.Size = new Size(114, 22);
            dodajToolStripMenuItem.Text = "Dodaj";
            dodajToolStripMenuItem.Click += dodajToolStripMenuItem_Click;
            // 
            // vidiSveToolStripMenuItem
            // 
            vidiSveToolStripMenuItem.Name = "vidiSveToolStripMenuItem";
            vidiSveToolStripMenuItem.Size = new Size(114, 22);
            vidiSveToolStripMenuItem.Text = "Vidi sve";
            // 
            // uređajToolStripMenuItem
            // 
            uređajToolStripMenuItem.Name = "uređajToolStripMenuItem";
            uređajToolStripMenuItem.Size = new Size(143, 22);
            uređajToolStripMenuItem.Text = "Uređaj";
            // 
            // administratorToolStripMenuItem
            // 
            administratorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { klijentiToolStripMenuItem, claimTypesToolStripMenuItem, ulogeToolStripMenuItem, resursiToolStripMenuItem, korisniciToolStripMenuItem2, scopesToolStripMenuItem });
            administratorToolStripMenuItem.Name = "administratorToolStripMenuItem";
            administratorToolStripMenuItem.Size = new Size(92, 20);
            administratorToolStripMenuItem.Text = "Administrator";
            // 
            // klijentiToolStripMenuItem
            // 
            klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            klijentiToolStripMenuItem.Size = new Size(180, 22);
            klijentiToolStripMenuItem.Text = "Klijenti";
            klijentiToolStripMenuItem.Click += klijentiToolStripMenuItem_Click;
            // 
            // claimTypesToolStripMenuItem
            // 
            claimTypesToolStripMenuItem.Name = "claimTypesToolStripMenuItem";
            claimTypesToolStripMenuItem.Size = new Size(180, 22);
            claimTypesToolStripMenuItem.Text = "ClaimTypes";
            // 
            // ulogeToolStripMenuItem
            // 
            ulogeToolStripMenuItem.Name = "ulogeToolStripMenuItem";
            ulogeToolStripMenuItem.Size = new Size(180, 22);
            ulogeToolStripMenuItem.Text = "Uloge";
            ulogeToolStripMenuItem.Click += ulogeToolStripMenuItem_Click;
            // 
            // resursiToolStripMenuItem
            // 
            resursiToolStripMenuItem.Name = "resursiToolStripMenuItem";
            resursiToolStripMenuItem.Size = new Size(180, 22);
            resursiToolStripMenuItem.Text = "Resursi";
            resursiToolStripMenuItem.Click += resursiToolStripMenuItem_Click;
            // 
            // korisniciToolStripMenuItem2
            // 
            korisniciToolStripMenuItem2.Name = "korisniciToolStripMenuItem2";
            korisniciToolStripMenuItem2.Size = new Size(180, 22);
            korisniciToolStripMenuItem2.Text = "Korisnici";
            korisniciToolStripMenuItem2.Click += korisniciToolStripMenuItem2_Click;
            // 
            // scopesToolStripMenuItem
            // 
            scopesToolStripMenuItem.Name = "scopesToolStripMenuItem";
            scopesToolStripMenuItem.Size = new Size(180, 22);
            scopesToolStripMenuItem.Text = "Scopes";
            // 
            // mdiPocetna
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 623);
            Controls.Add(tblLayoutPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "mdiPocetna";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "mdiPocetna";
            Load += mdiPocetna_Load;
            panel1.ResumeLayout(false);
            pnlUredjaj.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tblLayoutPanel.ResumeLayout(false);
            tblLayoutPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Panel panel1;
        private Button button1;
        private Panel pnlUredjaj;
        private Button btnLista;
        private Button btnPrijemUredjaja;
        private Button btnStatistika;
        private Button btnIzvjestaj;
        private Panel panel4;
        private Button btnMain;
        private TableLayoutPanel tblLayoutPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem radniZadaciToolStripMenuItem;
        private ToolStripMenuItem detaljiToolStripMenuItem;
        private ToolStripMenuItem korisniciToolStripMenuItem;
        private ToolStripMenuItem dodajNovogKorisnikaToolStripMenuItem;
        private ToolStripMenuItem detaljiToolStripMenuItem2;
        private ToolStripMenuItem magacinToolStripMenuItem;
        private ToolStripMenuItem komponenteToolStripMenuItem;
        private ToolStripMenuItem uređajToolStripMenuItem;
        private ToolStripMenuItem dodajToolStripMenuItem;
        private ToolStripMenuItem vidiSveToolStripMenuItem;
        private ToolStripMenuItem listaRadnihZadatakaToolStripMenuItem;
        private ToolStripMenuItem mojRačunToolStripMenuItem;
        private ToolStripMenuItem odjaviSeToolStripMenuItem;
        private ToolStripMenuItem administratorToolStripMenuItem;
        private ToolStripMenuItem klijentiToolStripMenuItem;
        private ToolStripMenuItem claimTypesToolStripMenuItem;
        private ToolStripMenuItem ulogeToolStripMenuItem;
        private ToolStripMenuItem resursiToolStripMenuItem;
        private ToolStripMenuItem korisniciToolStripMenuItem2;
        private ToolStripMenuItem scopesToolStripMenuItem;
    }
}



