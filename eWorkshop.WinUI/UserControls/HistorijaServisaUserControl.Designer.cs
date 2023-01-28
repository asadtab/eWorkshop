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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Naziv = new System.Windows.Forms.ColumnHeader();
            this.Vrijednost = new System.Windows.Forms.ColumnHeader();
            this.Kom = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Naziv,
            this.Vrijednost,
            this.Kom});
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(203, 165);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Naziv
            // 
            this.Naziv.Text = "Naziv";
            // 
            // Vrijednost
            // 
            this.Vrijednost.Text = "Vrijednost";
            // 
            // Kom
            // 
            this.Kom.Text = "Kom";
            // 
            // HistorijaServisaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Name = "HistorijaServisaUserControl";
            this.Size = new System.Drawing.Size(206, 171);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private ColumnHeader Naziv;
        private ColumnHeader Vrijednost;
        private ColumnHeader Kom;
    }
}
