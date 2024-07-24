using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using eWorkshop.Services.RadniZadatakStateMachine;

namespace eWorkshop.Services
{

    public class RadniZadatakService : BaseCRUDService<RadniZadatakVM, RadniZadatakSearchObject, RadniZadatak, RadniZadatakUpsertRequest, RadniZadatakUpsertRequest>, IRadniZadatakService
    {
        public BaseState BaseState { get; set; }

        public RadniZadatakService(_190128Context context, IMapper mapper, BaseState state) : base(context, mapper)
        {
            BaseState = state;
        }

        public override RadniZadatakVM Insert(RadniZadatakUpsertRequest insert)
        {
            var state = BaseState.CreateState("initial");

            return state.Insert(insert);
        }

        public RadniZadatakVM Fakturisi(int id)
        {
            var zadatak = Context.RadniZadataks.Find(id);

            var state = BaseState.CreateState(zadatak.StateMachine);
            state.CurrentEntity = zadatak;  

            state.Fakturisi();

            return Mapper.Map<RadniZadatakVM>(zadatak);
        }

        public RadniZadatakVM Zavrsi(int id)
        {
            var zadatak = Context.RadniZadataks.Find(id);

            var zadatakUredjaj = Context.RadniZadatakUredjajs.Where(x => x.RadniZadatakId == zadatak.RadniZadatakId).ToList();

            foreach (var item in zadatakUredjaj)
            {
                var uredjaj = Context.Uredjajs.Find(item.UredjajId);

                if (item.Uredjaj.Status == "active" || item.Uredjaj.Status == "task")
                {
                    Context.RadniZadatakUredjajs.Remove(item);
                    Context.SaveChanges();
                }
                
                if(uredjaj.Status == "task")
                {
                    uredjaj.Status = "active";
                    Context.SaveChanges();
                }

                if(uredjaj.Status != "out" && uredjaj.Status != "active")
                {
                    uredjaj.Status = "ready";
                }

                Context.SaveChanges();
            }

            var state = BaseState.CreateState("active");
            state.CurrentEntity = zadatak;

            state.Zavrsi();

            return Mapper.Map<RadniZadatakVM>(zadatak);
        }

        public override IQueryable<RadniZadatak> AddFilter(IQueryable<RadniZadatak> query, RadniZadatakSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search != null && search.StateMachineArray.Length > 0)
            {
                filter = filter.Where(x => x.StateMachine == search.StateMachineArray[0] 
                || x.StateMachine == search.StateMachineArray[1]);
            }

            if (search != null && search.RadniZadatakId != 0)
            {
                filter = filter.Where(x => x.RadniZadatakId == search.RadniZadatakId);
            }

            if (search != null && !string.IsNullOrEmpty(search.StateMachine))
            {
                filter = filter.Where(x => x.StateMachine == search.StateMachine);
            }

            return filter;
        }

       
    }
}
