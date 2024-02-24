using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eWorkshop.Services.IDS
{
    public class ClientService : BaseCRUDService<ClientVM, ClientSearchObject, Client, ClientInsertRequest, ClientInsertRequest>, IClientService
    {
        public ClientService(_190128Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override ClientVM Update(int id, ClientInsertRequest update)
        {
            foreach (var grantTypeRequest in update.ClientGrantTypes)
            {
                var existingGrantType =
                    Context.ClientGrantTypes.FirstOrDefault(x =>x.ClientId == id && x.GrantType == grantTypeRequest.GrantType);

                if (existingGrantType != null) 
                {
                    Mapper.Map(grantTypeRequest, existingGrantType);
                } else
                {
                    var newGrantType = Mapper.Map<ClientGrantType>(grantTypeRequest);
                    newGrantType.ClientId = id;
                    Context.ClientGrantTypes.Add(newGrantType);
                    Context.SaveChanges();
                }
            }

            foreach (var clientScopesRequest in update.ClientScopes)
            {
                var existingClientScope = Context.ClientScopes.FirstOrDefault(x => x.ClientId == id && x.Scope == clientScopesRequest.Scope);

                if (existingClientScope != null)
                {
                    Mapper.Map(clientScopesRequest, existingClientScope);
                }
                else
                {
                    var newClientScope = Mapper.Map<ClientScope>(clientScopesRequest);
                    newClientScope.ClientId = id;
                    Context.ClientScopes.Add(newClientScope);
                    Context.SaveChanges();
                }
            }

            var requestUpdate = new ClientUpsertRequest() 
            { 
                AllowOfflineAccess = update.AllowOfflineAccess,
                ClientId = update.ClientId,
                RequireClientSecret = update.RequireClientSecret,
                ClientName = update.ClientName,
                ClientUri = update.ClientUri,
                Enabled = update.Enabled,
                ProtocolType = update.ProtocolType,
                RequirePkce = update.RequirePkce
            };

            var entity = Context.Clients.Find(id);

            if (entity != null)
                Mapper.Map(requestUpdate, entity);
            else
                return null;

            Context.SaveChanges();

            return Mapper.Map<ClientVM>(entity);
        }

        public override IQueryable<Client> AddFilter(IQueryable<Client> query, ClientSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search != null && !string.IsNullOrEmpty(search.Naziv))
            {
                filter = filter.Where(x => x.ClientName.ToLower().Contains(search.Naziv.ToLower()));
            }

            if (search != null && !string.IsNullOrEmpty(search.Id))
            {
                filter = filter.Where(x => x.ClientId.ToLower().Contains(search.Id.ToLower()));
            }

            return filter;
        }
    }
}
