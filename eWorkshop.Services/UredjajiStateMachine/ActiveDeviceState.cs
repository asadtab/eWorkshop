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
    public class ActiveDeviceState : BaseState
    {
        public ActiveDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {
        }

        public override void SpareParts()
        {
            CurrentEntity.Status = "parts";
            Context.SaveChanges();
        }

        public override void Servisiraj()   
        {
            CurrentEntity.Status = "fix";
            Context.SaveChanges();
        }

        public override void RadniZadatak()
        {
            CurrentEntity.Status = "task";
            Context.SaveChanges();
        }

        public override void Deaktiviraj()
        {
            CurrentEntity.Status = "idle";
            Context.SaveChanges();
        }

        public override void Update(UredjajUpsertRequest request)
        {
            base.Update(request);
        }
    }
}
