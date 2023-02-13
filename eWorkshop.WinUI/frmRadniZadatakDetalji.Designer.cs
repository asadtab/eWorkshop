namespace eWorkshop.WinUI
{
    partial class frmRadniZadatakDetalji
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblProgres = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLokacija = new System.Windows.Forms.Label();
            this.pbProgres = new System.Windows.Forms.ProgressBar();
            this.btnIzvjestaj = new System.Windows.Forms.Button();
            this.btnDodajUredjaj = new System.Windows.Forms.Button();
            this.btnIsporuci = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnZavrsi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvUredjaji = new System.Windows.Forms.DataGridView();
            this.UredjajId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipOpisNaziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerijskiBroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUredjaji)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 177);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.41177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.58823F));
            this.tableLayoutPanel1.Controls.Add(this.lblProgres, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUkupno, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDatum, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNaziv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLokacija, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.91667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.08333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 156);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblProgres
            // 
            this.lblProgres.AutoSize = true;
            this.lblProgres.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProgres.Location = new System.Drawing.Point(185, 128);
            this.lblProgres.Name = "lblProgres";
            this.lblProgres.Size = new System.Drawing.Size(43, 21);
            this.lblProgres.TabIndex = 12;
            this.lblProgres.Text = "label";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(3, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Progres:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(185, 104);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 21);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv:";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUkupno.Location = new System.Drawing.Point(185, 74);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(82, 21);
            this.lblUkupno.TabIndex = 8;
            this.lblUkupno.Text = "lblUkupno";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatum.Location = new System.Drawing.Point(185, 48);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(74, 21);
            this.lblDatum.TabIndex = 7;
            this.lblDatum.Text = "lblDatum";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNaziv.Location = new System.Drawing.Point(185, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(66, 21);
            this.lblNaziv.TabIndex = 5;
            this.lblNaziv.Text = "lblNaziv";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ukupno uređaja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lokacija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum kreiranja";
            // 
            // lblLokacija
            // 
            this.lblLokacija.AutoSize = true;
            this.lblLokacija.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLokacija.Location = new System.Drawing.Point(185, 23);
            this.lblLokacija.Name = "lblLokacija";
            this.lblLokacija.Size = new System.Drawing.Size(83, 21);
            this.lblLokacija.TabIndex = 6;
            this.lblLokacija.Text = "lblLokacija";
            // 
            // pbProgres
            // 
            this.pbProgres.Location = new System.Drawing.Point(6, 21);
            this.pbProgres.Name = "pbProgres";
            this.pbProgres.Size = new System.Drawing.Size(335, 21);
            this.pbProgres.TabIndex = 15;
            // 
            // btnIzvjestaj
            // 
            this.btnIzvjestaj.Location = new System.Drawing.Point(6, 22);
            this.btnIzvjestaj.Name = "btnIzvjestaj";
            this.btnIzvjestaj.Size = new System.Drawing.Size(98, 23);
            this.btnIzvjestaj.TabIndex = 16;
            this.btnIzvjestaj.Text = "Kreiraj izvještaj";
            this.btnIzvjestaj.UseVisualStyleBackColor = true;
            // 
            // btnDodajUredjaj
            // 
            this.btnDodajUredjaj.Location = new System.Drawing.Point(6, 51);
            this.btnDodajUredjaj.Name = "btnDodajUredjaj";
            this.btnDodajUredjaj.Size = new System.Drawing.Size(98, 23);
            this.btnDodajUredjaj.TabIndex = 17;
            this.btnDodajUredjaj.Text = "Dodaj uređaj";
            this.btnDodajUredjaj.UseVisualStyleBackColor = true;
            this.btnDodajUredjaj.Click += new System.EventHandler(this.btnDodajUredjaj_Click);
            // 
            // btnIsporuci
            // 
            this.btnIsporuci.Location = new System.Drawing.Point(6, 80);
            this.btnIsporuci.Name = "btnIsporuci";
            this.btnIsporuci.Size = new System.Drawing.Size(98, 23);
            this.btnIsporuci.TabIndex = 18;
            this.btnIsporuci.Text = "Isporuči";
            this.btnIsporuci.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnZavrsi);
            this.groupBox2.Controls.Add(this.btnIzvjestaj);
            this.groupBox2.Controls.Add(this.btnIsporuci);
            this.groupBox2.Controls.Add(this.btnDodajUredjaj);
            this.groupBox2.Location = new System.Drawing.Point(365, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 140);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opcije";
            // 
            // btnZavrsi
            // 
            this.btnZavrsi.Location = new System.Drawing.Point(6, 109);
            this.btnZavrsi.Name = "btnZavrsi";
            this.btnZavrsi.Size = new System.Drawing.Size(98, 23);
            this.btnZavrsi.TabIndex = 19;
            this.btnZavrsi.Text = "Završi";
            this.btnZavrsi.UseVisualStyleBackColor = true;
            this.btnZavrsi.Click += new System.EventHandler(this.btnZavrsi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbProgres);
            this.groupBox3.Location = new System.Drawing.Point(12, 189);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 48);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progres";
            // 
            // dgvUredjaji
            // 
            this.dgvUredjaji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUredjaji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UredjajId,
            this.TipOpisNaziv,
            this.Koda,
            this.SerijskiBroj,
            this.Status});
            this.dgvUredjaji.Location = new System.Drawing.Point(6, 22);
            this.dgvUredjaji.Name = "dgvUredjaji";
            this.dgvUredjaji.RowTemplate.Height = 25;
            this.dgvUredjaji.Size = new System.Drawing.Size(665, 312);
            this.dgvUredjaji.TabIndex = 21;
            this.dgvUredjaji.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUredjaji_CellContentClick);
            // 
            // UredjajId
            // 
            this.UredjajId.DataPropertyName = "UredjajId";
            this.UredjajId.HeaderText = "Ev. Broj";
            this.UredjajId.Name = "UredjajId";
            this.UredjajId.Width = 50;
            // 
            // TipOpisNaziv
            // 
            this.TipOpisNaziv.DataPropertyName = "TipOpisNaziv";
            this.TipOpisNaziv.HeaderText = "Tip";
            this.TipOpisNaziv.Name = "TipOpisNaziv";
            this.TipOpisNaziv.Width = 200;
            // 
            // Koda
            // 
            this.Koda.DataPropertyName = "Koda";
            this.Koda.HeaderText = "Koda";
            this.Koda.Name = "Koda";
            this.Koda.Width = 150;
            // 
            // SerijskiBroj
            // 
            this.SerijskiBroj.DataPropertyName = "SerijskiBroj";
            this.SerijskiBroj.HeaderText = "SerijskiBroj";
            this.SerijskiBroj.Name = "SerijskiBroj";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 120;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvUredjaji);
            this.groupBox4.Location = new System.Drawing.Point(12, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(677, 340);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lista uređaja";
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.IndianRed;
            this.btnExit.Location = new System.Drawing.Point(659, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 48);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmRadniZadatakDetalji
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(720, 634);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRadniZadatakDetalji";
            this.ShowIcon = false;
            this.Text = "frmRadniZadatakDetalji";
            this.Load += new System.EventHandler(this.frmRadniZadatakDetalji_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUredjaji)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lblUkupno;
        private Label lblDatum;
        private Label lblNaziv;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label lblLokacija;
        private ProgressBar pbProgres;
        private Button btnIzvjestaj;
        private Button btnDodajUredjaj;
        private Button btnIsporuci;
        private GroupBox groupBox2;
        private Button btnZavrsi;
        private GroupBox groupBox3;
        private DataGridView dgvUredjaji;
        private GroupBox groupBox4;
        private Label lblStatus;
        private Label label5;
        private DataGridViewTextBoxColumn UredjajId;
        private DataGridViewTextBoxColumn TipOpisNaziv;
        private DataGridViewTextBoxColumn Koda;
        private DataGridViewTextBoxColumn SerijskiBroj;
        private DataGridViewTextBoxColumn Status;
        private Button btnExit;
        private Label label6;
        private Label lblProgres;
    }
}