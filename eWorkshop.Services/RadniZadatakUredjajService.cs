using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
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
    public class RadniZadatakUredjajService : BaseCRUDService<RadniZadatakUredjajBasicVM, RadniZadatakUredjajSearchObject, RadniZadatakUredjaj, RadniZadatakUredjajUpsertRequest, RadniZadatakUredjajUpsertRequest>, IRadniZadatakUredjajService
    {
        public BaseState BaseState{ get; set; }
        public RadniZadatakStateMachine.BaseState RadniZadatakBaseState{ get; set; }

        public RadniZadatakUredjajService(_190128Context context, IMapper mapper, BaseState state, RadniZadatakStateMachine.BaseState radniZadatakBaseState) : base(context, mapper)
        {
            BaseState = state;
            RadniZadatakBaseState = radniZadatakBaseState;
        }

        public override IQueryable<RadniZadatakUredjaj> AddInclude(IQueryable<RadniZadatakUredjaj> query, RadniZadatakUredjajSearchObject search = null)
        {
            query = query.Include("RadniZadatak").Include("Uredjaj.Tip");
            query = query.Include("Uredjaj.Lokacija");

            return query;
        }

        public override IQueryable<RadniZadatakUredjaj> AddFilter(IQueryable<RadniZadatakUredjaj> query, RadniZadatakUredjajSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (search.RadniZadatakId != null && search.RadniZadatakId != 0)
                filter = filter.Where(x => x.RadniZadatakId == search.RadniZadatakId);

            if (search.UredjajId != null && search.UredjajId != 0)
                filter = filter.Where(x => x.UredjajId == search.UredjajId);

            if (search.KorisnikId != null && search.KorisnikId != 0)
                filter = filter.Where(x => x.KorisnikId == search.KorisnikId);

            if (!string.IsNullOrEmpty(search.UredjajState))
                filter = filter.Where(x => x.Uredjaj.Status == search.UredjajState);

            if (search.ZadatakState.Length > 0)
            {
                /*for (int i = 0; i < search.ZadatakState.Length; i++)
                    filter = filter.Where(x => x.RadniZadatak.StateMachine == search.ZadatakState[i]);
*/
                filter = filter.Where(x => x.RadniZadatak.StateMachine == search.ZadatakState[0] 
                || x.RadniZadatak.StateMachine == search.ZadatakState[1]);
               // filter = filter.Where(x => x.RadniZadatak.StateMachine == search.ZadatakState[1]);
            }

            return filter;
        }

        public RadniZadatakUredjajBasicVM Dodaj(RadniZadatakUredjajUpsertRequest request)
        {
            var uredjaj = Context.Uredjajs.Find(request.UredjajId);
            var stateUredjaj = BaseState.CreateState(uredjaj.Status);
            stateUredjaj.CurrentEntity = uredjaj;
            stateUredjaj.Context = Context;

            var radniZadatak = Context.RadniZadataks.Find(request.RadniZadatakId);

            if (radniZadatak.StateMachine == "idle")
            {
                var stateRadniZadatak = RadniZadatakBaseState.CreateState("active");
                stateRadniZadatak.CurrentEntity = radniZadatak;
                stateRadniZadatak.Context = Context;

                stateRadniZadatak.Aktiviraj();
            }

            stateUredjaj.RadniZadatak();

            return base.Insert(request);

            //return Mapper.Map<RadniZadatakUredjajVM>(request);
        }
    }
}