namespace eWorkshop.WinUI
{
    partial class frmMain
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
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAktivniRadniZadaci = new System.Windows.Forms.Label();
            this.lblUkupnoUredjaja = new System.Windows.Forms.Label();
            this.lblUkupnoKorisnika = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblServisiraniUredjaji = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAktivniUredjaji = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPoslaniUredjaji = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSpremniUredjaji = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblNeaktivniUredjaji = new System.Windows.Forms.Label();
            this.lblRezervniDijelovi = new System.Windows.Forms.Label();
            this.lblTaskUredjaji = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flPanel
            // 
            this.flPanel.AutoScroll = true;
            this.flPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flPanel.Location = new System.Drawing.Point(6, 22);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(660, 280);
            this.flPanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 308);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aktivni radni zadaci";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(113, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Informacioni sistem za podršku rada servisne radionice";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel1);
            this.groupBox3.Location = new System.Drawing.Point(12, 389);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(676, 142);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistika";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAktivniRadniZadaci, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUkupnoUredjaja, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUkupnoKorisnika, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblServisiraniUredjaji, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAktivniUredjaji, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPoslaniUredjaji, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSpremniUredjaji, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNeaktivniUredjaji, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRezervniDijelovi, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTaskUredjaji, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 114);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Aktivnih radnih zadataka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ukupno uređaja";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ukupno korisnika";
            // 
            // lblAktivniRadniZadaci
            // 
            this.lblAktivniRadniZadaci.AutoSize = true;
            this.lblAktivniRadniZadaci.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAktivniRadniZadaci.Location = new System.Drawing.Point(194, 0);
            this.lblAktivniRadniZadaci.Name = "lblAktivniRadniZadaci";
            this.lblAktivniRadniZadaci.Size = new System.Drawing.Size(38, 21);
            this.lblAktivniRadniZadaci.TabIndex = 6;
            this.lblAktivniRadniZadaci.Text = "broj";
            // 
            // lblUkupnoUredjaja
            // 
            this.lblUkupnoUredjaja.AutoSize = true;
            this.lblUkupnoUredjaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUkupnoUredjaja.Location = new System.Drawing.Point(194, 32);
            this.lblUkupnoUredjaja.Name = "lblUkupnoUredjaja";
            this.lblUkupnoUredjaja.Size = new System.Drawing.Size(38, 21);
            this.lblUkupnoUredjaja.TabIndex = 7;
            this.lblUkupnoUredjaja.Text = "broj";
            // 
            // lblUkupnoKorisnika
            // 
            this.lblUkupnoKorisnika.AutoSize = true;
            this.lblUkupnoKorisnika.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUkupnoKorisnika.Location = new System.Drawing.Point(194, 64);
            this.lblUkupnoKorisnika.Name = "lblUkupnoKorisnika";
            this.lblUkupnoKorisnika.Size = new System.Drawing.Size(38, 21);
            this.lblUkupnoKorisnika.TabIndex = 8;
            this.lblUkupnoKorisnika.Text = "broj";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Servisirani uređaji";
            // 
            // lblServisiraniUredjaji
            // 
            this.lblServisiraniUredjaji.AutoSize = true;
            this.lblServisiraniUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblServisiraniUredjaji.Location = new System.Drawing.Point(194, 92);
            this.lblServisiraniUredjaji.Name = "lblServisiraniUredjaji";
            this.lblServisiraniUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblServisiraniUredjaji.TabIndex = 9;
            this.lblServisiraniUredjaji.Text = "broj";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(251, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Aktivni uređaji";
            // 
            // lblAktivniUredjaji
            // 
            this.lblAktivniUredjaji.AutoSize = true;
            this.lblAktivniUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAktivniUredjaji.Location = new System.Drawing.Point(388, 0);
            this.lblAktivniUredjaji.Name = "lblAktivniUredjaji";
            this.lblAktivniUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblAktivniUredjaji.TabIndex = 11;
            this.lblAktivniUredjaji.Text = "broj";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(251, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 21);
            this.label6.TabIndex = 4;
            this.label6.Text = "Poslani uređaji";
            // 
            // lblPoslaniUredjaji
            // 
            this.lblPoslaniUredjaji.AutoSize = true;
            this.lblPoslaniUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPoslaniUredjaji.Location = new System.Drawing.Point(388, 64);
            this.lblPoslaniUredjaji.Name = "lblPoslaniUredjaji";
            this.lblPoslaniUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblPoslaniUredjaji.TabIndex = 10;
            this.lblPoslaniUredjaji.Text = "broj";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(251, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 21);
            this.label10.TabIndex = 14;
            this.label10.Text = "Spremni uređaji";
            // 
            // lblSpremniUredjaji
            // 
            this.lblSpremniUredjaji.AutoSize = true;
            this.lblSpremniUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpremniUredjaji.Location = new System.Drawing.Point(388, 92);
            this.lblSpremniUredjaji.Name = "lblSpremniUredjaji";
            this.lblSpremniUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblSpremniUredjaji.TabIndex = 15;
            this.lblSpremniUredjaji.Text = "broj";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(251, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 21);
            this.label11.TabIndex = 16;
            this.label11.Text = "Neaktivni uređaji";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(450, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 21);
            this.label12.TabIndex = 17;
            this.label12.Text = "Rezervni dijelovi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(450, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 21);
            this.label13.TabIndex = 18;
            this.label13.Text = "Uređaji u zadacima";
            // 
            // lblNeaktivniUredjaji
            // 
            this.lblNeaktivniUredjaji.AutoSize = true;
            this.lblNeaktivniUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNeaktivniUredjaji.Location = new System.Drawing.Point(388, 32);
            this.lblNeaktivniUredjaji.Name = "lblNeaktivniUredjaji";
            this.lblNeaktivniUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblNeaktivniUredjaji.TabIndex = 19;
            this.lblNeaktivniUredjaji.Text = "broj";
            // 
            // lblRezervniDijelovi
            // 
            this.lblRezervniDijelovi.AutoSize = true;
            this.lblRezervniDijelovi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRezervniDijelovi.Location = new System.Drawing.Point(606, 0);
            this.lblRezervniDijelovi.Name = "lblRezervniDijelovi";
            this.lblRezervniDijelovi.Size = new System.Drawing.Size(38, 21);
            this.lblRezervniDijelovi.TabIndex = 20;
            this.lblRezervniDijelovi.Text = "broj";
            // 
            // lblTaskUredjaji
            // 
            this.lblTaskUredjaji.AutoSize = true;
            this.lblTaskUredjaji.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTaskUredjaji.Location = new System.Drawing.Point(606, 32);
            this.lblTaskUredjaji.Name = "lblTaskUredjaji";
            this.lblTaskUredjaji.Size = new System.Drawing.Size(38, 21);
            this.lblTaskUredjaji.TabIndex = 21;
            this.lblTaskUredjaji.Text = "broj";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(720, 543);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanel;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblAktivniRadniZadaci;
        private Label lblUkupnoUredjaja;
        private Label lblUkupnoKorisnika;
        private Label lblServisiraniUredjaji;
        private Label lblPoslaniUredjaji;
        private Label lblAktivniUredjaji;
        private Label label10;
        private Label lblSpremniUredjaji;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label lblNeaktivniUredjaji;
        private Label lblRezervniDijelovi;
        private Label lblTaskUredjaji;
    }
}