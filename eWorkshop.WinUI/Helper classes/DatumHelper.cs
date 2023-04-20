using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.WinUI.Helper_classes
{
    static class DatumHelper
    {
        static string DatumFormat(DateTime datum)
        {
            return datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
        }
    }
}
