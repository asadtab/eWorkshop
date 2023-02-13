using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eWorkshop.Model;
using System.Net;

namespace eWorkshop.WinUI.Service
{
    public class APIService
    {
        private string Resource = null;
        public string EndPoint = "https://localhost:7189/";

        public static string username { get; set; } = null;
        public static string password { get; set; } = null;
        public APIService(string resource)
        {
            Resource = resource;
        }

        public virtual async Task<T> Get<T>(object search = null)
        {
            var query = "";
            if (search != null)
                query = await search.ToQueryString();

            var list = await $"{EndPoint}{Resource}?{query}".WithBasicAuth(username, password).GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{EndPoint}{Resource}/{id}".WithBasicAuth(username, password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            var result = await $"{EndPoint}{Resource}".WithBasicAuth(username, password).PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

        public async Task<T> Put<T>(object request)
        {
            var result = await $"{EndPoint}{Resource}".WithBasicAuth(username, password).PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
        public async Task Delete (int id)
        {
            await $"{EndPoint}{Resource}/{id}".WithBasicAuth(username, password).DeleteAsync();

            //return T;
        }

    }
}
