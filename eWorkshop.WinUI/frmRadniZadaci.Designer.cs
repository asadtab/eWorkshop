namespace eWorkshop.WinUI
{
    partial class frmRadniZadaci
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
            this.lbUredjaji = new System.Windows.Forms.ListBox();
            this.cmbUredjaji = new System.Windows.Forms.ComboBox();
            this.gbRadniZadaci = new System.Windows.Forms.GroupBox();
            this.lbRadniZadatakUredjaj = new System.Windows.Forms.ListBox();
            this.cmbRadniZadaci = new System.Windows.Forms.ComboBox();
            this.btnIzbaci = new System.Windows.Forms.Button();
            this.btnRadniZadatakDetalji = new System.Windows.Forms.Button();
            this.btnNoviRadniZadatak = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.lblStanje = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbRadniZadaci.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbUredjaji);
            this.groupBox1.Controls.Add(this.cmbUredjaji);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uređaji";
            // 
            // lbUredjaji
            // 
            this.lbUredjaji.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUredjaji.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbUredjaji.FormattingEnabled = true;
            this.lbUredjaji.ItemHeight = 15;
            this.lbUredjaji.Location = new System.Drawing.Point(3, 19);
            this.lbUredjaji.Name = "lbUredjaji";
            this.lbUredjaji.Size = new System.Drawing.Size(193, 255);
            this.lbUredjaji.TabIndex = 0;
            this.lbUredjaji.DoubleClick += new System.EventHandler(this.lbUredjaji_SelectedIndexChanged);
            // 
            // cmbUredjaji
            // 
            this.cmbUredjaji.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbUredjaji.FormattingEnabled = true;
            this.cmbUredjaji.Location = new System.Drawing.Point(3, 284);
            this.cmbUredjaji.Name = "cmbUredjaji";
            this.cmbUredjaji.Size = new System.Drawing.Size(193, 23);
            this.cmbUredjaji.TabIndex = 7;
            // 
            // gbRadniZadaci
            // 
            this.gbRadniZadaci.Controls.Add(this.lbRadniZadatakUredjaj);
            this.gbRadniZadaci.Controls.Add(this.cmbRadniZadaci);
            this.gbRadniZadaci.Location = new System.Drawing.Point(298, 108);
            this.gbRadniZadaci.Name = "gbRadniZadaci";
            this.gbRadniZadaci.Size = new System.Drawing.Size(199, 310);
            this.gbRadniZadaci.TabIndex = 1;
            this.gbRadniZadaci.TabStop = false;
            this.gbRadniZadaci.Text = "Radni zadatak";
            // 
            // lbRadniZadatakUredjaj
            // 
            this.lbRadniZadatakUredjaj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbRadniZadatakUredjaj.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbRadniZadatakUredjaj.FormattingEnabled = true;
            this.lbRadniZadatakUredjaj.ItemHeight = 15;
            this.lbRadniZadatakUredjaj.Location = new System.Drawing.Point(3, 19);
            this.lbRadniZadatakUredjaj.Name = "lbRadniZadatakUredjaj";
            this.lbRadniZadatakUredjaj.Size = new System.Drawing.Size(193, 255);
            this.lbRadniZadatakUredjaj.TabIndex = 0;
            this.lbRadniZadatakUredjaj.DoubleClick += new System.EventHandler(this.lbRadniZadatakUredjaj_SelectedIndexChanged);
            // 
            // cmbRadniZadaci
            // 
            this.cmbRadniZadaci.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbRadniZadaci.FormattingEnabled = true;
            this.cmbRadniZadaci.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbRadniZadaci.Location = new System.Drawing.Point(3, 284);
            this.cmbRadniZadaci.Name = "cmbRadniZadaci";
            this.cmbRadniZadaci.Size = new System.Drawing.Size(193, 23);
            this.cmbRadniZadaci.TabIndex = 3;
            this.cmbRadniZadaci.Tag = "sadasd";
            this.cmbRadniZadaci.Text = "--Select--";
            this.cmbRadniZadaci.SelectedIndexChanged += new System.EventHandler(this.cmbRadniZadaci_SelectedIndexChanged);
            // 
            // btnIzbaci
            // 
            this.btnIzbaci.Location = new System.Drawing.Point(217, 395);
            this.btnIzbaci.Name = "btnIzbaci";
            this.btnIzbaci.Size = new System.Drawing.Size(75, 23);
            this.btnIzbaci.TabIndex = 2;
            this.btnIzbaci.Text = "<< Izbaci";
            this.btnIzbaci.UseVisualStyleBackColor = true;
            this.btnIzbaci.Click += new System.EventHandler(this.btnIzbaci_Click);
            // 
            // btnRadniZadatakDetalji
            // 
            this.btnRadniZadatakDetalji.Location = new System.Drawing.Point(506, 395);
            this.btnRadniZadatakDetalji.Name = "btnRadniZadatakDetalji";
            this.btnRadniZadatakDetalji.Size = new System.Drawing.Size(143, 23);
            this.btnRadniZadatakDetalji.TabIndex = 4;
            this.btnRadniZadatakDetalji.Text = "Detalji";
            this.btnRadniZadatakDetalji.UseVisualStyleBackColor = true;
            this.btnRadniZadatakDetalji.Click += new System.EventHandler(this.btnRadniZadatakDetalji_Click);
            // 
            // btnNoviRadniZadatak
            // 
            this.btnNoviRadniZadatak.Location = new System.Drawing.Point(506, 366);
            this.btnNoviRadniZadatak.Name = "btnNoviRadniZadatak";
            this.btnNoviRadniZadatak.Size = new System.Drawing.Size(143, 23);
            this.btnNoviRadniZadatak.TabIndex = 5;
            this.btnNoviRadniZadatak.Text = "Novi radni zadatak";
            this.btnNoviRadniZadatak.UseVisualStyleBackColor = true;
            this.btnNoviRadniZadatak.Click += new System.EventHandler(this.btnNoviRadniZadatak_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(217, 366);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj >>";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv: ";
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNaziv.Location = new System.Drawing.Point(105, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(38, 15);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Datum:";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatum.Location = new System.Drawing.Point(105, 35);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(38, 15);
            this.lblDatum.TabIndex = 3;
            this.lblDatum.Text = "label4";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.83871F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.16129F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDatum, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNaziv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUkupno, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStanje, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(186, 126);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stanje:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ukupno uređaja:";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUkupno.Location = new System.Drawing.Point(105, 103);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(38, 15);
            this.lblUkupno.TabIndex = 7;
            this.lblUkupno.Text = "label8";
            // 
            // lblStanje
            // 
            this.lblStanje.AutoSize = true;
            this.lblStanje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStanje.Location = new System.Drawing.Point(105, 70);
            this.lblStanje.Name = "lblStanje";
            this.lblStanje.Size = new System.Drawing.Size(38, 15);
            this.lblStanje.TabIndex = 5;
            this.lblStanje.Text = "label6";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(503, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 154);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
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
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmRadniZadaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 430);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnNoviRadniZadatak);
            this.Controls.Add(this.btnRadniZadatakDetalji);
            this.Controls.Add(this.btnIzbaci);
            this.Controls.Add(this.gbRadniZadaci);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRadniZadaci";
            this.Load += new System.EventHandler(this.frmRadniZadaci_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbRadniZadaci.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lbUredjaji;
        private ComboBox cmbUredjaji;
        private GroupBox gbRadniZadaci;
        private ListBox lbRadniZadatakUredjaj;
        private ComboBox cmbRadniZadaci;
        private Button btnIzbaci;
        private Button btnRadniZadatakDetalji;
        private Button btnNoviRadniZadatak;
        private Button btnDodaj;
        private Label label1;
        private Label lblNaziv;
        private Label label3;
        private Label lblDatum;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Label label7;
        private Label lblStanje;
        private Label lblUkupno;
        private GroupBox groupBox3;
        private Button btnExit;
    }
}