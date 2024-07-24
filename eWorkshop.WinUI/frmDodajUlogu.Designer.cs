namespace eWorkshop.WinUI
{
    partial class frmDodajUlogu
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
            txtUloga = new TextBox();
            label1 = new Label();
            btnPotvrdi = new Button();
            SuspendLayout();
            // 
            // txtUloga
            // 
            txtUloga.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUloga.Location = new Point(68, 64);
            txtUloga.Name = "txtUloga";
            txtUloga.Size = new Size(176, 29);
            txtUloga.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 42);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 1;
            label1.Text = "Naziv uloge";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(114, 115);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(75, 23);
            btnPotvrdi.TabIndex = 2;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // frmDodajUlogu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 164);
            Controls.Add(btnPotvrdi);
            Controls.Add(label1);
            Controls.Add(txtUloga);
            MaximizeBox = false;
            Name = "frmDodajUlogu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDodajUlogu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUloga;
        private Label label1;
        private Button btnPotvrdi;
    }
}