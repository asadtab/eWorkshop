using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.RadniZadatakStateMachine
{
    public class InitialTaskState : BaseState
    {
        public InitialTaskState(IMapper mapper, IServiceProvider serviceProvider, _190128Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override RadniZadatakVM Insert(RadniZadatakUpsertRequest request)
        {
            var set = Context.Set<RadniZadatak>();

            RadniZadatak entity = Mapper.Map<RadniZadatak>(request);

            CurrentEntity = entity;
            CurrentEntity.StateMachine = "idle";

            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<RadniZadatakVM>(entity);
        }
    }
}
