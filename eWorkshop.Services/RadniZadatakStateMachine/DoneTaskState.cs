using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.RadniZadatakStateMachine
{
    public class DoneTaskState : BaseState
    {
        public DoneTaskState(IMapper mapper, IServiceProvider serviceProvider, _190128Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override void Fakturisi()
        {
            CurrentEntity.StateMachine = "invoice";
            Context.SaveChanges();
        }
    }
}
