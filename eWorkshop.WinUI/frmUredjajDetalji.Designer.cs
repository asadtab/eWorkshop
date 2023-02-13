namespace eWorkshop.WinUI
{
    partial class frmUredjajDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLokacija = new System.Windows.Forms.Label();
            this.lblSerBroj = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblKoda = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEvBroj = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.flpHistorija = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAktiviraj = new System.Windows.Forms.Button();
            this.btnServisiraj = new System.Windows.Forms.Button();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.btnDijelovi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVrati = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evidencijski broj:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tip:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Koda:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Serijski broj:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.41177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.58823F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblLokacija, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSerBroj, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblKoda, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEvBroj, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTip, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 150);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(3, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Lokacija:";
            // 
            // lblLokacija
            // 
            this.lblLokacija.AutoSize = true;
            this.lblLokacija.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLokacija.Location = new System.Drawing.Point(185, 130);
            this.lblLokacija.Name = "lblLokacija";
            this.lblLokacija.Size = new System.Drawing.Size(43, 20);
            this.lblLokacija.TabIndex = 10;
            this.lblLokacija.Text = "tekst";
            // 
            // lblSerBroj
            // 
            this.lblSerBroj.AutoSize = true;
            this.lblSerBroj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSerBroj.Location = new System.Drawing.Point(185, 81);
            this.lblSerBroj.Name = "lblSerBroj";
            this.lblSerBroj.Size = new System.Drawing.Size(52, 21);
            this.lblSerBroj.TabIndex = 8;
            this.lblSerBroj.Text = "label8";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(185, 107);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 21);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "label5";
            // 
            // lblKoda
            // 
            this.lblKoda.AutoSize = true;
            this.lblKoda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKoda.Location = new System.Drawing.Point(185, 56);
            this.lblKoda.Name = "lblKoda";
            this.lblKoda.Size = new System.Drawing.Size(52, 21);
            this.lblKoda.TabIndex = 7;
            this.lblKoda.Text = "label7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Status:";
            // 
            // lblEvBroj
            // 
            this.lblEvBroj.AutoSize = true;
            this.lblEvBroj.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEvBroj.Location = new System.Drawing.Point(185, 0);
            this.lblEvBroj.Name = "lblEvBroj";
            this.lblEvBroj.Size = new System.Drawing.Size(52, 21);
            this.lblEvBroj.TabIndex = 5;
            this.lblEvBroj.Text = "label5";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTip.Location = new System.Drawing.Point(185, 28);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(52, 21);
            this.lblTip.TabIndex = 6;
            this.lblTip.Text = "label6";
            // 
            // flpHistorija
            // 
            this.flpHistorija.AutoScroll = true;
            this.flpHistorija.Location = new System.Drawing.Point(11, 22);
            this.flpHistorija.Name = "flpHistorija";
            this.flpHistorija.Size = new System.Drawing.Size(578, 301);
            this.flpHistorija.TabIndex = 5;
            // 
            // btnAktiviraj
            // 
            this.btnAktiviraj.Location = new System.Drawing.Point(6, 22);
            this.btnAktiviraj.Name = "btnAktiviraj";
            this.btnAktiviraj.Size = new System.Drawing.Size(104, 23);
            this.btnAktiviraj.TabIndex = 6;
            this.btnAktiviraj.Text = "Aktiviraj";
            this.btnAktiviraj.UseVisualStyleBackColor = true;
            this.btnAktiviraj.Click += new System.EventHandler(this.btnAktiviraj_Click);
            // 
            // btnServisiraj
            // 
            this.btnServisiraj.Location = new System.Drawing.Point(6, 51);
            this.btnServisiraj.Name = "btnServisiraj";
            this.btnServisiraj.Size = new System.Drawing.Size(104, 23);
            this.btnServisiraj.TabIndex = 7;
            this.btnServisiraj.Text = "Servisiraj";
            this.btnServisiraj.UseVisualStyleBackColor = true;
            this.btnServisiraj.Click += new System.EventHandler(this.btnServisiraj_Click);
            // 
            // btnPosalji
            // 
            this.btnPosalji.Location = new System.Drawing.Point(6, 109);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(104, 23);
            this.btnPosalji.TabIndex = 8;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            // 
            // btnDijelovi
            // 
            this.btnDijelovi.Location = new System.Drawing.Point(6, 22);
            this.btnDijelovi.Name = "btnDijelovi";
            this.btnDijelovi.Size = new System.Drawing.Size(104, 23);
            this.btnDijelovi.TabIndex = 10;
            this.btnDijelovi.Text = "Rezervni dijelovi";
            this.btnDijelovi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 171);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flpHistorija);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 329);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Historija servisa";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(6, 80);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(104, 23);
            this.btnSpremi.TabIndex = 15;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnVrati);
            this.groupBox3.Controls.Add(this.btnAktiviraj);
            this.groupBox3.Controls.Add(this.btnSpremi);
            this.groupBox3.Controls.Add(this.btnServisiraj);
            this.groupBox3.Controls.Add(this.btnPosalji);
            this.groupBox3.Location = new System.Drawing.Point(365, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(118, 171);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // btnVrati
            // 
            this.btnVrati.Location = new System.Drawing.Point(6, 138);
            this.btnVrati.Name = "btnVrati";
            this.btnVrati.Size = new System.Drawing.Size(104, 23);
            this.btnVrati.TabIndex = 16;
            this.btnVrati.Text = "Vrati";
            this.btnVrati.UseVisualStyleBackColor = true;
            this.btnVrati.Click += new System.EventHandler(this.btnVrati_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDijelovi);
            this.groupBox4.Location = new System.Drawing.Point(489, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(118, 171);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.IndianRed;
            this.btnExit.Location = new System.Drawing.Point(659, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 48);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmUredjajDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 535);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUredjajDetalji";
            this.Text = "frmUredjajDetalji";
            this.Load += new System.EventHandler(this.frmUredjajDetalji_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblSerBroj;
        private Label lblKoda;
        private Label lblEvBroj;
        private Label lblTip;
        private FlowLayoutPanel flpHistorija;
        private Button btnAktiviraj;
        private Button btnServisiraj;
        private Button btnPosalji;
        private Label label5;
        private Label lblStatus;
        private Button btnDijelovi;
        private Label label7;
        private Label lblLokacija;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnSpremi;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btnVrati;
        private Button btnExit;
    }
}