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
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblProgres = new Label();
            label6 = new Label();
            lblStatus = new Label();
            label5 = new Label();
            label1 = new Label();
            lblUkupno = new Label();
            lblDatum = new Label();
            lblNaziv = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblLokacija = new Label();
            pbProgres = new ProgressBar();
            btnIzvjestaj = new Button();
            btnDodajUredjaj = new Button();
            groupBox2 = new GroupBox();
            btnZavrsi = new Button();
            groupBox3 = new GroupBox();
            dgvUredjaji = new DataGridView();
            UredjajId = new DataGridViewTextBoxColumn();
            TipOpisNaziv = new DataGridViewTextBoxColumn();
            Koda = new DataGridViewTextBoxColumn();
            SerijskiBroj = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            groupBox4 = new GroupBox();
            btnExit = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUredjaji).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 177);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.41177F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.58823F));
            tableLayoutPanel1.Controls.Add(lblProgres, 1, 5);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(lblStatus, 1, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblUkupno, 1, 3);
            tableLayoutPanel1.Controls.Add(lblDatum, 1, 2);
            tableLayoutPanel1.Controls.Add(lblNaziv, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(lblLokacija, 1, 1);
            tableLayoutPanel1.Location = new Point(6, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.91667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.08333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(335, 156);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // lblProgres
            // 
            lblProgres.AutoSize = true;
            lblProgres.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblProgres.Location = new Point(185, 128);
            lblProgres.Name = "lblProgres";
            lblProgres.Size = new Size(43, 21);
            lblProgres.TabIndex = 12;
            lblProgres.Text = "label";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 128);
            label6.Name = "label6";
            label6.Size = new Size(67, 21);
            label6.TabIndex = 11;
            label6.Text = "Progres:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(185, 104);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 21);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 104);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 9;
            label5.Text = "Status:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // lblUkupno
            // 
            lblUkupno.AutoSize = true;
            lblUkupno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUkupno.Location = new Point(185, 74);
            lblUkupno.Name = "lblUkupno";
            lblUkupno.Size = new Size(82, 21);
            lblUkupno.TabIndex = 8;
            lblUkupno.Text = "lblUkupno";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatum.Location = new Point(185, 48);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(74, 21);
            lblDatum.TabIndex = 7;
            lblDatum.Text = "lblDatum";
            // 
            // lblNaziv
            // 
            lblNaziv.AutoSize = true;
            lblNaziv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNaziv.Location = new Point(185, 0);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(66, 21);
            lblNaziv.TabIndex = 5;
            lblNaziv.Text = "lblNaziv";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 74);
            label4.Name = "label4";
            label4.Size = new Size(124, 21);
            label4.TabIndex = 3;
            label4.Text = "Ukupno uređaja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 23);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 1;
            label2.Text = "Lokacija:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 48);
            label3.Name = "label3";
            label3.Size = new Size(122, 21);
            label3.TabIndex = 2;
            label3.Text = "Datum kreiranja";
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.Location = new Point(185, 23);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(83, 21);
            lblLokacija.TabIndex = 6;
            lblLokacija.Text = "lblLokacija";
            // 
            // pbProgres
            // 
            pbProgres.Location = new Point(6, 21);
            pbProgres.Name = "pbProgres";
            pbProgres.Size = new Size(335, 21);
            pbProgres.TabIndex = 15;
            // 
            // btnIzvjestaj
            // 
            btnIzvjestaj.Location = new Point(6, 22);
            btnIzvjestaj.Name = "btnIzvjestaj";
            btnIzvjestaj.Size = new Size(98, 23);
            btnIzvjestaj.TabIndex = 16;
            btnIzvjestaj.Text = "Kreiraj izvještaj";
            btnIzvjestaj.UseVisualStyleBackColor = true;
            btnIzvjestaj.Click += btnIzvjestaj_Click;
            // 
            // btnDodajUredjaj
            // 
            btnDodajUredjaj.Location = new Point(6, 51);
            btnDodajUredjaj.Name = "btnDodajUredjaj";
            btnDodajUredjaj.Size = new Size(98, 23);
            btnDodajUredjaj.TabIndex = 17;
            btnDodajUredjaj.Text = "Dodaj uređaj";
            btnDodajUredjaj.UseVisualStyleBackColor = true;
            btnDodajUredjaj.Click += btnDodajUredjaj_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnZavrsi);
            groupBox2.Controls.Add(btnIzvjestaj);
            groupBox2.Controls.Add(btnDodajUredjaj);
            groupBox2.Location = new Point(365, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(110, 140);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Opcije";
            // 
            // btnZavrsi
            // 
            btnZavrsi.Location = new Point(6, 80);
            btnZavrsi.Name = "btnZavrsi";
            btnZavrsi.Size = new Size(98, 23);
            btnZavrsi.TabIndex = 19;
            btnZavrsi.Text = "Završi";
            btnZavrsi.UseVisualStyleBackColor = true;
            btnZavrsi.Click += btnZavrsi_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(pbProgres);
            groupBox3.Location = new Point(12, 189);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(347, 48);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Progres";
            // 
            // dgvUredjaji
            // 
            dgvUredjaji.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUredjaji.Columns.AddRange(new DataGridViewColumn[] { UredjajId, TipOpisNaziv, Koda, SerijskiBroj, Status });
            dgvUredjaji.Location = new Point(6, 22);
            dgvUredjaji.Name = "dgvUredjaji";
            dgvUredjaji.RowTemplate.Height = 25;
            dgvUredjaji.Size = new Size(665, 312);
            dgvUredjaji.TabIndex = 21;
            dgvUredjaji.CellDoubleClick += dgvUredjaji_CellContentClick;
            // 
            // UredjajId
            // 
            UredjajId.DataPropertyName = "UredjajId";
            UredjajId.HeaderText = "Ev. Broj";
            UredjajId.Name = "UredjajId";
            UredjajId.Width = 50;
            // 
            // TipOpisNaziv
            // 
            TipOpisNaziv.DataPropertyName = "TipOpisNaziv";
            TipOpisNaziv.HeaderText = "Tip";
            TipOpisNaziv.Name = "TipOpisNaziv";
            TipOpisNaziv.Width = 200;
            // 
            // Koda
            // 
            Koda.DataPropertyName = "Koda";
            Koda.HeaderText = "Koda";
            Koda.Name = "Koda";
            Koda.Width = 150;
            // 
            // SerijskiBroj
            // 
            SerijskiBroj.DataPropertyName = "SerijskiBroj";
            SerijskiBroj.HeaderText = "SerijskiBroj";
            SerijskiBroj.Name = "SerijskiBroj";
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.Width = 120;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvUredjaji);
            groupBox4.Location = new Point(12, 243);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(677, 340);
            groupBox4.TabIndex = 22;
            groupBox4.TabStop = false;
            groupBox4.Text = "Lista uređaja";
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.IndianRed;
            btnExit.Location = new Point(659, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(49, 48);
            btnExit.TabIndex = 25;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmRadniZadatakDetalji
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(720, 634);
            ControlBox = false;
            Controls.Add(btnExit);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRadniZadatakDetalji";
            ShowIcon = false;
            Text = "frmRadniZadatakDetalji";
            FormClosing += frmRadniZadatakDetalji_FormClosing;
            Load += frmRadniZadatakDetalji_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUredjaji).EndInit();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
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