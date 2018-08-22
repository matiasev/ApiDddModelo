using ApiDdd.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ApiDdd.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Insert(obj);
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public IList<TEntity> Get()
        {
            return _repository.SelectAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.SelectById(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}
