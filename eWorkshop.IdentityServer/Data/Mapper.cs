using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Services.Database;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eWorkshop.IdentityServer.Data
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AspNetUserInsertRequest, IdentityUser>();
            CreateMap<IdentityUser, AspNetUserVM>();

        /*    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //  .ForMember(dest => dest.NormalizedUserName, opt => opt.MapFrom(src => src.NormalizedUserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));*/
        }
    }
}
