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
            this.label5 = new System.Windows.Forms.Label();
            this.lblKoda = new System.Windows.Forms.Label();
            this.txtKoda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVrijednost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtOznaka = new System.Windows.Forms.TextBox();
            this.btnRegistruj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Oznaka";
            // 
            // lblKoda
            // 
            this.lblKoda.AutoSize = true;
            this.lblKoda.Location = new System.Drawing.Point(357, 173);
            this.lblKoda.Name = "lblKoda";
            this.lblKoda.Size = new System.Drawing.Size(34, 15);
            this.lblKoda.TabIndex = 26;
            this.lblKoda.Text = "Koda";
            // 
            // txtKoda
            // 
            this.txtKoda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKoda.Location = new System.Drawing.Point(357, 191);
            this.txtKoda.Name = "txtKoda";
            this.txtKoda.Size = new System.Drawing.Size(235, 29);
            this.txtKoda.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Vrijednost";
            // 
            // txtVrijednost
            // 
            this.txtVrijednost.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtVrijednost.Location = new System.Drawing.Point(110, 191);
            this.txtVrijednost.Name = "txtVrijednost";
            this.txtVrijednost.Size = new System.Drawing.Size(235, 29);
            this.txtVrijednost.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNaziv.Location = new System.Drawing.Point(357, 141);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(235, 29);
            this.txtNaziv.TabIndex = 21;
            // 
            // txtOznaka
            // 
            this.txtOznaka.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOznaka.Location = new System.Drawing.Point(110, 141);
            this.txtOznaka.Name = "txtOznaka";
            this.txtOznaka.Size = new System.Drawing.Size(235, 29);
            this.txtOznaka.TabIndex = 29;
            // 
            // btnRegistruj
            // 
            this.btnRegistruj.Location = new System.Drawing.Point(460, 243);
            this.btnRegistruj.Name = "btnRegistruj";
            this.btnRegistruj.Size = new System.Drawing.Size(132, 29);
            this.btnRegistruj.TabIndex = 30;
            this.btnRegistruj.Text = "Sačuvaj";
            this.btnRegistruj.UseVisualStyleBackColor = true;
            this.btnRegistruj.Click += new System.EventHandler(this.btnRegistruj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(231, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 37);
            this.label6.TabIndex = 31;
            this.label6.Text = "Dodaj komponentu";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmDodajKomponentu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 411);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRegistruj);
            this.Controls.Add(this.txtOznaka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKoda);
            this.Controls.Add(this.txtKoda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVrijednost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNaziv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDodajKomponentu";
            this.Text = "frmDodajKomponentu";
            this.ResumeLayout(false);
            this.PerformLayout();

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