using eWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public interface IServisAdapter 
    {
        List<ServisIzvrsenFlutterVM> Servis(int id);
    }
}
