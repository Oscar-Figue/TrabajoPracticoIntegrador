using Base.Helpers;
using Repository.Base;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Base
{
    public class GenericService<TModel, TEntity>
    where TModel : class, new()
    where TEntity : class, new()
    {
        internal readonly GenericRepository<TEntity> repository;
        internal readonly EntityToModelMapper mapper;

        public GenericService()
        {
            this.repository = new GenericRepository<TEntity>();
            this.mapper = new EntityToModelMapper();
        }

        public List<TModel> GetAll()
        {
            var entities = repository.GetAll();
            return mapper.MapToModelList<TEntity, TModel>(entities);
        }

        public TModel GetById(int id)
        {
            var entity = repository.GetById(id);
            return mapper.MapToModel<TEntity, TModel>(entity);
        }

        public void Add(TModel model)
        {
            var entity = mapper.MapToModel<TModel, TEntity>(model);
            repository.Add(entity);
        }

        public void Update(TModel model)
        {
            var entity = mapper.MapToModel<TModel, TEntity>(model);
            repository.Update(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }

}
