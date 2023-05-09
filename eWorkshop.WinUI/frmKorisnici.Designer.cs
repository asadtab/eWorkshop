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
            Ime = new DataGridViewTextBoxColumn();
            Prezime = new DataGridViewTextBoxColumn();
            KorisnickoIme = new DataGridViewTextBoxColumn();
            Telefon = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            NaziviUloga = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(12, 63);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(229, 23);
            txtUserName.TabIndex = 0;
            // 
            // txtImePrezime
            // 
            txtImePrezime.BorderStyle = BorderStyle.FixedSingle;
            txtImePrezime.Location = new Point(247, 63);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(229, 23);
            txtImePrezime.TabIndex = 1;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(482, 63);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(75, 23);
            btnPrikazi.TabIndex = 2;
            btnPrikazi.Text = "Prikazi";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 3;
            label1.Text = "Korisnicko ime";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(247, 45);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "Ime i prezime";
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { Ime, Prezime, KorisnickoIme, Telefon, Email, NaziviUloga });
            dgvLista.Location = new Point(12, 122);
            dgvLista.Name = "dgvLista";
            dgvLista.RowTemplate.Height = 25;
            dgvLista.Size = new Size(776, 316);
            dgvLista.TabIndex = 5;
            // 
            // Ime
            // 
            Ime.DataPropertyName = "Ime";
            Ime.HeaderText = "Ime";
            Ime.Name = "Ime";
            // 
            // Prezime
            // 
            Prezime.DataPropertyName = "Prezime";
            Prezime.HeaderText = "Prezime";
            Prezime.Name = "Prezime";
            // 
            // KorisnickoIme
            // 
            KorisnickoIme.DataPropertyName = "KorisnickoIme";
            KorisnickoIme.HeaderText = "Korisničko ime";
            KorisnickoIme.Name = "KorisnickoIme";
            // 
            // Telefon
            // 
            Telefon.DataPropertyName = "Telefon";
            Telefon.HeaderText = "Telefon";
            Telefon.Name = "Telefon";
            // 
            // Email
            // 
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            // 
            // NaziviUloga
            // 
            NaziviUloga.DataPropertyName = "NaziviUloga";
            NaziviUloga.HeaderText = "Nazivi uloga";
            NaziviUloga.Name = "NaziviUloga";
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvLista);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrikazi);
            Controls.Add(txtImePrezime);
            Controls.Add(txtUserName);
            Name = "frmKorisnici";
            Text = "frmKorisnici";
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
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn KorisnickoIme;
        private DataGridViewTextBoxColumn Telefon;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn NaziviUloga;
    }
}