using AutoMapper;
using Jironimo.Common.Models.Aplications;
using Jironimo.Common.Models.User;
using Jironimo.Web.Areas.Admin.Models;
using Jironimo.Web.ViewModels;

namespace Jironimo.Web.MappingProfile
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<LoginViewModel, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<Application, ApplicationViewModel>();
        }
    }
}
