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
            NormalizedUserName = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            label3 = new Label();
            btnDodajNovogKorisnika = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(10, 150);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(152, 23);
            txtUserName.TabIndex = 0;
            // 
            // txtImePrezime
            // 
            txtImePrezime.BorderStyle = BorderStyle.FixedSingle;
            txtImePrezime.Location = new Point(168, 150);
            txtImePrezime.Name = "txtImePrezime";
            txtImePrezime.Size = new Size(152, 23);
            txtImePrezime.TabIndex = 1;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(326, 147);
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
            label1.Location = new Point(10, 127);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 3;
            label1.Text = "Korisnicko ime";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 127);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 4;
            label2.Text = "Ime i prezime";
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { NormalizedUserName, Email });
            dgvLista.Location = new Point(10, 176);
            dgvLista.Name = "dgvLista";
            dgvLista.RowHeadersWidth = 51;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.Size = new Size(699, 326);
            dgvLista.TabIndex = 5;
            dgvLista.CellContentClick += dgvLista_CellContentClick_1;
            dgvLista.CellDoubleClick += dgvLista_CellContentClick;
            // 
            // NormalizedUserName
            // 
            NormalizedUserName.DataPropertyName = "NormalizedUserName";
            NormalizedUserName.HeaderText = "Korisničko ime";
            NormalizedUserName.Name = "NormalizedUserName";
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
            label3.Location = new Point(229, 28);
            label3.Name = "label3";
            label3.Size = new Size(183, 37);
            label3.TabIndex = 6;
            label3.Text = "Lista korisnika";
            // 
            // btnDodajNovogKorisnika
            // 
            btnDodajNovogKorisnika.Location = new Point(560, 148);
            btnDodajNovogKorisnika.Margin = new Padding(3, 2, 3, 2);
            btnDodajNovogKorisnika.Name = "btnDodajNovogKorisnika";
            btnDodajNovogKorisnika.Size = new Size(150, 22);
            btnDodajNovogKorisnika.TabIndex = 7;
            btnDodajNovogKorisnika.Text = "Dodaj novog korisnika";
            btnDodajNovogKorisnika.UseVisualStyleBackColor = true;
            btnDodajNovogKorisnika.Click += btnDodajNovogKorisnika_Click;
            // 
            // frmKorisnici
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 553);
            Controls.Add(btnDodajNovogKorisnika);
            Controls.Add(label3);
            Controls.Add(dgvLista);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrikazi);
            Controls.Add(txtImePrezime);
            Controls.Add(txtUserName);
            FormBorderStyle = FormBorderStyle.None;
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
        private Button btnDodajNovogKorisnika;
        private DataGridViewTextBoxColumn NormalizedUserName;
        private DataGridViewTextBoxColumn Email;
    }
}