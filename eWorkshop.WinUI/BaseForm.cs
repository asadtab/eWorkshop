using eWorkshop.WinUI.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI
{
    public partial class BaseForm : Form
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly ITokenService TokenService;

        public BaseForm()
        {
            
        }
        public BaseForm(IServiceProvider serviceProvider, ITokenService tokenService)
        {
            ServiceProvider = serviceProvider;
            TokenService = tokenService;
        }
    }
}
