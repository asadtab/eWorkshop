namespace eWorkshop.WinUI
{
    partial class frmPrijemUredjaja
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
            txtKoda = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtSerijskiBroj = new TextBox();
            label3 = new Label();
            txtIzdanje = new TextBox();
            txtOpisKodPrijema = new RichTextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnGenerisiSerijskiBroj = new Button();
            btnNoviTipUredjaja = new Button();
            txtEvBroj = new TextBox();
            label7 = new Label();
            btnRegistruj = new Button();
            cmbTipUredjaja = new ComboBox();
            label9 = new Label();
            btnExit = new Button();
            cmbLokacija = new ComboBox();
            SuspendLayout();
            // 
            // txtKoda
            // 
            txtKoda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtKoda.Location = new Point(259, 142);
            txtKoda.Name = "txtKoda";
            txtKoda.Size = new Size(235, 29);
            txtKoda.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(259, 124);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 1;
            label1.Text = "Koda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 174);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Serijski broj";
            // 
            // txtSerijskiBroj
            // 
            txtSerijskiBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSerijskiBroj.Location = new Point(12, 192);
            txtSerijskiBroj.Name = "txtSerijskiBroj";
            txtSerijskiBroj.Size = new Size(235, 29);
            txtSerijskiBroj.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(259, 174);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Izdanje";
            // 
            // txtIzdanje
            // 
            txtIzdanje.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtIzdanje.Location = new Point(259, 192);
            txtIzdanje.Name = "txtIzdanje";
            txtIzdanje.Size = new Size(235, 29);
            txtIzdanje.TabIndex = 4;
            // 
            // txtOpisKodPrijema
            // 
            txtOpisKodPrijema.BorderStyle = BorderStyle.FixedSingle;
            txtOpisKodPrijema.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOpisKodPrijema.Location = new Point(12, 292);
            txtOpisKodPrijema.Name = "txtOpisKodPrijema";
            txtOpisKodPrijema.Size = new Size(482, 96);
            txtOpisKodPrijema.TabIndex = 6;
            txtOpisKodPrijema.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 274);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 7;
            label4.Text = "Opis uređaja kod prijema";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 124);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 9;
            label5.Text = "Tip";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(176, 34);
            label6.Name = "label6";
            label6.Size = new Size(202, 37);
            label6.TabIndex = 10;
            label6.Text = "Registruj uređaj";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnGenerisiSerijskiBroj
            // 
            btnGenerisiSerijskiBroj.Location = new Point(555, 192);
            btnGenerisiSerijskiBroj.Name = "btnGenerisiSerijskiBroj";
            btnGenerisiSerijskiBroj.Size = new Size(132, 29);
            btnGenerisiSerijskiBroj.TabIndex = 11;
            btnGenerisiSerijskiBroj.Text = "Generiši serijski broj";
            btnGenerisiSerijskiBroj.UseVisualStyleBackColor = true;
            btnGenerisiSerijskiBroj.Click += btnGenerisiSerijskiBroj_Click;
            // 
            // btnNoviTipUredjaja
            // 
            btnNoviTipUredjaja.Location = new Point(555, 142);
            btnNoviTipUredjaja.Name = "btnNoviTipUredjaja";
            btnNoviTipUredjaja.Size = new Size(132, 29);
            btnNoviTipUredjaja.TabIndex = 12;
            btnNoviTipUredjaja.Text = "Novi tip uređaja";
            btnNoviTipUredjaja.UseVisualStyleBackColor = true;
            btnNoviTipUredjaja.Click += btnNoviTipUredjaja_Click;
            // 
            // txtEvBroj
            // 
            txtEvBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEvBroj.Location = new Point(555, 242);
            txtEvBroj.Name = "txtEvBroj";
            txtEvBroj.ReadOnly = true;
            txtEvBroj.Size = new Size(132, 29);
            txtEvBroj.TabIndex = 13;
            txtEvBroj.Text = "345";
            txtEvBroj.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(555, 224);
            label7.Name = "label7";
            label7.Size = new Size(145, 15);
            label7.TabIndex = 14;
            label7.Text = "Posljednji ev. broj uređaja:";
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(555, 292);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(132, 29);
            btnRegistruj.TabIndex = 15;
            btnRegistruj.Text = "Sačuvaj";
            btnRegistruj.UseVisualStyleBackColor = true;
            btnRegistruj.Click += btnRegistruj_Click;
            // 
            // cmbTipUredjaja
            // 
            cmbTipUredjaja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipUredjaja.FormattingEnabled = true;
            cmbTipUredjaja.Location = new Point(12, 142);
            cmbTipUredjaja.Name = "cmbTipUredjaja";
            cmbTipUredjaja.Size = new Size(235, 29);
            cmbTipUredjaja.TabIndex = 16;
            cmbTipUredjaja.Text = "Odaberi tip uređaja";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 224);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 20;
            label9.Text = "Lokacija";
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
            btnExit.TabIndex = 22;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cmbLokacija
            // 
            cmbLokacija.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbLokacija.FormattingEnabled = true;
            cmbLokacija.Items.AddRange(new object[] { "Odaberi lokaciju" });
            cmbLokacija.Location = new Point(12, 242);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(235, 29);
            cmbLokacija.TabIndex = 23;
            cmbLokacija.Text = "Odaberi lokaciju";
            // 
            // frmPrijemUredjaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(720, 450);
            ControlBox = false;
            Controls.Add(cmbLokacija);
            Controls.Add(btnExit);
            Controls.Add(label9);
            Controls.Add(cmbTipUredjaja);
            Controls.Add(btnRegistruj);
            Controls.Add(label7);
            Controls.Add(txtEvBroj);
            Controls.Add(btnNoviTipUredjaja);
            Controls.Add(btnGenerisiSerijskiBroj);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtOpisKodPrijema);
            Controls.Add(label3);
            Controls.Add(txtIzdanje);
            Controls.Add(label2);
            Controls.Add(txtSerijskiBroj);
            Controls.Add(label1);
            Controls.Add(txtKoda);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmPrijemUredjaja";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPrijemUredjaja";
            TransparencyKey = Color.Transparent;
            FormClosing += frmPrijemUredjaja_FormClosing;
            Load += frmPrijemUredjaja_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKoda;
        private Label label1;
        private Label label2;
        private TextBox txtSerijskiBroj;
        private Label label3;
        private TextBox txtIzdanje;
        private RichTextBox txtOpisKodPrijema;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnGenerisiSerijskiBroj;
        private Button btnNoviTipUredjaja;
        private TextBox txtEvBroj;
        private Label label7;
        private Button btnRegistruj;
        private ComboBox cmbTipUredjaja;
        private Label label9;
        private Button btnExit;
        private ComboBox cmbLokacija;
    }
}