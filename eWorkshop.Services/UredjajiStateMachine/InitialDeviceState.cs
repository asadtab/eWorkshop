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
    public class InitialDeviceState : BaseState
    {
        public InitialDeviceState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context) : base(serviceProvider, mapper, context)
        {}

        public override UredjajVM Insert(UredjajUpsertRequest request)
        {
            var set = Context.Set<Uredjaj>();

            Uredjaj entity = Mapper.Map<Uredjaj>(request);

            CurrentEntity = entity;
            CurrentEntity.Status = "idle";

            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<UredjajVM>(entity);
        }

    }
}
