namespace eWorkshop.WinUI
{
    partial class frmKorisnici
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
            txtUserName = new TextBox();
            txtImePrezime = new TextBox();
            btnPrikazi = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvLista = new DataGridView();
            KorisniciID = new DataGridViewTextBoxColumn();
            Ime = new DataGridViewTextBoxColumn();
            Prezime = new DataGridViewTextBoxColumn();
            KorisnickoIme = new DataGridViewTextBoxColumn();
            Telefon = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            label3 = new Label();
            btnDodajNovogKorisnika = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(12, 200);
            txtUserName.Margin = new Padding(3, 4, 3, 4);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(174, 27);
            txtUserName.TabIndex = 0;
            // 
            // txtImePrezime
            // 
            txtImePrezime.BorderStyle = BorderStyle.FixedSingle;
            txtImePrezime.Location = new Point(192, 200);
            txtImePrezime.Margin = new Padding(3, 4, 3, 4);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(174, 27);
            txtImePrezime.TabIndex = 1;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(372, 196);
            btnPrikazi.Margin = new Padding(3, 4, 3, 4);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(86, 31);
            btnPrikazi.TabIndex = 2;
            btnPrikazi.Text = "Prikazi";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 169);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 3;
            label1.Text = "Korisnicko ime";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 169);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 4;
            label2.Text = "Ime i prezime";
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { KorisniciID, Ime, Prezime, KorisnickoIme, Telefon, Email });
            dgvLista.Location = new Point(12, 235);
            dgvLista.Margin = new Padding(3, 4, 3, 4);
            dgvLista.Name = "dgvLista";
            dgvLista.RowHeadersWidth = 51;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.Size = new Size(799, 434);
            dgvLista.TabIndex = 5;
            dgvLista.CellDoubleClick += dgvLista_CellContentClick;
            // 
            // KorisniciID
            // 
            KorisniciID.DataPropertyName = "KorisniciID";
            KorisniciID.HeaderText = "KorisnikID";
            KorisniciID.MinimumWidth = 6;
            KorisniciID.Name = "KorisniciID";
            KorisniciID.ReadOnly = true;
            KorisniciID.Visible = false;
            KorisniciID.Width = 125;
            // 
            // Ime
            // 
            Ime.DataPropertyName = "Ime";
            Ime.HeaderText = "Ime";
            Ime.MinimumWidth = 6;
            Ime.Name = "Ime";
            Ime.Width = 125;
            // 
            // Prezime
            // 
            Prezime.DataPropertyName = "Prezime";
            Prezime.HeaderText = "Prezime";
            Prezime.MinimumWidth = 6;
            Prezime.Name = "Prezime";
            Prezime.Width = 125;
            // 
            // KorisnickoIme
            // 
            KorisnickoIme.DataPropertyName = "KorisnickoIme";
            KorisnickoIme.HeaderText = "Korisničko ime";
            KorisnickoIme.MinimumWidth = 6;
            KorisnickoIme.Name = "KorisnickoIme";
            KorisnickoIme.Width = 125;
            // 
            // Telefon
            // 
            Telefon.DataPropertyName = "Telefon";
            Telefon.HeaderText = "Telefon";
            Telefon.MinimumWidth = 6;
            Telefon.Name = "Telefon";
            Telefon.Width = 125;
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 125;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(262, 37);
            label3.Name = "label3";
            label3.Size = new Size(228, 46);
            label3.TabIndex = 6;
            label3.Text = "Lista korisnika";
            // 
            // btnDodajNovogKorisnika
            // 
            btnDodajNovogKorisnika.Location = new Point(640, 198);
            btnDodajNovogKorisnika.Name = "btnDodajNovogKorisnika";
            btnDodajNovogKorisnika.Size = new Size(171, 29);
            btnDodajNovogKorisnika.TabIndex = 7;
            btnDodajNovogKorisnika.Text = "Dodaj novog korisnika";
            btnDodajNovogKorisnika.UseVisualStyleBackColor = true;
            btnDodajNovogKorisnika.Click += btnDodajNovogKorisnika_Click;
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 737);
            Controls.Add(btnDodajNovogKorisnika);
            Controls.Add(label3);
            Controls.Add(dgvLista);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrikazi);
            Controls.Add(txtImePrezime);
            Controls.Add(txtUserName);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmKorisnici";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmKorisnici";
            Load += frmKorisnici_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private TextBox txtImePrezime;
        private Button btnPrikazi;
        private Label label1;
        private Label label2;
        private DataGridView dgvLista;
        private Label label3;
        private DataGridViewTextBoxColumn KorisniciID;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn KorisnickoIme;
        private DataGridViewTextBoxColumn Telefon;
        private DataGridViewTextBoxColumn Email;
        private Button btnDodajNovogKorisnika;
    }
}