using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Services.Database;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.RadniZadatakStateMachine
{
    public class IdleTaskState : BaseState
    {
        public IdleTaskState(IMapper mapper, IServiceProvider serviceProvider, _190128Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override void Aktiviraj()
        {
            CurrentEntity.StateMachine = "active";
            Context.SaveChanges();
        }

        public override RadniZadatakVM Update(int id)
        {
            return base.Update(id);
        }
    }
}
