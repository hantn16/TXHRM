using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.Web.Models;
using TXHRM.Web.Models.Common;
using TXHRM.Web.Models.Post;
using TXHRM.Web.Models.System;

namespace TXHRM.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategoryViewModel, PostCategory>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
                cfg.CreateMap<Footer, FooterViewModel>();
                cfg.CreateMap<Slide, SlideViewModel>();
                cfg.CreateMap<Page, PageViewModel>();
                cfg.CreateMap<AppRole, AppRoleViewModel>();
                cfg.CreateMap<AppUser, AppUserViewModel>();
                cfg.CreateMap<Function, FunctionViewModel>();
                cfg.CreateMap<Permission, PermissionViewModel>();

            });
        }
    }
}