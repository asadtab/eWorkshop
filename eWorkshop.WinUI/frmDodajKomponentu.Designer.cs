namespace eWorkshop.WinUI
{
    partial class frmDodajKomponentu
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
            label5 = new Label();
            lblKoda = new Label();
            txtKoda = new TextBox();
            label2 = new Label();
            txtVrijednost = new TextBox();
            label1 = new Label();
            txtNaziv = new TextBox();
            txtOznaka = new TextBox();
            btnRegistruj = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(110, 123);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 28;
            label5.Text = "Oznaka";
            // 
            // lblKoda
            // 
            lblKoda.AutoSize = true;
            lblKoda.Location = new Point(357, 173);
            lblKoda.Name = "lblKoda";
            lblKoda.Size = new Size(34, 15);
            lblKoda.TabIndex = 26;
            lblKoda.Text = "Koda";
            // 
            // txtKoda
            // 
            txtKoda.BorderStyle = BorderStyle.FixedSingle;
            txtKoda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtKoda.Location = new Point(357, 191);
            txtKoda.Name = "txtKoda";
            txtKoda.Size = new Size(235, 29);
            txtKoda.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 173);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 24;
            label2.Text = "Vrijednost";
            // 
            // txtVrijednost
            // 
            txtVrijednost.BorderStyle = BorderStyle.FixedSingle;
            txtVrijednost.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtVrijednost.Location = new Point(110, 191);
            txtVrijednost.Name = "txtVrijednost";
            txtVrijednost.Size = new Size(235, 29);
            txtVrijednost.TabIndex = 23;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(357, 123);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 22;
            label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            txtNaziv.BorderStyle = BorderStyle.FixedSingle;
            txtNaziv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(357, 141);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(235, 29);
            txtNaziv.TabIndex = 21;
            // 
            // txtOznaka
            // 
            txtOznaka.BorderStyle = BorderStyle.FixedSingle;
            txtOznaka.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOznaka.Location = new Point(110, 141);
            txtOznaka.Name = "txtOznaka";
            txtOznaka.Size = new Size(235, 29);
            txtOznaka.TabIndex = 29;
            // 
            // btnRegistruj
            // 
            btnRegistruj.Location = new Point(460, 243);
            btnRegistruj.Name = "btnRegistruj";
            btnRegistruj.Size = new Size(132, 29);
            btnRegistruj.TabIndex = 30;
            btnRegistruj.Text = "Sačuvaj";
            btnRegistruj.UseVisualStyleBackColor = true;
            btnRegistruj.Click += btnRegistruj_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(231, 39);
            label6.Name = "label6";
            label6.Size = new Size(248, 37);
            label6.TabIndex = 31;
            label6.Text = "Dodaj komponentu";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmDodajKomponentu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 411);
            ControlBox = false;
            Controls.Add(label6);
            Controls.Add(btnRegistruj);
            Controls.Add(txtOznaka);
            Controls.Add(label5);
            Controls.Add(lblKoda);
            Controls.Add(txtKoda);
            Controls.Add(label2);
            Controls.Add(txtVrijednost);
            Controls.Add(label1);
            Controls.Add(txtNaziv);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDodajKomponentu";
            Text = "frmDodajKomponentu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label lblKoda;
        private TextBox txtKoda;
        private Label label2;
        private TextBox txtVrijednost;
        private Label label1;
        private TextBox txtNaziv;
        private TextBox txtOznaka;
        private Button btnRegistruj;
        private Label label6;
    }
}