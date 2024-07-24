namespace eWorkshop.WinUI
{
    partial class frmKomponenteLista
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
            btnExit = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            cmbStateMachine = new ComboBox();
            dgvLista = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            serijskibroj = new DataGridViewTextBoxColumn();
            lokacija = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.IndianRed;
            btnExit.Location = new Point(699, -78);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(49, 48);
            btnExit.TabIndex = 31;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(215, 79);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 30;
            label3.Text = "Pretraga:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(215, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 29);
            textBox1.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 28;
            label2.Text = "Stanje uređaja:";
            // 
            // cmbStateMachine
            // 
            cmbStateMachine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbStateMachine.FormattingEnabled = true;
            cmbStateMachine.Location = new Point(12, 97);
            cmbStateMachine.Name = "cmbStateMachine";
            cmbStateMachine.Size = new Size(197, 29);
            cmbStateMachine.TabIndex = 26;
            // 
            // dgvLista
            // 
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, serijskibroj, lokacija });
            dgvLista.Location = new Point(12, 132);
            dgvLista.Name = "dgvLista";
            dgvLista.ReadOnly = true;
            dgvLista.RowTemplate.Height = 25;
            dgvLista.Size = new Size(545, 493);
            dgvLista.TabIndex = 25;
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
            dataGridViewTextBoxColumn3.HeaderText = "Vrsta";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // serijskibroj
            // 
            serijskibroj.DataPropertyName = "SerijskiBroj";
            serijskibroj.HeaderText = "Vrijednost";
            serijskibroj.Name = "serijskibroj";
            serijskibroj.ReadOnly = true;
            // 
            // lokacija
            // 
            lokacija.DataPropertyName = "LokacijaNaziv";
            lokacija.HeaderText = "Koda";
            lokacija.Name = "lokacija";
            lokacija.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(232, 9);
            label1.Name = "label1";
            label1.Size = new Size(222, 37);
            label1.TabIndex = 32;
            label1.Text = "Lista komponenti";
            // 
            // frmKomponenteLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 634);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(cmbStateMachine);
            Controls.Add(dgvLista);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmKomponenteLista";
            Text = "frmKomponenteLista";
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private ComboBox cmbStateMachine;
        private DataGridView dgvLista;
        private Label label1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serijskibroj;
        private DataGridViewTextBoxColumn lokacija;
    }
}