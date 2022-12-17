using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services
{
    public class UredjajService : BaseCRUDService<UredjajVM, UredjajSearchObject, Uredjaj, UredjajUpsertRequest, UredjajUpsertRequest>,
        IUredjajService
    {

        public BaseState BaseState { get; set; }

        public UredjajService(_190128Context context, IMapper mapper, BaseState baseState) : base(context, mapper)
        {
            BaseState = baseState;

        }

        public override IQueryable<Uredjaj> AddInclude(IQueryable<Uredjaj> query, UredjajSearchObject search = null)
        {
            query = query.Include("Tip");

            return query;
        }

        public UredjajVM Parts(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);
            state.CurrentEntity = uredjaj;

            state.SpareParts();

            return Mapper.Map<UredjajVM>(uredjaj);
        }

        public UredjajLokacijaVM Posalji(UredjajLokacijaVM uredjajLokacija)
        {
            var state = BaseState.CreateState("ready");
            var uredjaj = Context.Uredjajs.Find(uredjajLokacija.UredjajId);
            state.CurrentEntity = uredjaj;

            state.Posalji(uredjajLokacija);

            return uredjajLokacija;
        }

        public override UredjajVM Insert(UredjajUpsertRequest insert)
        {
            var state = BaseState.CreateState("initial");

            return state.Insert(insert);
        }

        public override UredjajVM Update(int id, UredjajUpsertRequest update)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);
            state.CurrentEntity = uredjaj;
            state.Context = Context;

            state.Update(update);

            return GetById(id);
        }

        public UredjajVM VratiIzTaska(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);

            state.CurrentEntity = uredjaj;

            if(uredjaj.Status == "task")
            {
                state.Aktiviraj();
                return GetById(id);
            }

            return GetById(id);
        }

        public UredjajVM Aktiviraj(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);

            state.CurrentEntity = uredjaj;

            if (uredjaj.Status == "idle")
            {
                state.Aktiviraj();
                return GetById(id);
            }

            if (uredjaj.Status == "fix")
            {
                state.Ready();
                return GetById(id);
            }

            /*if (uredjaj.Status == "ready")
            {
                state.Posalji();
                return GetById(id);
            }
*/
            if (uredjaj.Status == "out")
            {
                state.Vrati();
                return GetById(id);
            }

            if(uredjaj.Status == "task")
            {
                state.Servisiraj();
                return GetById(id);
            }

            return GetById(id);
        }

        public override IQueryable<Uredjaj> AddFilter(IQueryable<Uredjaj> query, UredjajSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search.Tip != 0)
                filter = filter.Where(x => x.TipId == search.Tip);

            if (search.UredjajId != 0)
                filter = filter.Where(x => x.UredjajId == search.UredjajId);

            if(!string.IsNullOrEmpty(search.Status))
                filter = filter.Where(x => x.Status == search.Status);

            return filter;
        }
    }
}
