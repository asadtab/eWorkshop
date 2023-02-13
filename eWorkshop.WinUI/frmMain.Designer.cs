namespace eWorkshop.WinUI
{
    partial class frmMain
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
            this.flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNoviRadniZadatak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flPanel
            // 
            this.flPanel.AutoScroll = true;
            this.flPanel.Location = new System.Drawing.Point(155, 97);
            this.flPanel.Name = "flPanel";
            this.flPanel.Size = new System.Drawing.Size(633, 266);
            this.flPanel.TabIndex = 0;
            // 
            // btnNoviRadniZadatak
            // 
            this.btnNoviRadniZadatak.Location = new System.Drawing.Point(3, 214);
            this.btnNoviRadniZadatak.Name = "btnNoviRadniZadatak";
            this.btnNoviRadniZadatak.Size = new System.Drawing.Size(146, 23);
            this.btnNoviRadniZadatak.TabIndex = 2;
            this.btnNoviRadniZadatak.Text = "Dodaj novi radni zadatak";
            this.btnNoviRadniZadatak.UseVisualStyleBackColor = true;
            this.btnNoviRadniZadatak.Click += new System.EventHandler(this.btnNoviRadniZadatak_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnNoviRadniZadatak);
            this.Controls.Add(this.flPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flPanel;
        private Button btnNoviRadniZadatak;
    }
}