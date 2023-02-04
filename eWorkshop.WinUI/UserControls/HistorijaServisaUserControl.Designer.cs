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
            this.pnlLista = new System.Windows.Forms.Panel();
            this.lvKomponente = new System.Windows.Forms.ListView();
            this.Naziv = new System.Windows.Forms.ColumnHeader();
            this.Vrijednost = new System.Windows.Forms.ColumnHeader();
            this.Koda = new System.Windows.Forms.ColumnHeader();
            this.btnDatum = new System.Windows.Forms.Button();
            this.pnlLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.lvKomponente);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLista.Location = new System.Drawing.Point(0, 18);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(250, 201);
            this.pnlLista.TabIndex = 0;
            // 
            // lvKomponente
            // 
            this.lvKomponente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Naziv,
            this.Vrijednost,
            this.Koda});
            this.lvKomponente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvKomponente.Location = new System.Drawing.Point(0, 34);
            this.lvKomponente.Name = "lvKomponente";
            this.lvKomponente.Size = new System.Drawing.Size(250, 167);
            this.lvKomponente.TabIndex = 0;
            this.lvKomponente.UseCompatibleStateImageBehavior = false;
            this.lvKomponente.View = System.Windows.Forms.View.Details;
            // 
            // Naziv
            // 
            this.Naziv.Text = "Naziv";
            // 
            // Vrijednost
            // 
            this.Vrijednost.Text = "Vrijednost";
            this.Vrijednost.Width = 70;
            // 
            // Koda
            // 
            this.Koda.Text = "Koda";
            // 
            // btnDatum
            // 
            this.btnDatum.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatum.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDatum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDatum.Location = new System.Drawing.Point(0, 0);
            this.btnDatum.Name = "btnDatum";
            this.btnDatum.Size = new System.Drawing.Size(250, 37);
            this.btnDatum.TabIndex = 1;
            this.btnDatum.Text = "button1";
            this.btnDatum.UseVisualStyleBackColor = true;
            this.btnDatum.Click += new System.EventHandler(this.button1_Click);
            // 
            // HistorijaServisaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDatum);
            this.Controls.Add(this.pnlLista);
            this.Name = "HistorijaServisaUserControl";
            this.Size = new System.Drawing.Size(250, 219);
            this.pnlLista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlLista;
        private ListView lvKomponente;
        private ColumnHeader Naziv;
        private ColumnHeader Vrijednost;
        private Button btnDatum;
        private ColumnHeader Koda;
    }
}
