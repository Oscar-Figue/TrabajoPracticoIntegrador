using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Helpers
{
    public class EntityToModelMapper
    {
        public List<TModel> MapToModelList<TEntity, TModel>(IEnumerable<TEntity> entities)
            where TEntity : class
            where TModel : class, new()
        {
            if (entities == null)
            {
                return null;
            }

            var modelList = new List<TModel>();
            foreach (var entity in entities)
            {
                var model = MapToModel<TEntity, TModel>(entity);
                modelList.Add(model);
            }

            return modelList;
        }

        public TModel MapToModel<TEntity, TModel>(TEntity entity)
    where TEntity : class
    where TModel : class, new()
        {
            if (entity == null)
            {
                return null;
            }

            var model = new TModel();

            var entityProperties = typeof(TEntity).GetProperties();
            var modelProperties = typeof(TModel).GetProperties()
                .Where(p => p.CanWrite);

            foreach (var modelProperty in modelProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == modelProperty.Name);
                if (entityProperty != null)
                {
                    var value = entityProperty.GetValue(entity);
                    if (value != null && !IsSimpleType(entityProperty.PropertyType))
                    {
                        var entityType = value.GetType();
                        var modelType = modelProperty.PropertyType;

                        var mapMethod = typeof(EntityToModelMapper).GetMethod("MapToModel");
                        var genericMethod = mapMethod.MakeGenericMethod(entityType, modelType);
                        var nestedModel = genericMethod.Invoke(this, new[] { value });

                        modelProperty.SetValue(model, nestedModel);
                    }
                    else
                    {
                        modelProperty.SetValue(model, value);
                    }
                }
            }

            return model;
        }

        private bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || new[] { typeof(string), typeof(decimal), typeof(DateTime), typeof(Guid) }.Contains(type) || type.IsValueType;
        }
    }

}