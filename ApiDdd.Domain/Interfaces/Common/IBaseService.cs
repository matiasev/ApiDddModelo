using FluentValidation;
using System.Collections.Generic;

namespace ApiDdd.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Delete(int id);

        IList<TEntity> Get();

        TEntity GetById(int id);

        void Update(TEntity obj);
    }
}