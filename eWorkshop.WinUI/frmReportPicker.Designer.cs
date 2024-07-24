namespace eWorkshop.WinUI
{
    partial class frmReportPicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

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
            btnPotvrdi = new Button();
            cbDeleted = new CheckBox();
            label3 = new Label();
            txtSearch = new TextBox();
            label2 = new Label();
            cmbStateMachine = new ComboBox();
            dgvLista = new DataGridView();
            pick = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            serijskibroj = new DataGridViewTextBoxColumn();
            lokacija = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(608, 123);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(75, 29);
            btnPotvrdi.TabIndex = 2;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // cbDeleted
            // 
            cbDeleted.AutoSize = true;
            cbDeleted.Location = new Point(600, -19);
            cbDeleted.Name = "cbDeleted";
            cbDeleted.Size = new Size(108, 19);
            cbDeleted.TabIndex = 31;
            cbDeleted.Text = "Izbrisani uređaji";
            cbDeleted.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, -37);
            label3.Name = "label3";
            label3.Size = new Size(181, 15);
            label3.TabIndex = 30;
            label3.Text = "Pretraga po evidencijskom broju:";
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(248, 122);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(197, 29);
            txtSearch.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, -37);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 28;
            label2.Text = "Stanje uređaja:";
            // 
            // cmbStateMachine
            // 
            cmbStateMachine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStateMachine.FormattingEnabled = true;
            cmbStateMachine.Location = new Point(45, 122);
            cmbStateMachine.Name = "cmbStateMachine";
            cmbStateMachine.Size = new Size(197, 29);
            cmbStateMachine.TabIndex = 27;
            cmbStateMachine.SelectedIndexChanged += cmbStateMachine_SelectedIndexChanged;
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.AllowUserToResizeColumns = false;
            dgvLista.AllowUserToResizeRows = false;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { pick, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, serijskibroj, lokacija });
            dgvLista.Location = new Point(45, 170);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.Size = new Size(638, 428);
            dgvLista.TabIndex = 26;
            dgvLista.CellContentClick += dgvLista_CellContentClick;
            // 
            // pick
            // 
            pick.DataPropertyName = "isSelected";
            pick.HeaderText = "Odaberi";
            pick.Name = "pick";
            pick.ReadOnly = true;
            pick.Width = 60;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 99);
            label1.Name = "label1";
            label1.Size = new Size(181, 15);
            label1.TabIndex = 33;
            label1.Text = "Pretraga po evidencijskom broju:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 99);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 32;
            label4.Text = "Stanje uređaja:";
            // 
            // frmReportPicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 634);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(cbDeleted);
            Controls.Add(label3);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(cmbStateMachine);
            Controls.Add(dgvLista);
            Controls.Add(btnPotvrdi);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReportPicker";
            Text = "frmReportPicker";
            Load += frmReportPicker_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPotvrdi;
        private CheckBox cbDeleted;
        private Label label3;
        private TextBox txtSearch;
        private Label label2;
        private ComboBox cmbStateMachine;
        private DataGridView dgvLista;
        private Label label1;
        private Label label4;
        private DataGridViewCheckBoxColumn pick;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serijskibroj;
        private DataGridViewTextBoxColumn lokacija;
    }
}