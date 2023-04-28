using Ecommerce.Domain.Base;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Utility
{
    public static class LogUtility
    {
        public static (List<string> propertyNames, bool hasAny) GetUpdateChanges<T>(T beforeEntity, T updatedEntity) where T : EntityBase
        {                       
            EntityIsNull(beforeEntity, updatedEntity);

            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            List<string> propertyNames = new();
            foreach (PropertyInfo property in properties)
            {
                object oldValue = property.GetValue(beforeEntity, null)!;
                object newValue = property.GetValue(updatedEntity, null)!;

                if (property.PropertyType.IsSubclassOf(typeof(EntityBase)))
                    continue;

                if (!oldValue.Equals(newValue))
                    propertyNames.Add(property.Name);
            }

            return (propertyNames, propertyNames.Any());
        }

        public static void EntityIsNull(EntityBase? entity)
        {
            if (entity == null)
                ThrowNullException(entity!);
        }

        public static void EntityIsNull(EntityBase? entity, EntityBase? entity2)
        {
            if (entity == null || entity2 == null)
                ThrowNullException(entity!);
        }

        private static void ThrowNullException(EntityBase entity)
        {
            throw new ArgumentNullException(nameof(entity), "Can't make log if parameter is null");
        }
    }
}
