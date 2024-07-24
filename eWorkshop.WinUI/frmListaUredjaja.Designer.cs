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
            components = new System.ComponentModel.Container();
            dgvLista = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            serijskibroj = new DataGridViewTextBoxColumn();
            lokacija = new DataGridViewTextBoxColumn();
            isDeleted = new DataGridViewTextBoxColumn();
            cmbStateMachine = new ComboBox();
            EvBroj = new DataGridViewTextBoxColumn();
            Tip = new DataGridViewTextBoxColumn();
            Koda = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            label3 = new Label();
            btnExit = new Button();
            cmsUredi = new ContextMenuStrip(components);
            urediToolStripMenuItem = new ToolStripMenuItem();
            izbrišiToolStripMenuItem = new ToolStripMenuItem();
            cbDeleted = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            cmsUredi.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, serijskibroj, lokacija, isDeleted });
            dgvLista.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvLista.Location = new Point(12, 185);
            dgvLista.MultiSelect = false;
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ShowEditingIcon = false;
            dgvLista.Size = new Size(696, 396);
            dgvLista.TabIndex = 0;
            dgvLista.CellDoubleClick += dgvLista_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "UredjajId";
            dataGridViewTextBoxColumn1.HeaderText = "Evidencijski broj";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "TipOpisNaziv";
            dataGridViewTextBoxColumn2.HeaderText = "Tip";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Koda";
            dataGridViewTextBoxColumn3.HeaderText = "Koda";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // serijskibroj
            // 
            serijskibroj.DataPropertyName = "SerijskiBroj";
            serijskibroj.HeaderText = "Serijski broj";
            serijskibroj.Name = "serijskibroj";
            serijskibroj.ReadOnly = true;
            // 
            // lokacija
            // 
            lokacija.DataPropertyName = "LokacijaNaziv";
            lokacija.HeaderText = "Lokacija";
            lokacija.Name = "lokacija";
            lokacija.ReadOnly = true;
            // 
            // isDeleted
            // 
            isDeleted.DataPropertyName = "isDeleted";
            isDeleted.HeaderText = "Izbrisan";
            isDeleted.Name = "isDeleted";
            isDeleted.ReadOnly = true;
            isDeleted.Resizable = DataGridViewTriState.True;
            isDeleted.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // cmbStateMachine
            // 
            cmbStateMachine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStateMachine.FormattingEnabled = true;
            cmbStateMachine.Location = new Point(6, 41);
            cmbStateMachine.Name = "cmbStateMachine";
            cmbStateMachine.Size = new Size(197, 29);
            cmbStateMachine.TabIndex = 1;
            cmbStateMachine.SelectedIndexChanged += cmbStateMachine_SelectedIndexChanged;
            // 
            // EvBroj
            // 
            EvBroj.DataPropertyName = "UredjajId";
            EvBroj.HeaderText = "Ev. broj";
            EvBroj.Name = "EvBroj";
            // 
            // Tip
            // 
            Tip.DataPropertyName = "TipId";
            Tip.HeaderText = "Tip";
            Tip.Name = "Tip";
            // 
            // Koda
            // 
            Koda.DataPropertyName = "Koda";
            Koda.HeaderText = "Koda";
            Koda.Name = "Koda";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(217, 19);
            label1.Name = "label1";
            label1.Size = new Size(167, 37);
            label1.TabIndex = 2;
            label1.Text = "Lista uređaja";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 3;
            label2.Text = "Stanje uređaja:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(209, 41);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(197, 29);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(209, 19);
            label3.Name = "label3";
            label3.Size = new Size(181, 15);
            label3.TabIndex = 5;
            label3.Text = "Pretraga po evidencijskom broju:";
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.IndianRed;
            btnExit.Location = new Point(659, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(49, 48);
            btnExit.TabIndex = 24;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // cmsUredi
            // 
            cmsUredi.Items.AddRange(new ToolStripItem[] { urediToolStripMenuItem, izbrišiToolStripMenuItem });
            cmsUredi.Name = "contextMenuStrip1";
            cmsUredi.Size = new Size(105, 48);
            // 
            // urediToolStripMenuItem
            // 
            urediToolStripMenuItem.Name = "urediToolStripMenuItem";
            urediToolStripMenuItem.Size = new Size(104, 22);
            urediToolStripMenuItem.Text = "Uredi";
            // 
            // izbrišiToolStripMenuItem
            // 
            izbrišiToolStripMenuItem.Name = "izbrišiToolStripMenuItem";
            izbrišiToolStripMenuItem.Size = new Size(104, 22);
            izbrišiToolStripMenuItem.Text = "Izbriši";
            // 
            // cbDeleted
            // 
            cbDeleted.AutoSize = true;
            cbDeleted.Location = new Point(428, 51);
            cbDeleted.Name = "cbDeleted";
            cbDeleted.Size = new Size(108, 19);
            cbDeleted.TabIndex = 25;
            cbDeleted.Text = "Izbrisani uređaji";
            cbDeleted.UseVisualStyleBackColor = true;
            cbDeleted.CheckedChanged += cbDeleted_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbStateMachine);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbDeleted);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Location = new Point(12, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(696, 92);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pretraga";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(18, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(432, 69);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            // 
            // frmListaUredjaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 634);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnExit);
            Controls.Add(dgvLista);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmListaUredjaja";
            Text = "frmListaUredjaja";
            Load += frmListaUredjaja_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            cmsUredi.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvLista;
        private ComboBox cmbStateMachine;
        private DataGridViewTextBoxColumn EvBroj;
        private DataGridViewTextBoxColumn Tip;
        private DataGridViewTextBoxColumn Koda;
        private Label label1;
        private Label label2;
        private TextBox txtSearch;
        private Label label3;
        private Button btnExit;
        private ContextMenuStrip cmsUredi;
        private ToolStripMenuItem urediToolStripMenuItem;
        private ToolStripMenuItem izbrišiToolStripMenuItem;
        private CheckBox cbDeleted;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serijskibroj;
        private DataGridViewTextBoxColumn lokacija;
        private DataGridViewTextBoxColumn isDeleted;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}