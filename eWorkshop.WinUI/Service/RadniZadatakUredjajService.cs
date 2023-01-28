using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Service
{
    public class RadniZadatakUredjajService : APIService
    {
        public RadniZadatakUredjajService(string resource) : base(resource)
        {
        }

        public override Task<T> Get<T>(object search = null)
        {
            return base.Get<T>(search);
        }


    }
}
