using AutoMapper;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.UredjajiStateMachine
{
    public class OutDeviceState : BaseState
    {
        public OutDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {
        }

        public override void Vrati()
        {
            CurrentEntity.Status = "active";
            Context.SaveChanges();
        }
    }
}
