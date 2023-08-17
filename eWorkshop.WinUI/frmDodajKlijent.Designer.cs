namespace eWorkshop.WinUI
{
    partial class frmDodajKlijent
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
            Dodaj = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbTipKlijenta = new ComboBox();
            label5 = new Label();
            groupBox1 = new GroupBox();
            lblInfo = new Label();
            label7 = new Label();
            label8 = new Label();
            txtClientId = new TextBox();
            txtClientName = new TextBox();
            txtClientSecret = new TextBox();
            txtConfirmClientSecret = new TextBox();
            txtClientUri = new TextBox();
            listBox1 = new ListBox();
            button1 = new Button();
            chlbScopes = new CheckedListBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Dodaj
            // 
            Dodaj.Location = new Point(317, 541);
            Dodaj.Name = "Dodaj";
            Dodaj.Size = new Size(75, 23);
            Dodaj.TabIndex = 0;
            Dodaj.Text = "Dodaj";
            Dodaj.TextImageRelation = TextImageRelation.ImageAboveText;
            Dodaj.UseVisualStyleBackColor = true;
            Dodaj.Click += Dodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 241);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 2;
            label1.Text = "Naziv";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 187);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 4;
            label2.Text = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 295);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Client Secret";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 187);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 8;
            label4.Text = "Redirect Uri";
            // 
            // cmbTipKlijenta
            // 
            cmbTipKlijenta.FormattingEnabled = true;
            cmbTipKlijenta.Items.AddRange(new object[] { "Javni ", "Povjerljivi" });
            cmbTipKlijenta.Location = new Point(57, 112);
            cmbTipKlijenta.Name = "cmbTipKlijenta";
            cmbTipKlijenta.Size = new Size(216, 23);
            cmbTipKlijenta.TabIndex = 11;
            cmbTipKlijenta.Text = "-- Odaberi klijenta --";
            cmbTipKlijenta.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(57, 90);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 12;
            label5.Text = "Tip klijenta";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblInfo);
            groupBox1.Location = new Point(317, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 90);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // lblInfo
            // 
            lblInfo.AutoEllipsis = true;
            lblInfo.Location = new Point(6, 19);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(350, 68);
            lblInfo.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(57, 349);
            label7.Name = "label7";
            label7.Size = new Size(120, 15);
            label7.TabIndex = 15;
            label7.Text = "Confirm Client Secret";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(57, 403);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 16;
            label8.Text = "Scopes";
            // 
            // txtClientId
            // 
            txtClientId.BorderStyle = BorderStyle.FixedSingle;
            txtClientId.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientId.Location = new Point(57, 209);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(216, 29);
            txtClientId.TabIndex = 17;
            // 
            // txtClientName
            // 
            txtClientName.BorderStyle = BorderStyle.FixedSingle;
            txtClientName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientName.Location = new Point(57, 263);
            txtClientName.Name = "txtClientName";
            txtClientName.Size = new Size(216, 29);
            txtClientName.TabIndex = 18;
            // 
            // txtClientSecret
            // 
            txtClientSecret.BorderStyle = BorderStyle.FixedSingle;
            txtClientSecret.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientSecret.Location = new Point(57, 317);
            txtClientSecret.Name = "txtClientSecret";
            txtClientSecret.Size = new Size(216, 29);
            txtClientSecret.TabIndex = 20;
            // 
            // txtConfirmClientSecret
            // 
            txtConfirmClientSecret.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmClientSecret.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtConfirmClientSecret.Location = new Point(57, 371);
            txtConfirmClientSecret.Name = "txtConfirmClientSecret";
            txtConfirmClientSecret.Size = new Size(216, 29);
            txtConfirmClientSecret.TabIndex = 22;
            // 
            // txtClientUri
            // 
            txtClientUri.BorderStyle = BorderStyle.FixedSingle;
            txtClientUri.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtClientUri.Location = new Point(317, 209);
            txtClientUri.Name = "txtClientUri";
            txtClientUri.Size = new Size(216, 29);
            txtClientUri.TabIndex = 23;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(317, 244);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(216, 94);
            listBox1.TabIndex = 24;
            // 
            // button1
            // 
            button1.Location = new Point(552, 209);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 25;
            button1.Text = "Dodaj ";
            button1.UseVisualStyleBackColor = true;
            // 
            // chlbScopes
            // 
            chlbScopes.FormattingEnabled = true;
            chlbScopes.Location = new Point(57, 425);
            chlbScopes.Name = "chlbScopes";
            chlbScopes.Size = new Size(216, 130);
            chlbScopes.TabIndex = 10;
            // 
            // frmDodajKlijent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 634);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(txtClientUri);
            Controls.Add(txtConfirmClientSecret);
            Controls.Add(txtClientSecret);
            Controls.Add(txtClientName);
            Controls.Add(txtClientId);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(cmbTipKlijenta);
            Controls.Add(chlbScopes);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Dodaj);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDodajKlijent";
            Text = "frmDodajKlijent";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Dodaj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbTipKlijenta;
        private Label label5;
        private GroupBox groupBox1;
        private Label lblInfo;
        private Label label7;
        private Label label8;
        private TextBox txtClientId;
        private TextBox txtClientName;
        private TextBox txtClientSecret;
        private TextBox txtConfirmClientSecret;
        private TextBox txtClientUri;
        private ListBox listBox1;
        private Button button1;
        private CheckedListBox chlbScopes;
    }
}