namespace eWorkshop.WinUI
{
    partial class frmDodajResurs
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
            txtResourceDisplayName = new TextBox();
            txtResourceName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtResourceDescription = new TextBox();
            label3 = new Label();
            clbScopes = new CheckedListBox();
            groupBox1 = new GroupBox();
            gbScopes = new GroupBox();
            btnPotvrdi = new Button();
            groupBox1.SuspendLayout();
            gbScopes.SuspendLayout();
            SuspendLayout();
            // 
            // txtResourceDisplayName
            // 
            txtResourceDisplayName.BorderStyle = BorderStyle.FixedSingle;
            txtResourceDisplayName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtResourceDisplayName.Location = new Point(6, 95);
            txtResourceDisplayName.Name = "txtResourceDisplayName";
            txtResourceDisplayName.Size = new Size(216, 29);
            txtResourceDisplayName.TabIndex = 22;
            // 
            // txtResourceName
            // 
            txtResourceName.BorderStyle = BorderStyle.FixedSingle;
            txtResourceName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtResourceName.Location = new Point(6, 41);
            txtResourceName.Name = "txtResourceName";
            txtResourceName.Size = new Size(216, 29);
            txtResourceName.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 20;
            label2.Text = "Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 73);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 19;
            label1.Text = "Naziv";
            // 
            // txtResourceDescription
            // 
            txtResourceDescription.BorderStyle = BorderStyle.FixedSingle;
            txtResourceDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtResourceDescription.Location = new Point(6, 149);
            txtResourceDescription.Name = "txtResourceDescription";
            txtResourceDescription.Size = new Size(216, 29);
            txtResourceDescription.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 127);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 23;
            label3.Text = "Opis";
            // 
            // clbScopes
            // 
            clbScopes.FormattingEnabled = true;
            clbScopes.Location = new Point(6, 22);
            clbScopes.Name = "clbScopes";
            clbScopes.Size = new Size(215, 274);
            clbScopes.TabIndex = 25;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtResourceName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtResourceDescription);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtResourceDisplayName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 200);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // gbScopes
            // 
            gbScopes.Controls.Add(clbScopes);
            gbScopes.Location = new Point(254, 12);
            gbScopes.Name = "gbScopes";
            gbScopes.Size = new Size(227, 301);
            gbScopes.TabIndex = 27;
            gbScopes.TabStop = false;
            gbScopes.Text = "Scopes";
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(205, 342);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.RightToLeft = RightToLeft.Yes;
            btnPotvrdi.Size = new Size(75, 23);
            btnPotvrdi.TabIndex = 28;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // frmDodajResurs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 377);
            Controls.Add(btnPotvrdi);
            Controls.Add(gbScopes);
            Controls.Add(groupBox1);
            Name = "frmDodajResurs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDodajResurs";
            Load += frmDodajResurs_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbScopes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtResourceDisplayName;
        private TextBox txtResourceName;
        private Label label2;
        private Label label1;
        private TextBox txtResourceDescription;
        private Label label3;
        private CheckedListBox clbScopes;
        private GroupBox groupBox1;
        private GroupBox gbScopes;
        private Button btnPotvrdi;
    }
}