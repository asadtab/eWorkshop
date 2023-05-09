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

namespace eWorkshop.WinUI
{
    public partial class frmKomponenteLista : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public frmKomponenteLista(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }
    }
}
