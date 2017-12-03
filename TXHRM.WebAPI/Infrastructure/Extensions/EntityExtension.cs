using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.WebAPI.Models;

namespace TXHRM.WebAPI.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateFromViewModel<T, TViewModel>(this T entity, TViewModel entityViewModel)
        {
            try
            {
                var listproperty = entity.GetType().GetProperties();
                List<PropertyInfo> property = entity.GetType().GetProperties().Where(c => c.GetMethod.IsFinal == true || c.GetMethod.IsVirtual == false).ToList();
                List<PropertyInfo> VMproperty = entityViewModel.GetType().GetProperties().Where(c => c.GetMethod.IsVirtual == false).ToList();
                foreach (var item in property)
                {
                    var value = VMproperty.SingleOrDefault(c => c.Name == item.Name).GetValue(entityViewModel);
                    item.SetValue(entity, value);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
        {
            try
            {
                appUser.Id = appUserViewModel.Id;
                appUser.FullName = appUserViewModel.FullName;
                if (!string.IsNullOrEmpty(appUserViewModel.BirthDay))
                {
                    DateTime dateTime = DateTime.ParseExact(appUserViewModel.BirthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    appUser.BirthDay = dateTime;
                }

                appUser.Email = appUserViewModel.Email;
                appUser.Address = appUserViewModel.Address;
                appUser.UserName = appUserViewModel.UserName;
                appUser.PhoneNumber = appUserViewModel.PhoneNumber;
                appUser.Gender = appUserViewModel.Gender == "True" ? true : false;
                appUser.Status = appUserViewModel.Status;
                appUser.Address = appUserViewModel.Address;
                appUser.Avatar = appUserViewModel.Avatar;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static void UpdateFunction(this Function function, FunctionViewModel functionVm)
        {
            try
            {
                function.Name = functionVm.Name;
                function.DisplayOrder = functionVm.DisplayOrder;
                function.IconCss = functionVm.IconCss;
                function.Status = functionVm.Status;
                function.ParentId = functionVm.ParentId;
                function.Status = functionVm.Status;
                function.URL = functionVm.URL;
                function.Id = functionVm.Id;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void UpdatePermission(this Permission permission, PermissionViewModel permissionVm)
        {
            try
            {
                permission.RoleId = permissionVm.RoleId;
                permission.FunctionId = permissionVm.FunctionId;
                permission.CanCreate = permissionVm.CanCreate;
                permission.CanDelete = permissionVm.CanDelete;
                permission.CanRead = permissionVm.CanRead;
                permission.CanUpdate = permissionVm.CanUpdate;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}