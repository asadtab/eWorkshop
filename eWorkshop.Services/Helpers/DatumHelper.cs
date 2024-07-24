using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.Helpers
{
    static class DatumHelper
    {
        static public string DatumFormat(DateTime? datum)
        {
            return datum?.ToString("dd'.'MM'.'yyyy");
        }
    }
}
