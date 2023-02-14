namespace eWorkshop.WinUI
{
    partial class frmListaUredjaja
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
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serijskibroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lokacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.akcija = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbStateMachine = new System.Windows.Forms.ComboBox();
            this.EvBroj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Koda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.serijskibroj,
            this.lokacija,
            this.akcija});
            this.dgvLista.Location = new System.Drawing.Point(12, 129);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.RowTemplate.Height = 25;
            this.dgvLista.Size = new System.Drawing.Size(696, 493);
            this.dgvLista.TabIndex = 0;
            this.dgvLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UredjajId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Evidencijski broj";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TipOpisNaziv";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tip";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Koda";
            this.dataGridViewTextBoxColumn3.HeaderText = "Koda";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // serijskibroj
            // 
            this.serijskibroj.DataPropertyName = "SerijskiBroj";
            this.serijskibroj.HeaderText = "Serijski broj";
            this.serijskibroj.Name = "serijskibroj";
            this.serijskibroj.ReadOnly = true;
            // 
            // lokacija
            // 
            this.lokacija.DataPropertyName = "LokacijaNaziv";
            this.lokacija.HeaderText = "Lokacija";
            this.lokacija.Name = "lokacija";
            this.lokacija.ReadOnly = true;
            // 
            // akcija
            // 
            this.akcija.HeaderText = "Akcija";
            this.akcija.Name = "akcija";
            this.akcija.ReadOnly = true;
            // 
            // cmbStateMachine
            // 
            this.cmbStateMachine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStateMachine.FormattingEnabled = true;
            this.cmbStateMachine.Location = new System.Drawing.Point(12, 94);
            this.cmbStateMachine.Name = "cmbStateMachine";
            this.cmbStateMachine.Size = new System.Drawing.Size(197, 29);
            this.cmbStateMachine.TabIndex = 1;
            this.cmbStateMachine.SelectedIndexChanged += new System.EventHandler(this.cmbStateMachine_SelectedIndexChanged);
            // 
            // EvBroj
            // 
            this.EvBroj.DataPropertyName = "UredjajId";
            this.EvBroj.HeaderText = "Ev. broj";
            this.EvBroj.Name = "EvBroj";
            // 
            // Tip
            // 
            this.Tip.DataPropertyName = "TipId";
            this.Tip.HeaderText = "Tip";
            this.Tip.Name = "Tip";
            // 
            // Koda
            // 
            this.Koda.DataPropertyName = "Koda";
            this.Koda.HeaderText = "Koda";
            this.Koda.Name = "Koda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(276, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista uređaja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stanje uređaja:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(215, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 29);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pretraga:";
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
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmListaUredjaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 634);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStateMachine);
            this.Controls.Add(this.dgvLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListaUredjaja";
            this.Text = "frmListaUredjaja";
            this.Load += new System.EventHandler(this.frmListaUredjaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvLista;
        private ComboBox cmbStateMachine;
        private DataGridViewTextBoxColumn EvBroj;
        private DataGridViewTextBoxColumn Tip;
        private DataGridViewTextBoxColumn Koda;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serijskibroj;
        private DataGridViewTextBoxColumn lokacija;
        private DataGridViewButtonColumn akcija;
        private Button btnExit;
    }
}