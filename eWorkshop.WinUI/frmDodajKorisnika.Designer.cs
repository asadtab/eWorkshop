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
            txtTelefon = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            btnPotvrdi = new Button();
            label6 = new Label();
            txtPasswordPotvrda = new TextBox();
            errProvider = new ErrorProvider(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            chbUposlenik = new CheckBox();
            chlbUloge = new CheckedListBox();
            groupBox3 = new GroupBox();
            chlbScopes = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtIme
            // 
            txtIme.BorderStyle = BorderStyle.FixedSingle;
            txtIme.Location = new Point(7, 56);
            txtIme.Margin = new Padding(3, 4, 3, 4);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(191, 27);
            txtIme.TabIndex = 0;
            // 
            // txtPrezime
            // 
            txtPrezime.BorderStyle = BorderStyle.FixedSingle;
            txtPrezime.Location = new Point(254, 56);
            txtPrezime.Margin = new Padding(3, 4, 3, 4);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(191, 27);
            txtPrezime.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(7, 128);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(191, 27);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(254, 128);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(191, 27);
            txtPassword.TabIndex = 3;
            // 
            // txtTelefon
            // 
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Location = new Point(7, 200);
            txtTelefon.Margin = new Padding(3, 4, 3, 4);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(191, 27);
            txtTelefon.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 25);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 5;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(254, 25);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 6;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 97);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 7;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 97);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 8;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 169);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 9;
            label5.Text = "Telefon:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(293, 12);
            label7.Name = "label7";
            label7.Size = new Size(213, 46);
            label7.TabIndex = 11;
            label7.Text = "Novi korisnik";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(350, 420);
            btnPotvrdi.Margin = new Padding(3, 4, 3, 4);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(86, 31);
            btnPotvrdi.TabIndex = 12;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(254, 169);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 14;
            label6.Text = "Password potvrda:";
            // 
            // txtPasswordPotvrda
            // 
            txtPasswordPotvrda.BorderStyle = BorderStyle.FixedSingle;
            txtPasswordPotvrda.Location = new Point(254, 200);
            txtPasswordPotvrda.Margin = new Padding(3, 4, 3, 4);
            txtPasswordPotvrda.Name = "txtPasswordPotvrda";
            txtPasswordPotvrda.Size = new Size(191, 27);
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
            groupBox1.Controls.Add(txtPasswordPotvrda);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtTelefon);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(14, 117);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(464, 253);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chbUposlenik);
            groupBox2.Controls.Add(chlbUloge);
            groupBox2.Location = new Point(485, 117);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(150, 253);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Uloge";
            // 
            // chbUposlenik
            // 
            chbUposlenik.AutoSize = true;
            chbUposlenik.Location = new Point(7, 221);
            chbUposlenik.Margin = new Padding(3, 4, 3, 4);
            chbUposlenik.Name = "chbUposlenik";
            chbUposlenik.Size = new Size(140, 24);
            chbUposlenik.TabIndex = 2;
            chbUposlenik.Text = "Uposlenik ŽFBiH";
            chbUposlenik.UseVisualStyleBackColor = true;
            chbUposlenik.CheckStateChanged += chbUposlenik_CheckStateChanged;
            // 
            // chlbUloge
            // 
            chlbUloge.CheckOnClick = true;
            chlbUloge.FormattingEnabled = true;
            chlbUloge.Items.AddRange(new object[] { "Administrator", "Serviser" });
            chlbUloge.Location = new Point(7, 33);
            chlbUloge.Margin = new Padding(3, 4, 3, 4);
            chlbUloge.Name = "chlbUloge";
            chlbUloge.Size = new Size(137, 158);
            chlbUloge.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chlbScopes);
            groupBox3.Location = new Point(641, 117);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(150, 253);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Scopes";
            // 
            // chlbScopes
            // 
            chlbScopes.FormattingEnabled = true;
            chlbScopes.Location = new Point(6, 33);
            chlbScopes.Margin = new Padding(3, 4, 3, 4);
            chlbScopes.Name = "chlbScopes";
            chlbScopes.Size = new Size(137, 202);
            chlbScopes.TabIndex = 3;
            // 
            // frmDodajKorisnika
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 548);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnPotvrdi);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmDodajKorisnika";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmDodajKorisnika_Load;
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtTelefon;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Button btnPotvrdi;
        private Label label6;
        private TextBox txtPasswordPotvrda;
        private ErrorProvider errProvider;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private CheckedListBox chlbUloge;
        private CheckBox chbUposlenik;
        private GroupBox groupBox3;
        private CheckedListBox chlbScopes;
    }
}