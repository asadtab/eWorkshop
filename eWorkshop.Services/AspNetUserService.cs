using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Model;
using eWorkshop.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eWorkshop.Services
{
    public class AspNetUserService: BaseCRUDService<AspNetUserVM, object, AspNetUser, AspNetUserInsertRequest, AspNetUserInsertRequest>, IAspNetUserService
    {


        public AspNetUserService(_190128Context context, IMapper mapper) : base(context, mapper)
        {

        }


/*        public override void BeforeInsert(AspNetUserInsertRequest insert, AspNetUser entity)
        {
            var salt = GenerateSalt();
            entity.PasswordHash = GenerateHash(insert.PasswordHash);
            entity.Id = Guid.NewGuid().ToString();

            base.BeforeInsert(insert, entity);
        }
*/
        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA256");
            byte[] hashBytes = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
