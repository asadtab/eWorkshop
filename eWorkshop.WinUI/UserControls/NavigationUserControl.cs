using eWorkshop.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eWorkshop.WinUI.UserControls
{
    public partial class NavigationUserControl : UserControl
    {
        public Stack<Form> FormStack { get; set; } = new Stack<Form>();
        public FormControl FormControl { get; set; } = new FormControl();

        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public NavigationUserControl(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();

           ServiceProvider = serviceProvider;
           TokenService = tokenService;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form closedForm = (Form)sender;
            FormStack = new Stack<Form>(FormStack.Where(form => !form.Equals(closedForm)));
            //UpdateButtons();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (FormStack.Count > 1)
            {
                var form = FormStack.Pop();
                form.Hide();

                Form prevForm = FormStack.Peek();

                FormControl.NovaFormaOpcije(prevForm);
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (FormStack.Count > 1)
            {
                Form nextForm = FormStack.ElementAt(FormStack.Count - 2);
                FormControl.NovaFormaOpcije(nextForm);
                //UpdateButtons();
            }
        }
    
        public void AddForm(Form form)
        {
            FormStack.Push(form);
            form.FormClosed += Form_FormClosed;
            form.Show();
        }
    }
}
