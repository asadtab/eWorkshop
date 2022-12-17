using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class ReparacijaService : BaseCRUDService<ServisVM, object, Servi, ServisInsertRequest, ServisUpdateRequest>, IReparacijaService
    {
        public BaseState BaseState{ get; set; }

        public ReparacijaService(_190128Context context, IMapper mapper, BaseState baseState) : base(context, mapper)
        {
            BaseState = baseState;
        }

        public override IQueryable<Servi> AddInclude(IQueryable<Servi> query, object search = null)
        {
            query = query.Include("RadniZadatak");

            return query;
        }

        public override ServisVM Insert(ServisInsertRequest insert)
        {
            var entity = base.Insert(insert);

            foreach (var id in insert.KomponenteIdList)
            {
                IzvrseniServi servis = new IzvrseniServi();

                servis.KomponentaId = id;
                servis.ServisId = entity.ServisId;
                servis.Datum = entity.Datum;

                Context.Add(servis);
            }

            Context.SaveChanges();

            var uredjaj = Context.Uredjajs.Find(entity.UredjajId);

            var state = BaseState.CreateState(uredjaj.Status);
            state.CurrentEntity = uredjaj;
            state.Servisiraj();

            return entity;
        }
    }
}
