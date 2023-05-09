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
            components = new System.ComponentModel.Container();
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
            errProvider = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtKoda
            // 
            txtKoda.BorderStyle = BorderStyle.FixedSingle;
            txtKoda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtKoda.Location = new Point(247, 46);
            txtKoda.Name = "txtKoda";
            txtKoda.Size = new Size(216, 29);
            txtKoda.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 24);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 1;
            label1.Text = "Koda";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 78);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Serijski broj";
            // 
            // txtSerijskiBroj
            // 
            txtSerijskiBroj.BorderStyle = BorderStyle.FixedSingle;
            txtSerijskiBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSerijskiBroj.Location = new Point(6, 99);
            txtSerijskiBroj.Name = "txtSerijskiBroj";
            txtSerijskiBroj.Size = new Size(216, 29);
            txtSerijskiBroj.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(247, 78);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 5;
            label3.Text = "Izdanje";
            // 
            // txtIzdanje
            // 
            txtIzdanje.BorderStyle = BorderStyle.FixedSingle;
            txtIzdanje.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtIzdanje.Location = new Point(247, 99);
            txtIzdanje.Name = "txtIzdanje";
            txtIzdanje.Size = new Size(216, 29);
            txtIzdanje.TabIndex = 4;
            // 
            // txtOpisKodPrijema
            // 
            txtOpisKodPrijema.BorderStyle = BorderStyle.FixedSingle;
            txtOpisKodPrijema.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOpisKodPrijema.Location = new Point(6, 212);
            txtOpisKodPrijema.Name = "txtOpisKodPrijema";
            txtOpisKodPrijema.Size = new Size(457, 96);
            txtOpisKodPrijema.TabIndex = 6;
            txtOpisKodPrijema.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 189);
            label4.Name = "label4";
            label4.Size = new Size(139, 15);
            label4.TabIndex = 7;
            label4.Text = "Opis uređaja kod prijema";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 24);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 9;
            label5.Text = "Tip";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(203, 31);
            label6.Name = "label6";
            label6.Size = new Size(202, 37);
            label6.TabIndex = 10;
            label6.Text = "Registruj uređaj";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnGenerisiSerijskiBroj
            // 
            btnGenerisiSerijskiBroj.Location = new Point(29, 94);
            btnGenerisiSerijskiBroj.Name = "btnGenerisiSerijskiBroj";
            btnGenerisiSerijskiBroj.Size = new Size(132, 29);
            btnGenerisiSerijskiBroj.TabIndex = 11;
            btnGenerisiSerijskiBroj.Text = "Generiši serijski broj";
            btnGenerisiSerijskiBroj.UseVisualStyleBackColor = true;
            btnGenerisiSerijskiBroj.Click += btnGenerisiSerijskiBroj_Click;
            // 
            // btnNoviTipUredjaja
            // 
            btnNoviTipUredjaja.Location = new Point(29, 44);
            btnNoviTipUredjaja.Name = "btnNoviTipUredjaja";
            btnNoviTipUredjaja.Size = new Size(132, 29);
            btnNoviTipUredjaja.TabIndex = 12;
            btnNoviTipUredjaja.Text = "Novi tip uređaja";
            btnNoviTipUredjaja.UseVisualStyleBackColor = true;
            btnNoviTipUredjaja.Click += btnNoviTipUredjaja_Click;
            // 
            // txtEvBroj
            // 
            txtEvBroj.BorderStyle = BorderStyle.FixedSingle;
            txtEvBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEvBroj.Location = new Point(29, 152);
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
            label7.Location = new Point(29, 130);
            label7.Name = "label7";
            label7.Size = new Size(145, 15);
            label7.TabIndex = 14;
            label7.Text = "Posljednji ev. broj uređaja:";
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(6, 285);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(188, 29);
            btnRegistruj.TabIndex = 15;
            btnRegistruj.Text = "Sačuvaj";
            btnRegistruj.UseVisualStyleBackColor = true;
            btnRegistruj.Click += btnRegistruj_Click;
            // 
            // cmbTipUredjaja
            // 
            cmbTipUredjaja.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipUredjaja.FormattingEnabled = true;
            cmbTipUredjaja.Location = new Point(6, 46);
            cmbTipUredjaja.Name = "cmbTipUredjaja";
            cmbTipUredjaja.Size = new Size(216, 29);
            cmbTipUredjaja.TabIndex = 16;
            cmbTipUredjaja.Text = "Odaberi tip uređaja";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 131);
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
            cmbLokacija.Location = new Point(6, 151);
            cmbLokacija.Name = "cmbLokacija";
            cmbLokacija.Size = new Size(216, 29);
            cmbLokacija.TabIndex = 23;
            cmbLokacija.Text = "Odaberi lokaciju";
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(641, 100);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtKoda);
            groupBox2.Controls.Add(cmbLokacija);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtSerijskiBroj);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(cmbTipUredjaja);
            groupBox2.Controls.Add(txtIzdanje);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtOpisKodPrijema);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(12, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(488, 320);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Info";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnNoviTipUredjaja);
            groupBox3.Controls.Add(btnGenerisiSerijskiBroj);
            groupBox3.Controls.Add(txtEvBroj);
            groupBox3.Controls.Add(btnRegistruj);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(508, 118);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 320);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Opcije";
            // 
            // frmPrijemUredjaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(720, 450);
            ControlBox = false;
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnExit);
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
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
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
        private ErrorProvider errProvider;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
    }
}