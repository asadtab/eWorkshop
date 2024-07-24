namespace eWorkshop.WinUI
{
    partial class frmRacun
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
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAktivan = new Label();
            lblUloga = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            lblKorisnickoIme = new Label();
            lblIme = new Label();
            lblPrezime = new Label();
            flpServisi = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 186);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.41177F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.58823F));
            tableLayoutPanel1.Controls.Add(lblAktivan, 1, 3);
            tableLayoutPanel1.Controls.Add(lblUloga, 1, 4);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(lblKorisnickoIme, 1, 2);
            tableLayoutPanel1.Controls.Add(lblIme, 1, 0);
            tableLayoutPanel1.Controls.Add(lblPrezime, 1, 1);
            tableLayoutPanel1.Location = new Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 47.0588226F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 52.9411774F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(335, 150);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // lblAktivan
            // 
            lblAktivan.AutoSize = true;
            lblAktivan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAktivan.Location = new Point(185, 80);
            lblAktivan.Name = "lblAktivan";
            lblAktivan.Size = new Size(79, 21);
            lblAktivan.TabIndex = 8;
            lblAktivan.Text = "lblAktivan";
            // 
            // lblUloga
            // 
            lblUloga.AutoSize = true;
            lblUloga.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUloga.Location = new Point(185, 109);
            lblUloga.Name = "lblUloga";
            lblUloga.Size = new Size(68, 21);
            lblUloga.TabIndex = 9;
            lblUloga.Text = "lblUloga";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(39, 21);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 24);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 51);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 2;
            label3.Text = "Korisničko ime:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 80);
            label4.Name = "label4";
            label4.Size = new Size(65, 21);
            label4.TabIndex = 3;
            label4.Text = "Aktivan:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(3, 109);
            label6.Name = "label6";
            label6.Size = new Size(54, 21);
            label6.TabIndex = 3;
            label6.Text = "Uloge:";
            // 
            // lblKorisnickoIme
            // 
            lblKorisnickoIme.AutoSize = true;
            lblKorisnickoIme.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblKorisnickoIme.Location = new Point(185, 51);
            lblKorisnickoIme.Name = "lblKorisnickoIme";
            lblKorisnickoIme.Size = new Size(125, 21);
            lblKorisnickoIme.TabIndex = 7;
            lblKorisnickoIme.Text = "lblKorisnickoIme";
            // 
            // lblIme
            // 
            lblIme.AutoSize = true;
            lblIme.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblIme.Location = new Point(185, 0);
            lblIme.Name = "lblIme";
            lblIme.Size = new Size(53, 21);
            lblIme.TabIndex = 5;
            lblIme.Text = "lblIme";
            // 
            // lblPrezime
            // 
            lblPrezime.AutoSize = true;
            lblPrezime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrezime.Location = new Point(185, 24);
            lblPrezime.Name = "lblPrezime";
            lblPrezime.Size = new Size(83, 21);
            lblPrezime.TabIndex = 6;
            lblPrezime.Text = "lblPrezime";
            // 
            // flpServisi
            // 
            flpServisi.AutoScroll = true;
            flpServisi.Location = new Point(12, 204);
            flpServisi.Name = "flpServisi";
            flpServisi.Size = new Size(696, 325);
            flpServisi.TabIndex = 3;
            // 
            // frmRacun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 541);
            Controls.Add(flpServisi);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRacun";
            Text = "frmRacun";
            Load += frmRacun_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAktivan;
        private Label lblUloga;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label lblKorisnickoIme;
        private Label lblIme;
        private Label lblPrezime;
        private FlowLayoutPanel flpServisi;
    }
}