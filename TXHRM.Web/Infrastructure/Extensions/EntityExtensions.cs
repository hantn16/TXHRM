using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.Web.Models;

namespace TXHRM.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateFromViewModel<T,TViewModel>(this T entity,TViewModel entityViewModel)
        {
            var listproperty = entity.GetType().GetProperties();
            List<PropertyInfo> property = entity.GetType().GetProperties().Where(c => c.GetMethod.IsFinal == true||c.GetMethod.IsVirtual==false).ToList();
            List<PropertyInfo> VMproperty = entityViewModel.GetType().GetProperties().Where(c => c.GetMethod.IsVirtual == false).ToList();
            foreach (var item in property)
            {
                var value = VMproperty.SingleOrDefault(c => c.Name == item.Name).GetValue(entityViewModel);
                item.SetValue(entity, value);
            }
        }
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
            postCategory.ID = postCategoryVm.ID;
            postCategory.Image = postCategoryVm.Image;
            postCategory.Name = postCategoryVm.Name;
            postCategory.ParentID = postCategoryVm.ParentID;

            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.ModifiedBy = postCategoryVm.ModifiedBy;
            postCategory.ModifiedDate = postCategoryVm.ModifiedDate;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.Status = postCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.Alias = postVm.Alias;
            post.Description = postVm.Description;
            post.HotFlag = postVm.HotFlag;
            post.HomeFlag = postVm.HomeFlag;
            post.ID = postVm.ID;
            post.Image = postVm.Image;
            post.Name = postVm.Name;
            post.CategoryId = postVm.CategoryId;
            post.ViewCount = postVm.ViewCount;
            post.Content = postVm.Content;
            post.Tags = postVm.Tags;

            post.CreatedBy = postVm.CreatedBy;
            post.CreatedDate = postVm.CreatedDate;
            post.ModifiedBy = postVm.ModifiedBy;
            post.ModifiedDate = postVm.ModifiedDate;
            post.MetaDescription = postVm.MetaDescription;
            post.MetaKeyword = postVm.MetaKeyword;
            post.Status = postVm.Status;
        }
    }
}