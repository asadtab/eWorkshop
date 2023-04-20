namespace eWorkshop.WinUI.UserControls
{
    partial class HistorijaServisaUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlLista = new Panel();
            lvKomponente = new ListView();
            Naziv = new ColumnHeader();
            Vrijednost = new ColumnHeader();
            Koda = new ColumnHeader();
            btnDatum = new Button();
            lblServiser = new Label();
            label1 = new Label();
            pnlLista.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLista
            // 
            pnlLista.Controls.Add(lvKomponente);
            pnlLista.Dock = DockStyle.Bottom;
            pnlLista.Location = new Point(0, 64);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(250, 201);
            pnlLista.TabIndex = 0;
            // 
            // lvKomponente
            // 
            lvKomponente.Columns.AddRange(new ColumnHeader[] { Naziv, Vrijednost, Koda });
            lvKomponente.Dock = DockStyle.Top;
            lvKomponente.Location = new Point(0, 0);
            lvKomponente.Name = "lvKomponente";
            lvKomponente.Size = new Size(250, 198);
            lvKomponente.TabIndex = 0;
            lvKomponente.UseCompatibleStateImageBehavior = false;
            lvKomponente.View = View.Details;
            // 
            // Naziv
            // 
            Naziv.Text = "Naziv";
            // 
            // Vrijednost
            // 
            Vrijednost.Text = "Vrijednost";
            Vrijednost.Width = 70;
            // 
            // Koda
            // 
            Koda.Text = "Koda";
            // 
            // btnDatum
            // 
            btnDatum.Dock = DockStyle.Top;
            btnDatum.FlatAppearance.BorderColor = Color.Gray;
            btnDatum.FlatStyle = FlatStyle.Flat;
            btnDatum.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDatum.Location = new Point(0, 0);
            btnDatum.Name = "btnDatum";
            btnDatum.Size = new Size(250, 37);
            btnDatum.TabIndex = 1;
            btnDatum.Text = "button1";
            btnDatum.UseVisualStyleBackColor = true;
            btnDatum.Click += button1_Click;
            // 
            // lblServiser
            // 
            lblServiser.AutoSize = true;
            lblServiser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblServiser.Location = new Point(91, 40);
            lblServiser.Name = "lblServiser";
            lblServiser.Size = new Size(52, 21);
            lblServiser.TabIndex = 1;
            lblServiser.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 40);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 2;
            label1.Text = "Servisirao:";
            // 
            // HistorijaServisaUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(lblServiser);
            Controls.Add(btnDatum);
            Controls.Add(pnlLista);
            Name = "HistorijaServisaUserControl";
            Size = new Size(250, 265);
            pnlLista.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlLista;
        private ListView lvKomponente;
        private ColumnHeader Naziv;
        private ColumnHeader Vrijednost;
        private Button btnDatum;
        private ColumnHeader Koda;
        private Label lblServiser;
        private Label label1;
    }
}
