using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TXHRM.Model.Models;
using TXHRM.Web2.Models;

namespace TXHRM.Web2.Infrastructure.Extensions
{
    public static class EntityExtension
    {
        public static void UpdateFromViewModel<T, TViewModel>(this T entity, TViewModel entityViewModel)
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
    }
}