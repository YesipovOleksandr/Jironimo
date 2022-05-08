using AutoMapper;
using Jironimo.Common.Models.Aplications;

namespace Jironimo.DAL.MappingProfile
{
    public class DataAccessMapingProfile : Profile
    {
        public DataAccessMapingProfile()
        {
            CreateMap<Application, Entities.Application>();
        }
    }
}
