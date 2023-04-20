using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI
{
    public partial class frmPotvrda : Form
    {
        public frmPotvrda()
        {
            InitializeComponent();
        }

        public static DialogResult Show(string question, string btnPotvrdaString, string btnPonistiString)
        {
            using (frmPotvrda dialog = new frmPotvrda())
            {
                dialog.lblUpit.Text = question;
                dialog.btnConfirm.Text = btnPotvrdaString;
                dialog.btnCancel.Text = btnPonistiString;
                DialogResult result = dialog.ShowDialog();
                return result;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
