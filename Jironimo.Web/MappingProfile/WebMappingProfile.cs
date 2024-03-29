﻿using AutoMapper;
using Jironimo.Common.Models.Aplications;
using Jironimo.Common.Models.Developers;
using Jironimo.Common.Models.User;
using Jironimo.Web.Areas.Admin.Models.Account;
using Jironimo.Web.Areas.Admin.Models.Application;
using Jironimo.Web.Areas.Admin.Models.ApplicationDetails;
using Jironimo.Web.Areas.Admin.Models.Categories;
using Jironimo.Web.Areas.Admin.Models.Developers;
using Jironimo.Web.ViewModels;
using Jironimo.Web.ViewModels.ApplicationDetails;

namespace Jironimo.Web.MappingProfile
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<LoginViewModel, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Application, ApplicationViewModel>()
                .ForMember(dest => dest.CategoryName, act => act.MapFrom(src => src.Category.Name));
            CreateMap<ApplicationDetails, ApplicationDetailsModel>();
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<ApplicationDetailsCreateViewModel, ApplicationDetails>();
            
            //admin            
            CreateMap<ApplicationCreateViewModel, Application>();
            CreateMap<Application, ApplicationEditViewModel>().ReverseMap();
            CreateMap<CategoryCreateViewModel, Category>().ReverseMap();
            CreateMap<DeveloperCreateViewModel, Developer>().ReverseMap();
            CreateMap<Developer, DeveloperListSelect>().ReverseMap();
        
        }
    }
}
