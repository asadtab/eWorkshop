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

        public void OpcijeTabele(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
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
    }
}
