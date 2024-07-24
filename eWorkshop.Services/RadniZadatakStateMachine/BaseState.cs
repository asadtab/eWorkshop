using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using eWorkshop.Services.UredjajiStateMachine;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.RadniZadatakStateMachine
{
    public class BaseState
    {
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public RadniZadatak CurrentEntity;
        public _190128Context Context { get; set; }

        public BaseState(IMapper mapper, IServiceProvider serviceProvider, _190128Context context)
        {
            Mapper = mapper;
            ServiceProvider = serviceProvider;
            Context = context;
        }

        public virtual RadniZadatakVM Insert(RadniZadatakUpsertRequest request)
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public virtual RadniZadatakVM Update(int id)
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public virtual RadniZadatakVM Update(RadniZadatakUpsertRequest request)
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public virtual void  Aktiviraj()
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public virtual void Zavrsi()
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public virtual void Fakturisi()
        {
            throw new Exception("Nedozvoljena akcija");
        }

        public BaseState CreateState(string state)
        {
            switch (state)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialTaskState>();
                    break;
                case "idle":
                    return ServiceProvider.GetService<IdleTaskState>();
                    break;
                case "active":
                    return ServiceProvider.GetService<ActiveTaskState>();
                    break;
                case "done":
                    return ServiceProvider.GetService<DoneTaskState>();
                    break;
                case "invoice":
                    return ServiceProvider.GetService<DoneTaskState>();
                    break;
                //case "invoice":
                    //return ServiceProvider.GetService<InvoiceTaskState>();
                default:
                    throw new Exception("Akcija ne postoji");
            }
        }
    }
}
