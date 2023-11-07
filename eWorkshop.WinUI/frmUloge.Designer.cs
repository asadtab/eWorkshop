namespace eWorkshop.WinUI
{
    partial class frmUloge
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
            btnDodajNovogKorisnika = new Button();
            label3 = new Label();
            dgvListaUloga = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnPrikazi = new Button();
            txtNazivUloge = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListaUloga).BeginInit();
            SuspendLayout();
            // 
            // btnDodajNovogKorisnika
            // 
            btnDodajNovogKorisnika.Location = new Point(558, 159);
            btnDodajNovogKorisnika.Margin = new Padding(3, 2, 3, 2);
            btnDodajNovogKorisnika.Name = "btnDodajNovogKorisnika";
            btnDodajNovogKorisnika.Size = new Size(150, 23);
            btnDodajNovogKorisnika.TabIndex = 15;
            btnDodajNovogKorisnika.Text = "Dodaj novu ulogu";
            btnDodajNovogKorisnika.UseVisualStyleBackColor = true;
            btnDodajNovogKorisnika.Click += btnDodajNovogKorisnika_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(229, 39);
            label3.Name = "label3";
            label3.Size = new Size(183, 37);
            label3.TabIndex = 14;
            label3.Text = "Lista korisnika";
            // 
            // dgvListaUloga
            // 
            dgvListaUloga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaUloga.Columns.AddRange(new DataGridViewColumn[] { Name });
            dgvListaUloga.Location = new Point(10, 187);
            dgvListaUloga.Name = "dgvListaUloga";
            dgvListaUloga.RowHeadersWidth = 51;
            dgvListaUloga.RowTemplate.Height = 25;
            dgvListaUloga.Size = new Size(699, 326);
            dgvListaUloga.TabIndex = 13;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Naziv";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.ReadOnly = true;
            Name.Visible = false;
            Name.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 135);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 11;
            label1.Text = "Naziv uloge";
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(168, 158);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(75, 23);
            btnPrikazi.TabIndex = 10;
            btnPrikazi.Text = "Prikazi";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // txtNazivUloge
            // 
            txtNazivUloge.BorderStyle = BorderStyle.FixedSingle;
            txtNazivUloge.Location = new Point(10, 158);
            txtNazivUloge.Name = "txtNazivUloge";
            txtNazivUloge.Size = new Size(152, 23);
            txtNazivUloge.TabIndex = 8;
            // 
            // frmUloge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 553);
            Controls.Add(btnDodajNovogKorisnika);
            Controls.Add(label3);
            Controls.Add(dgvListaUloga);
            Controls.Add(label1);
            Controls.Add(btnPrikazi);
            Controls.Add(txtNazivUloge);
            FormBorderStyle = FormBorderStyle.None;
            //Name = "frmUloge";
            Text = "frmUloge";
            Load += frmUloge_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListaUloga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDodajNovogKorisnika;
        private Label label3;
        private DataGridView dgvListaUloga;
        private DataGridViewTextBoxColumn Name;
        private Label label1;
        private Button btnPrikazi;
        private TextBox txtNazivUloge;
    }
}