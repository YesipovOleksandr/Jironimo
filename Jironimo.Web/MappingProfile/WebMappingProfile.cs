using AutoMapper;
using Jironimo.Common.Models.Aplications;
using Jironimo.Web.ViewModels;

namespace Jironimo.Web.MappingProfile
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Application, ApplicationViewModel>();
        }
    }
}
