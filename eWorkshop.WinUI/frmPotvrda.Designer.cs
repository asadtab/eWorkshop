namespace eWorkshop.WinUI
{
    partial class frmPotvrda
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
            lblUpit = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblUpit
            // 
            lblUpit.AutoSize = true;
            lblUpit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUpit.Location = new Point(12, 27);
            lblUpit.Name = "lblUpit";
            lblUpit.Size = new Size(52, 21);
            lblUpit.TabIndex = 0;
            lblUpit.Text = "label1";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(43, 88);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "button1";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(173, 88);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "button2";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmPotvrda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 142);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblUpit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmPotvrda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmPotvrda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUpit;
        private Button btnConfirm;
        private Button btnCancel;
    }
}