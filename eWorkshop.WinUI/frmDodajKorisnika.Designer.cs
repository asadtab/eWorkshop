namespace eWorkshop.WinUI
{
    partial class frmDodajKorisnika
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
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label7 = new Label();
            btnPotvrdi = new Button();
            label6 = new Label();
            txtPasswordPotvrda = new TextBox();
            errProvider = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            chbUposlenik = new CheckBox();
            chlbUloge = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtIme
            // 
            txtIme.BorderStyle = BorderStyle.FixedSingle;
            txtIme.Location = new Point(6, 42);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(167, 23);
            txtIme.TabIndex = 0;
            // 
            // txtPrezime
            // 
            txtPrezime.BorderStyle = BorderStyle.FixedSingle;
            txtPrezime.Location = new Point(222, 42);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(167, 23);
            txtPrezime.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(222, 101);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(167, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(6, 107);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(167, 23);
            txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 5;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 19);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 6;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(222, 78);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 84);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 8;
            label4.Text = "Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(161, 7);
            label7.Name = "label7";
            label7.Size = new Size(171, 37);
            label7.TabIndex = 11;
            label7.Text = "Novi korisnik";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(216, 302);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(75, 23);
            btnPotvrdi.TabIndex = 12;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 138);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 14;
            label6.Text = "Password potvrda:";
            // 
            // txtPasswordPotvrda
            // 
            txtPasswordPotvrda.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordPotvrda.Location = new Point(6, 161);
            txtPasswordPotvrda.Name = "txtPasswordPotvrda";
            txtPasswordPotvrda.Size = new Size(167, 23);
            txtPasswordPotvrda.TabIndex = 13;
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtIme);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPrezime);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPasswordPotvrda);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Location = new Point(12, 88);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(406, 190);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chbUposlenik);
            groupBox2.Controls.Add(chlbUloge);
            groupBox2.Location = new Point(424, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(131, 190);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Uloge";
            // 
            // chbUposlenik
            // 
            chbUposlenik.AutoSize = true;
            chbUposlenik.Location = new Point(6, 166);
            chbUposlenik.Name = "chbUposlenik";
            chbUposlenik.Size = new Size(113, 19);
            chbUposlenik.TabIndex = 2;
            chbUposlenik.Text = "Uposlenik ŽFBiH";
            chbUposlenik.UseVisualStyleBackColor = true;
            chbUposlenik.CheckStateChanged += chbUposlenik_CheckStateChanged;
            // 
            // chlbUloge
            // 
            chlbUloge.CheckOnClick = true;
            chlbUloge.FormattingEnabled = true;
            chlbUloge.Location = new Point(6, 25);
            chlbUloge.Name = "chlbUloge";
            chlbUloge.Size = new Size(120, 112);
            chlbUloge.TabIndex = 0;
            // 
            // frmDodajKorisnika
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 411);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrdi);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmDodajKorisnika";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmDodajKorisnika_Load;
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private Button btnPotvrdi;
        private Label label6;
        private TextBox txtPasswordPotvrda;
        private ErrorProvider errProvider;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private CheckedListBox chlbUloge;
        private CheckBox chbUposlenik;
    }
}