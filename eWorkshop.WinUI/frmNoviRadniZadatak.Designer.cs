namespace eWorkshop.WinUI
{
    partial class frmNoviRadniZadatak
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
            lblNaziv = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnPotvrdi = new Button();
            SuspendLayout();
            // 
            // lblNaziv
            // 
            lblNaziv.BorderStyle = BorderStyle.FixedSingle;
            lblNaziv.Location = new Point(32, 104);
            lblNaziv.Name = "lblNaziv";
            lblNaziv.Size = new Size(155, 23);
            lblNaziv.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 86);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(32, 30);
            label2.Name = "label2";
            label2.Size = new Size(155, 21);
            label2.TabIndex = 2;
            label2.Text = "Novi radni zadatak";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(32, 143);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(155, 23);
            btnPotvrdi.TabIndex = 3;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // frmNoviRadniZadatak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(219, 207);
            Controls.Add(btnPotvrdi);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNaziv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmNoviRadniZadatak";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmNoviRadniZadatak";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lblNaziv;
        private Label label1;
        private Label label2;
        private Button btnPotvrdi;
    }
}