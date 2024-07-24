namespace eWorkshop.WinUI
{
    partial class frmDodajTipUredjaja
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
            label1 = new Label();
            label2 = new Label();
            txtOpis = new TextBox();
            btnSpremi = new Button();
            SuspendLayout();
            // 
            // txtNaziv
            // 
            txtNaziv.BorderStyle = BorderStyle.FixedSingle;
            txtNaziv.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNaziv.Location = new Point(43, 72);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(187, 29);
            txtNaziv.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 54);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Naziv";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 104);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 3;
            label2.Text = "Opis";
            // 
            // txtOpis
            // 
            txtOpis.BorderStyle = BorderStyle.FixedSingle;
            txtOpis.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtOpis.Location = new Point(43, 122);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(187, 29);
            txtOpis.TabIndex = 2;
            // 
            // btnSpremi
            // 
            btnSpremi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpremi.Location = new Point(43, 167);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(187, 29);
            btnSpremi.TabIndex = 4;
            btnSpremi.Text = "Spremi";
            btnSpremi.UseVisualStyleBackColor = true;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // frmDodajTipUredjaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 250);
            Controls.Add(btnSpremi);
            Controls.Add(label2);
            Controls.Add(txtOpis);
            Controls.Add(label1);
            Controls.Add(txtNaziv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(289, 289);
            MinimizeBox = false;
            MinimumSize = new Size(289, 289);
            Name = "frmDodajTipUredjaja";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDodajTipUredjaja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNaziv;
        private Label label1;
        private Label label2;
        private TextBox txtOpis;
        private Button btnSpremi;
    }
}