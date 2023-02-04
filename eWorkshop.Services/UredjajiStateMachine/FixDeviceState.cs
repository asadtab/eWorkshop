using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.UredjajiStateMachine
{
    public class FixDeviceState : BaseState
    {
        public FixDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {
        }

        public override void Ready()
        {
            CurrentEntity.Status = "ready";
            Context.SaveChanges();
        }

        public override void Servisiraj()
        {
            CurrentEntity.Status = "fix";
            Context.SaveChanges();
        }
    }
}
