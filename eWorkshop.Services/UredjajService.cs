using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            query = query.Include("Lokacija");  

            return query;
        }

        public override UredjajVM GetById(int id)
        {
            var uredjaj = Context.Uredjajs.Include(x => x.Tip).Include(x => x.Lokacija).FirstOrDefault(x => x.UredjajId == id);

            return Mapper.Map<UredjajVM>(uredjaj);
        }

        public UredjajVM Parts(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);
            state.CurrentEntity = uredjaj;

            state.SpareParts();

            return Mapper.Map<UredjajVM>(uredjaj);
        }

        public void Posalji(int id)
        {
            var state = BaseState.CreateState("ready");
            var uredjaj = Context.Uredjajs.Find(id);
            state.CurrentEntity = uredjaj;

            state.Posalji(id);

            //return uredjajLokacija;
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

            var radniZadatakUredjaj = Context.RadniZadatakUredjajs.Where(x => x.UredjajId == id).FirstOrDefault();
            Context.RadniZadatakUredjajs.Remove(radniZadatakUredjaj);
            Context.SaveChanges();
            

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

            if (uredjaj.Status == "parts")
            {
                state.Aktiviraj();
                return GetById(id);
            }

            return GetById(id);
        }

        public override IQueryable<Uredjaj> AddFilter(IQueryable<Uredjaj> query, UredjajSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search != null && search.Tip != 0)
                filter = filter.Where(x => x.TipId == search.Tip);

            if (search != null && search.UredjajId != 0)
                filter = filter.Where(x => x.UredjajId == search.UredjajId);

            if (search != null && !string.IsNullOrEmpty(search.Status))
                filter = filter.Where(x => x.Status == search.Status);

            if (search != null && !string.IsNullOrEmpty(search.Naziv))
                filter = filter.Where(x => x.Tip.Naziv.ToLower().Contains(search.Naziv.ToLower()));

            if (search != null && !string.IsNullOrEmpty(search.Koda))
                filter = filter.Where(x => x.Koda.Contains(search.Koda));

            if (search != null && !string.IsNullOrEmpty(search.Opis))
                filter = filter.Where(x => x.Tip.Opis.Contains(search.Opis));

            if (search != null && !string.IsNullOrEmpty(search.LokacijaNaziv))
                filter = filter.Where(x => x.Lokacija.Naziv.Contains(search.LokacijaNaziv));

            if (search != null)
                filter = filter.Where(x => x.IsDeleted == search.isDeleted);

            if (search != null && search.GetNajveciEvBroj)
            {
                filter = filter.OrderByDescending(x => x.UredjajId);
            }

                return filter;
        }

        public UredjajVM Deaktiviraj(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            var state = BaseState.CreateState(uredjaj.Status);
            state.CurrentEntity = uredjaj;
            state.Context = Context;

            state.Deaktiviraj();

            return GetById(id);
        }

        public override UredjajVM Delete(int id)
        {
            var uredjaj = Context.Uredjajs.Find(id);

            if (uredjaj == null)
                return null;

            uredjaj.IsDeleted = true;
            Context.SaveChanges();

            return Mapper.Map<UredjajVM>(uredjaj);
        }
    }
}
