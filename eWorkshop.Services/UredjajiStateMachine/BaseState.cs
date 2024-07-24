using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.UredjajiStateMachine
{
    public class BaseState
    {

        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public Uredjaj CurrentEntity { get; set; }
        public string CurrentState { get; set; }
        public _190128Context Context { get; set; }
        public Servi Servis { get; set; }

        public BaseState(IServiceProvider serviceProvider, IMapper mapper, _190128Context context)
        {
            Mapper = mapper;
            ServiceProvider = serviceProvider;
            Context = context;
        }

        

        public virtual UredjajVM Insert(UredjajUpsertRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Update(UredjajUpsertRequest request)
        {
            throw new Exception("Not allowed");
        }

        public virtual void SpareParts()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Aktiviraj()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Servisiraj()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Ready()
        {
            throw new Exception("Not allowed");
        }
        public virtual void Deaktiviraj()
        {
            throw new Exception("Not allowed");
        }

        public virtual void Posalji(int id)
        {
            throw new Exception("Not allowed");
        }

        public virtual void Vrati()
        {
            throw new Exception("Not allowed");
        }
        public virtual void RadniZadatak()
        {
            throw new Exception("Not allowed");
        }

        public  BaseState CreateState(string state)
        {
            switch (state)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialDeviceState>();
                    break;
                case "idle":
                    return ServiceProvider.GetService<IdleDeviceState>();
                    break;
                case "active":
                    return ServiceProvider.GetService<ActiveDeviceState>();
                    break;
                case "task":
                    return ServiceProvider.GetService<TaskDeviceState>();
                    break;
                case "fix":
                    return ServiceProvider.GetService<FixDeviceState>(); ;
                    break;
                case "ready":
                    return ServiceProvider.GetService<ReadyDeviceState>();
                    break;
                case "out":
                    return ServiceProvider.GetService<OutDeviceState>();
                    break;
                case "parts":
                    return ServiceProvider.GetService<PartsDeviceState>();
                    break;
                default:
                    throw new Exception("Not supported!");
            }
            }
    }
}