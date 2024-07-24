namespace eWorkshop.WinUI
{
    partial class frmKomponenteEdit
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
            txtNaziv = new TextBox();
            txtVrijednost = new TextBox();
            txtKoda = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            btnPotvrdi = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNaziv
            // 
            txtNaziv.BorderStyle = BorderStyle.FixedSingle;
            txtNaziv.Location = new Point(22, 50);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(162, 23);
            txtNaziv.TabIndex = 0;
            // 
            // txtVrijednost
            // 
            txtVrijednost.BorderStyle = BorderStyle.FixedSingle;
            txtVrijednost.Location = new Point(22, 94);
            txtVrijednost.Name = "txtVrijednost";
            txtVrijednost.Size = new Size(162, 23);
            txtVrijednost.TabIndex = 1;
            // 
            // txtKoda
            // 
            txtKoda.BorderStyle = BorderStyle.FixedSingle;
            txtKoda.Location = new Point(22, 138);
            txtKoda.Name = "txtKoda";
            txtKoda.Size = new Size(162, 23);
            txtKoda.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 32);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Naziv";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 76);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Vrijednost";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 120);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "Tip/Koda";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPotvrdi);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtNaziv);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtVrijednost);
            groupBox1.Controls.Add(txtKoda);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 214);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Uredi komponentu";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(22, 167);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(162, 23);
            btnPotvrdi.TabIndex = 6;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // frmKomponenteEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 238);
            Controls.Add(groupBox1);
            Name = "frmKomponenteEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmKomponenteEdit";
            Load += frmKomponenteEdit_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNaziv;
        private TextBox txtVrijednost;
        private TextBox txtKoda;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnPotvrdi;
    }
}