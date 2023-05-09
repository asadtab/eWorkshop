namespace eWorkshop.WinUI
{
    partial class frmServis
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label7 = new Label();
            lblLokacija = new Label();
            lblSerBroj = new Label();
            lblStatus = new Label();
            lblKoda = new Label();
            label5 = new Label();
            lblEvBroj = new Label();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblTip = new Label();
            txtOpisServisiranja = new RichTextBox();
            groupBox2 = new GroupBox();
            label11 = new Label();
            txtKomponentaKoda = new TextBox();
            btn_o = new Button();
            btnO = new Button();
            btn_u = new Button();
            btnU = new Button();
            btnMikro = new Button();
            btnOhm = new Button();
            btnKomponenta = new Button();
            label9 = new Label();
            txtKomponentaVrijednost = new TextBox();
            Naziv = new Label();
            txtKomponentaNaziv = new TextBox();
            label8 = new Label();
            cmbKomponente = new ComboBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            lvKomponente = new ListView();
            Broj = new ColumnHeader();
            NazivKomponente = new ColumnHeader();
            Vrijednost = new ColumnHeader();
            Koda = new ColumnHeader();
            KomponentaId = new ColumnHeader();
            cmsKomponenteEdit = new ContextMenuStrip(components);
            urediToolStripMenuItem = new ToolStripMenuItem();
            izbrišiToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            btnDodajRecommended = new Button();
            groupBox6 = new GroupBox();
            errProvider = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            cmsKomponenteEdit.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(347, 162);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.41177F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.58823F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label7, 0, 5);
            tableLayoutPanel1.Controls.Add(lblLokacija, 1, 5);
            tableLayoutPanel1.Controls.Add(lblSerBroj, 1, 3);
            tableLayoutPanel1.Controls.Add(lblStatus, 1, 4);
            tableLayoutPanel1.Controls.Add(lblKoda, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(lblEvBroj, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(lblTip, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(341, 134);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Evidencijski broj:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(3, 114);
            label7.Name = "label7";
            label7.Size = new Size(69, 20);
            label7.TabIndex = 11;
            label7.Text = "Lokacija:";
            // 
            // lblLokacija
            // 
            lblLokacija.AutoSize = true;
            lblLokacija.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLokacija.Location = new Point(188, 114);
            lblLokacija.Name = "lblLokacija";
            lblLokacija.Size = new Size(43, 20);
            lblLokacija.TabIndex = 10;
            lblLokacija.Text = "tekst";
            // 
            // lblSerBroj
            // 
            lblSerBroj.AutoSize = true;
            lblSerBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSerBroj.Location = new Point(188, 65);
            lblSerBroj.Name = "lblSerBroj";
            lblSerBroj.Size = new Size(52, 21);
            lblSerBroj.TabIndex = 8;
            lblSerBroj.Text = "label8";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Location = new Point(188, 91);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 21);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "label5";
            // 
            // lblKoda
            // 
            lblKoda.AutoSize = true;
            lblKoda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblKoda.Location = new Point(188, 40);
            lblKoda.Name = "lblKoda";
            lblKoda.Size = new Size(52, 21);
            lblKoda.TabIndex = 7;
            lblKoda.Text = "label7";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(3, 91);
            label5.Name = "label5";
            label5.Size = new Size(55, 21);
            label5.TabIndex = 9;
            label5.Text = "Status:";
            // 
            // lblEvBroj
            // 
            lblEvBroj.AutoSize = true;
            lblEvBroj.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEvBroj.Location = new Point(188, 0);
            lblEvBroj.Name = "lblEvBroj";
            lblEvBroj.Size = new Size(52, 20);
            lblEvBroj.TabIndex = 5;
            lblEvBroj.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 65);
            label4.Name = "label4";
            label4.Size = new Size(95, 21);
            label4.TabIndex = 3;
            label4.Text = "Serijski broj:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 20);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 1;
            label2.Text = "Tip:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 40);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 2;
            label3.Text = "Koda:";
            // 
            // lblTip
            // 
            lblTip.AutoSize = true;
            lblTip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTip.Location = new Point(188, 20);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(52, 20);
            lblTip.TabIndex = 6;
            lblTip.Text = "label6";
            // 
            // txtOpisServisiranja
            // 
            txtOpisServisiranja.BorderStyle = BorderStyle.FixedSingle;
            txtOpisServisiranja.Location = new Point(6, 22);
            txtOpisServisiranja.Name = "txtOpisServisiranja";
            txtOpisServisiranja.Size = new Size(348, 181);
            txtOpisServisiranja.TabIndex = 15;
            txtOpisServisiranja.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(txtKomponentaKoda);
            groupBox2.Controls.Add(btn_o);
            groupBox2.Controls.Add(btnO);
            groupBox2.Controls.Add(btn_u);
            groupBox2.Controls.Add(btnU);
            groupBox2.Controls.Add(btnMikro);
            groupBox2.Controls.Add(btnOhm);
            groupBox2.Controls.Add(btnKomponenta);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtKomponentaVrijednost);
            groupBox2.Controls.Add(Naziv);
            groupBox2.Controls.Add(txtKomponentaNaziv);
            groupBox2.Location = new Point(12, 180);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(466, 160);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dodaj komponentu";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(245, 30);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 31;
            label11.Text = "Koda:";
            // 
            // txtKomponentaKoda
            // 
            txtKomponentaKoda.BorderStyle = BorderStyle.FixedSingle;
            txtKomponentaKoda.Location = new Point(245, 53);
            txtKomponentaKoda.Name = "txtKomponentaKoda";
            txtKomponentaKoda.Size = new Size(210, 23);
            txtKomponentaKoda.TabIndex = 30;
            // 
            // btn_o
            // 
            btn_o.Location = new Point(186, 131);
            btn_o.Name = "btn_o";
            btn_o.Size = new Size(30, 23);
            btn_o.TabIndex = 29;
            btn_o.Text = "ö";
            btn_o.UseVisualStyleBackColor = true;
            btn_o.Click += btn_o_Click;
            // 
            // btnO
            // 
            btnO.Location = new Point(150, 131);
            btnO.Name = "btnO";
            btnO.Size = new Size(30, 23);
            btnO.TabIndex = 28;
            btnO.Text = "Ö";
            btnO.UseVisualStyleBackColor = true;
            btnO.Click += btnO_Click;
            // 
            // btn_u
            // 
            btn_u.Location = new Point(114, 131);
            btn_u.Name = "btn_u";
            btn_u.Size = new Size(30, 23);
            btn_u.TabIndex = 27;
            btn_u.Text = "ü";
            btn_u.UseVisualStyleBackColor = true;
            btn_u.Click += btn_u_Click;
            // 
            // btnU
            // 
            btnU.Location = new Point(78, 131);
            btnU.Name = "btnU";
            btnU.Size = new Size(30, 23);
            btnU.TabIndex = 26;
            btnU.Text = "Ü";
            btnU.UseVisualStyleBackColor = true;
            btnU.Click += btnU_Click;
            // 
            // btnMikro
            // 
            btnMikro.Location = new Point(42, 131);
            btnMikro.Name = "btnMikro";
            btnMikro.Size = new Size(30, 23);
            btnMikro.TabIndex = 25;
            btnMikro.Text = "µ";
            btnMikro.UseVisualStyleBackColor = true;
            btnMikro.Click += btnMikro_Click;
            // 
            // btnOhm
            // 
            btnOhm.Location = new Point(6, 131);
            btnOhm.Name = "btnOhm";
            btnOhm.Size = new Size(30, 23);
            btnOhm.TabIndex = 24;
            btnOhm.Text = "Ω";
            btnOhm.UseVisualStyleBackColor = true;
            btnOhm.Click += button3_Click;
            // 
            // btnKomponenta
            // 
            btnKomponenta.Location = new Point(380, 110);
            btnKomponenta.Name = "btnKomponenta";
            btnKomponenta.Size = new Size(75, 23);
            btnKomponenta.TabIndex = 22;
            btnKomponenta.Text = "Potvrdi";
            btnKomponenta.UseVisualStyleBackColor = true;
            btnKomponenta.Click += btnKomponenta_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 79);
            label9.Name = "label9";
            label9.Size = new Size(110, 15);
            label9.TabIndex = 21;
            label9.Text = "Vrijednost/Količina:";
            // 
            // txtKomponentaVrijednost
            // 
            txtKomponentaVrijednost.BorderStyle = BorderStyle.FixedSingle;
            txtKomponentaVrijednost.Location = new Point(3, 102);
            txtKomponentaVrijednost.Name = "txtKomponentaVrijednost";
            txtKomponentaVrijednost.Size = new Size(210, 23);
            txtKomponentaVrijednost.TabIndex = 20;
            // 
            // Naziv
            // 
            Naziv.AutoSize = true;
            Naziv.Location = new Point(3, 30);
            Naziv.Name = "Naziv";
            Naziv.Size = new Size(39, 15);
            Naziv.TabIndex = 19;
            Naziv.Text = "Naziv:";
            // 
            // txtKomponentaNaziv
            // 
            txtKomponentaNaziv.BorderStyle = BorderStyle.FixedSingle;
            txtKomponentaNaziv.Location = new Point(3, 53);
            txtKomponentaNaziv.Name = "txtKomponentaNaziv";
            txtKomponentaNaziv.Size = new Size(210, 23);
            txtKomponentaNaziv.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 30);
            label8.Name = "label8";
            label8.Size = new Size(116, 15);
            label8.TabIndex = 23;
            label8.Text = "Naziv i vrijednost/tip";
            // 
            // cmbKomponente
            // 
            cmbKomponente.FormattingEnabled = true;
            cmbKomponente.Location = new Point(6, 53);
            cmbKomponente.Name = "cmbKomponente";
            cmbKomponente.Size = new Size(210, 23);
            cmbKomponente.TabIndex = 19;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtOpisServisiranja);
            groupBox3.Location = new Point(12, 346);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(360, 209);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Opis aktivnosti servisa";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lvKomponente);
            groupBox4.Location = new Point(378, 346);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(330, 238);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "Zamijenjene komponente";
            // 
            // lvKomponente
            // 
            lvKomponente.Columns.AddRange(new ColumnHeader[] { Broj, NazivKomponente, Vrijednost, Koda, KomponentaId });
            lvKomponente.ContextMenuStrip = cmsKomponenteEdit;
            lvKomponente.FullRowSelect = true;
            lvKomponente.GridLines = true;
            lvKomponente.LabelEdit = true;
            lvKomponente.Location = new Point(6, 22);
            lvKomponente.Name = "lvKomponente";
            lvKomponente.Size = new Size(318, 210);
            lvKomponente.TabIndex = 0;
            lvKomponente.UseCompatibleStateImageBehavior = false;
            lvKomponente.View = View.Details;
            // 
            // Broj
            // 
            Broj.Text = "#";
            Broj.Width = 30;
            // 
            // NazivKomponente
            // 
            NazivKomponente.Text = "Naziv";
            NazivKomponente.Width = 100;
            // 
            // Vrijednost
            // 
            Vrijednost.Text = "Vrijednost";
            Vrijednost.Width = 70;
            // 
            // Koda
            // 
            Koda.Text = "Koda";
            Koda.Width = 90;
            // 
            // KomponentaId
            // 
            KomponentaId.Text = "Id";
            // 
            // cmsKomponenteEdit
            // 
            cmsKomponenteEdit.Items.AddRange(new ToolStripItem[] { urediToolStripMenuItem, izbrišiToolStripMenuItem });
            cmsKomponenteEdit.Name = "cmsKomponenteEdit";
            cmsKomponenteEdit.Size = new Size(105, 48);
            // 
            // urediToolStripMenuItem
            // 
            urediToolStripMenuItem.Name = "urediToolStripMenuItem";
            urediToolStripMenuItem.Size = new Size(104, 22);
            urediToolStripMenuItem.Text = "Uredi";
            urediToolStripMenuItem.Click += urediToolStripMenuItem_Click;
            // 
            // izbrišiToolStripMenuItem
            // 
            izbrišiToolStripMenuItem.Name = "izbrišiToolStripMenuItem";
            izbrišiToolStripMenuItem.Size = new Size(104, 22);
            izbrišiToolStripMenuItem.Text = "Izbriši";
            izbrišiToolStripMenuItem.Click += izbrišiToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(297, 561);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 20;
            button1.Text = "Potvrdi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.IndianRed;
            button2.Location = new Point(659, 12);
            button2.Name = "button2";
            button2.Size = new Size(49, 48);
            button2.TabIndex = 21;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnDodajRecommended
            // 
            btnDodajRecommended.Location = new Point(92, 110);
            btnDodajRecommended.Name = "btnDodajRecommended";
            btnDodajRecommended.Size = new Size(126, 23);
            btnDodajRecommended.TabIndex = 30;
            btnDodajRecommended.Text = "Dodaj komponentu";
            btnDodajRecommended.UseVisualStyleBackColor = true;
            btnDodajRecommended.Click += btnDodajRecommended_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(btnDodajRecommended);
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(cmbKomponente);
            groupBox6.Location = new Point(484, 180);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(224, 142);
            groupBox6.TabIndex = 31;
            groupBox6.TabStop = false;
            groupBox6.Text = "Prijedlog komponente";
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // frmServis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 634);
            ControlBox = false;
            Controls.Add(groupBox6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmServis";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmServis";
            FormClosing += frmServis_FormClosing;
            Load += frmServis_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            cmsKomponenteEdit.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label7;
        private Label lblLokacija;
        private Label lblSerBroj;
        private Label lblStatus;
        private Label lblKoda;
        private Label label5;
        private Label lblEvBroj;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label lblTip;
        private RichTextBox txtOpisServisiranja;
        private GroupBox groupBox2;
        private Label label9;
        private TextBox txtKomponentaVrijednost;
        private Label Naziv;
        private TextBox txtKomponentaNaziv;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btnKomponenta;
        private ComboBox cmbKomponente;
        private Label label8;
        private ListView lvKomponente;
        private ColumnHeader Broj;
        private ColumnHeader NazivKomponente;
        private ColumnHeader Vrijednost;
        private Button button1;
        private Button button2;
        private Button btnOhm;
        private Button btn_o;
        private Button btnO;
        private Button btn_u;
        private Button btnU;
        private Button btnMikro;
        private Button btnDodajRecommended;
        private Label label11;
        private TextBox txtKomponentaKoda;
        private GroupBox groupBox6;
        private ColumnHeader Koda;
        private ContextMenuStrip cmsKomponenteEdit;
        private ToolStripMenuItem urediToolStripMenuItem;
        private ToolStripMenuItem izbrišiToolStripMenuItem;
        private ColumnHeader KomponentaId;
        private ErrorProvider errProvider;
    }
}