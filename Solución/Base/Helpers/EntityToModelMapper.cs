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

            var entityType = typeof(TEntity);
            var modelType = typeof(TModel);
            var model = new TModel();

            var entityProperties = entityType.GetProperties();
            var modelProperties = modelType.GetProperties()
                .Where(p => p.CanWrite);

            foreach (var modelProperty in modelProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == modelProperty.Name);
                if (entityProperty != null)
                {
                    var value = entityProperty.GetValue(entity);
                    modelProperty.SetValue(model, value);
                }
            }

            return model;
        }
    }
}
