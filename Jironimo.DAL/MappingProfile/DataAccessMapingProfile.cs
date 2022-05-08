using AutoMapper;
using Jironimo.Common.Models.Aplications;
using Jironimo.Common.Models.User;

namespace Jironimo.DAL.MappingProfile
{
    public class DataAccessMapingProfile : Profile
    {
        public DataAccessMapingProfile()
        {
            CreateMap<Application, Entities.Application>();

            CreateMap<Entities.User, User>();
            CreateMap<User, Entities.User>();
        }
    }
}
