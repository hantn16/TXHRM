using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.WebAPI.Models;

namespace TXHRM.WebAPI.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PostCategory, PostCategoryViewModel>().PreserveReferences();
                cfg.CreateMap<Post, PostViewModel>().PreserveReferences();
                cfg.CreateMap<PostViewModel, PostViewModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<PostTag, PostTagViewModel>().PreserveReferences();
                cfg.CreateMap<Tag, TagViewModel>().PreserveReferences();
                cfg.CreateMap<AppRole, AppRoleViewModel>().PreserveReferences();
                cfg.CreateMap<AppRole, AppRoleViewModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<AppUser, AppUserViewModel>().PreserveReferences();
                cfg.CreateMap<Function, FunctionViewModel>().PreserveReferences();
                cfg.CreateMap<Function, FunctionViewModel>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Permission, PermissionViewModel>().PreserveReferences();
            });
        }
    }
}