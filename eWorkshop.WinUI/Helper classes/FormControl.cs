using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI
{
    public class FormControl
    {
       public string ObaveznaVrijednost = "Obavezna vrijednost!"; 

        public void OpcijeTabele(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public int SelektujRedIVratiId(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            var selectedRow = dgv.Rows[index];

            int Id = (int)selectedRow.Cells[0].Value;

            return Id;
        }

        public void NovaFormaOpcije(Form forma)
        {
            forma.MdiParent = Form.ActiveForm;
            forma.Text = string.Empty;
            forma.Dock = DockStyle.Fill;
            forma.Show();
        }

        public bool CheckInput(ErrorProvider err, Control control, string msg)
        {
            bool flag = true;

            if(control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
            {
                flag = false;
            }

            if (control is ComboBox && (control as ComboBox).SelectedItem == null)
            {
                flag = false;
            }

            if (control is RichTextBox && string.IsNullOrEmpty((control as RichTextBox).Text))
            {
                flag = false;
            }

            if (!flag) {
                err.SetError(control, msg);
                return false;
            }

            err.Clear();
            return true;
        }
    }
}
