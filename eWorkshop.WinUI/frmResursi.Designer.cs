namespace eWorkshop.WinUI
{
    partial class frmResursi
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
            btnDodajNoviResurs = new Button();
            dgvResursi = new DataGridView();
            Name = new DataGridViewTextBoxColumn();
            DisplayName = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResursi).BeginInit();
            SuspendLayout();
            // 
            // btnDodajNoviResurs
            // 
            btnDodajNoviResurs.Location = new Point(596, 155);
            btnDodajNoviResurs.Name = "btnDodajNoviResurs";
            btnDodajNoviResurs.Size = new Size(112, 23);
            btnDodajNoviResurs.TabIndex = 4;
            btnDodajNoviResurs.Text = "Dodaj novi resurs";
            btnDodajNoviResurs.UseVisualStyleBackColor = true;
            btnDodajNoviResurs.Click += btnDodajNoviResurs_Click;
            // 
            // dgvResursi
            // 
            dgvResursi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResursi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResursi.Columns.AddRange(new DataGridViewColumn[] { Name, DisplayName, Description });
            dgvResursi.Location = new Point(12, 184);
            dgvResursi.Name = "dgvResursi";
            dgvResursi.RowTemplate.Height = 25;
            dgvResursi.Size = new Size(696, 342);
            dgvResursi.TabIndex = 3;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Id";
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // DisplayName
            // 
            DisplayName.DataPropertyName = "DisplayName";
            DisplayName.HeaderText = "Naziv";
            DisplayName.Name = "DisplayName";
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Opis";
            Description.Name = "Description";
            // 
            // frmResursi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 634);
            Controls.Add(btnDodajNoviResurs);
            Controls.Add(dgvResursi);
            FormBorderStyle = FormBorderStyle.None;
            Name = new DataGridViewTextBoxColumn();
            Text = "frmResursi";
            Load += frmResursi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvResursi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDodajNoviResurs;
        private DataGridView dgvResursi;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn DisplayName;
        private DataGridViewTextBoxColumn Description;
    }
}