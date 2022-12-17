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
            this.txtKoda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerijskiBroj = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIzdanje = new System.Windows.Forms.TextBox();
            this.txtOpisKodPrijema = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerisiSerijskiBroj = new System.Windows.Forms.Button();
            this.btnNoviTipUredjaja = new System.Windows.Forms.Button();
            this.txtEvBroj = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegistruj = new System.Windows.Forms.Button();
            this.cmbTipUredjaja = new System.Windows.Forms.ComboBox();
            this.cmbRadniZadatak = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLokacija = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKoda
            // 
            this.txtKoda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKoda.Location = new System.Drawing.Point(259, 142);
            this.txtKoda.Name = "txtKoda";
            this.txtKoda.Size = new System.Drawing.Size(235, 29);
            this.txtKoda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Koda";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serijski broj";
            // 
            // txtSerijskiBroj
            // 
            this.txtSerijskiBroj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSerijskiBroj.Location = new System.Drawing.Point(12, 192);
            this.txtSerijskiBroj.Name = "txtSerijskiBroj";
            this.txtSerijskiBroj.Size = new System.Drawing.Size(235, 29);
            this.txtSerijskiBroj.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Izdanje";
            // 
            // txtIzdanje
            // 
            this.txtIzdanje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtIzdanje.Location = new System.Drawing.Point(259, 192);
            this.txtIzdanje.Name = "txtIzdanje";
            this.txtIzdanje.Size = new System.Drawing.Size(235, 29);
            this.txtIzdanje.TabIndex = 4;
            // 
            // txtOpisKodPrijema
            // 
            this.txtOpisKodPrijema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpisKodPrijema.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOpisKodPrijema.Location = new System.Drawing.Point(12, 292);
            this.txtOpisKodPrijema.Name = "txtOpisKodPrijema";
            this.txtOpisKodPrijema.Size = new System.Drawing.Size(482, 96);
            this.txtOpisKodPrijema.TabIndex = 6;
            this.txtOpisKodPrijema.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Opis uređaja kod prijema";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tip";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(299, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 37);
            this.label6.TabIndex = 10;
            this.label6.Text = "Registruj uređaj";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGenerisiSerijskiBroj
            // 
            this.btnGenerisiSerijskiBroj.Location = new System.Drawing.Point(554, 242);
            this.btnGenerisiSerijskiBroj.Name = "btnGenerisiSerijskiBroj";
            this.btnGenerisiSerijskiBroj.Size = new System.Drawing.Size(132, 29);
            this.btnGenerisiSerijskiBroj.TabIndex = 11;
            this.btnGenerisiSerijskiBroj.Text = "Generiši serijski broj";
            this.btnGenerisiSerijskiBroj.UseVisualStyleBackColor = true;
            this.btnGenerisiSerijskiBroj.Click += new System.EventHandler(this.btnGenerisiSerijskiBroj_Click);
            // 
            // btnNoviTipUredjaja
            // 
            this.btnNoviTipUredjaja.Location = new System.Drawing.Point(554, 142);
            this.btnNoviTipUredjaja.Name = "btnNoviTipUredjaja";
            this.btnNoviTipUredjaja.Size = new System.Drawing.Size(132, 29);
            this.btnNoviTipUredjaja.TabIndex = 12;
            this.btnNoviTipUredjaja.Text = "Novi tip uređaja";
            this.btnNoviTipUredjaja.UseVisualStyleBackColor = true;
            this.btnNoviTipUredjaja.Click += new System.EventHandler(this.btnNoviTipUredjaja_Click);
            // 
            // txtEvBroj
            // 
            this.txtEvBroj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEvBroj.Location = new System.Drawing.Point(554, 310);
            this.txtEvBroj.Name = "txtEvBroj";
            this.txtEvBroj.ReadOnly = true;
            this.txtEvBroj.Size = new System.Drawing.Size(132, 29);
            this.txtEvBroj.TabIndex = 13;
            this.txtEvBroj.Text = "345";
            this.txtEvBroj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(554, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Posljednji ev. broj uređaja:";
            // 
            // btnRegistruj
            // 
            this.btnRegistruj.Location = new System.Drawing.Point(554, 359);
            this.btnRegistruj.Name = "btnRegistruj";
            this.btnRegistruj.Size = new System.Drawing.Size(132, 29);
            this.btnRegistruj.TabIndex = 15;
            this.btnRegistruj.Text = "Sačuvaj";
            this.btnRegistruj.UseVisualStyleBackColor = true;
            this.btnRegistruj.Click += new System.EventHandler(this.btnRegistruj_Click);
            // 
            // cmbTipUredjaja
            // 
            this.cmbTipUredjaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTipUredjaja.FormattingEnabled = true;
            this.cmbTipUredjaja.Location = new System.Drawing.Point(12, 142);
            this.cmbTipUredjaja.Name = "cmbTipUredjaja";
            this.cmbTipUredjaja.Size = new System.Drawing.Size(235, 29);
            this.cmbTipUredjaja.TabIndex = 16;
            this.cmbTipUredjaja.SelectedIndexChanged += new System.EventHandler(this.cmbTipUredjaja_SelectedIndexChanged);
            // 
            // cmbRadniZadatak
            // 
            this.cmbRadniZadatak.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRadniZadatak.FormattingEnabled = true;
            this.cmbRadniZadatak.Location = new System.Drawing.Point(12, 242);
            this.cmbRadniZadatak.Name = "cmbRadniZadatak";
            this.cmbRadniZadatak.Size = new System.Drawing.Size(235, 29);
            this.cmbRadniZadatak.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Radni zadatak";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Lokacija";
            // 
            // txtLokacija
            // 
            this.txtLokacija.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLokacija.Location = new System.Drawing.Point(259, 242);
            this.txtLokacija.Name = "txtLokacija";
            this.txtLokacija.Size = new System.Drawing.Size(235, 29);
            this.txtLokacija.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(554, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Novi radni zadatak";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmPrijemUredjaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(730, 450);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLokacija);
            this.Controls.Add(this.cmbRadniZadatak);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTipUredjaja);
            this.Controls.Add(this.btnRegistruj);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEvBroj);
            this.Controls.Add(this.btnNoviTipUredjaja);
            this.Controls.Add(this.btnGenerisiSerijskiBroj);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOpisKodPrijema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIzdanje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerijskiBroj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKoda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.MinimizeBox = false;
            this.Name = "frmPrijemUredjaja";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrijemUredjaja";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmPrijemUredjaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ComboBox cmbRadniZadatak;
        private Label label8;
        private Label label9;
        private TextBox txtLokacija;
        private Button button1;
    }
}