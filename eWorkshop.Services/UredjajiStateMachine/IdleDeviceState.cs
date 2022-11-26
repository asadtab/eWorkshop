using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.UredjajiStateMachine
{
    public class IdleDeviceState : BaseState
    {
        public IdleDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {
        }

        public override void Update(UredjajUpsertRequest request)
        {
            var set = Context.Set<Uredjaj>();

            Mapper.Map(request, CurrentEntity);
            CurrentEntity.Status = "idle";

            Context.SaveChanges();
        }

        public override void SpareParts()
        {
            CurrentEntity.Status = "parts";
            Context.SaveChanges();
        }

        public override void Aktiviraj()
        {
            CurrentEntity.Status = "active";
            Context.SaveChanges();
        }
    }
}
