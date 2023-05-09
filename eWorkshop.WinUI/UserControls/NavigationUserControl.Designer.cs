namespace eWorkshop.WinUI.UserControls
{
    partial class NavigationUserControl
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 49);
            button1.TabIndex = 0;
            button1.Text = "<-";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.System;
            button2.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(84, 3);
            button2.Name = "button2";
            button2.Size = new Size(75, 49);
            button2.TabIndex = 1;
            button2.Text = "->";
            button2.UseVisualStyleBackColor = false;
            // 
            // NavigationUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "NavigationUserControl";
            Size = new Size(163, 55);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}
