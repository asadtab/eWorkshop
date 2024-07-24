using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.RadniZadatakStateMachine
{
    public class InvoiceTaskState : BaseState
    {
        public InvoiceTaskState(IMapper mapper, IServiceProvider serviceProvider, _190128Context context) : base(mapper, serviceProvider, context)
        {
        }
    }
}
