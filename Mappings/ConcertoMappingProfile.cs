using AutoMapper;
using KMF.ApplicationUser;
using KMF.Entities;
using KMF.Models;

namespace KMF.Mappings
{
    public class ConcertoMappingProfile : Profile
    {
        public ConcertoMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<Concerto, ConcertoDto>()
                .ForMember(c => c.IsEditable, options => options.MapFrom(source => user != null && user.Email == "osiedle5@wp.pl"
                    || user!.Email == "j.chmiel2006@gmail.com" || user.IsInRole("Admin")))
                .ReverseMap();
        }
    }
}
