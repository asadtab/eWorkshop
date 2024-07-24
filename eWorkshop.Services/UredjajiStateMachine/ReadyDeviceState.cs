using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.UredjajiStateMachine
{
    public class ReadyDeviceState : BaseState
    {
        public ReadyDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {
        }

        public override void Posalji(int id)
        {
            //CurrentEntity.LokacijaId = uredjajLokacija.LokacijaId;
            CurrentEntity.Status = "out";
            Context.SaveChanges();
        }

        public override void Servisiraj()
        {
            CurrentEntity.Status = "fix";
            Context.SaveChanges();
        }
    }
}
