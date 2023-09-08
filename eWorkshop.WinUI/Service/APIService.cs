using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.Model;
using System.Net;
using Microsoft.Extensions.Logging;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace eWorkshop.WinUI.Service
{
    public class APIService
    {
        private string Resource = null;
        public string EndPoint = "https://localhost:7189/";
        public string EndPointIds = "https://localhost:5443/";

        public ITokenService TokenService { get; set; }

        public static KorisniciVM Korisnik;

        public static string username { get; set; } = null;
        public static string password { get; set; } = null;



        public APIService(string resource, ITokenService tokenService = null, bool server = false)
        {
            if (server)
            {
                EndPoint = EndPointIds;
            }

            Resource = resource;
            TokenService = tokenService;
        }

        public virtual async Task<T> Get<T>(object search = null)
        {
            var token = await TokenService.GetToken("weatherapi.read");

            var query = "";
            if (search != null)
                query = await search.ToQueryString();

            //var list = await $"{EndPoint}{Resource}?{query}".WithBasicAuth(username, password).GetJsonAsync<T>();
            var list2 = await $"{EndPoint}{Resource}?{query}".WithOAuthBearerToken(token.AccessToken).GetJsonAsync<T>();

            return list2;
        }

        public async Task<T> GetById<T>(object id)
        {
            var token = await TokenService.GetToken("weatherapi.read");


            var result = await $"{EndPoint}{Resource}/{id}".WithOAuthBearerToken(token.AccessToken).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            var token = await TokenService.GetToken("weatherapi.read");

            var result = await $"{EndPoint}{Resource}".WithOAuthBearerToken(token.AccessToken).PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

        public async Task<T> Put<T>(object request)
        {
            var token = await TokenService.GetToken("weatherapi.read");

            var result = await $"{EndPoint}{Resource}".WithOAuthBearerToken(token.AccessToken).PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
        public async Task Delete (int id)
        {
            var token = await TokenService.GetToken("weatherapi.read");

            await $"{EndPoint}{Resource}/{id}".WithOAuthBearerToken(token.AccessToken).DeleteAsync();
        }

    }
}
