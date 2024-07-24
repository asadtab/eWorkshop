using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Service
{
    public class BaseService
    {
        public ITokenService TokenService { get; set; }

        public BaseService(ITokenService tokenService)
        {
            TokenService = tokenService;
        }
    }
}
