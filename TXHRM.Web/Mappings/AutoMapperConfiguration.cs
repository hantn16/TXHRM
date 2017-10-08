using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.Web.Models;

namespace TXHRM.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
            });
        }
    }
}