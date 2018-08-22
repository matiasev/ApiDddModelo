using System.Collections.Generic;

namespace ApiDdd.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);

        void Remove(int id);

        IList<TEntity> SelectAll();

        TEntity SelectById(int id);

        void Update(TEntity obj);
    }
}