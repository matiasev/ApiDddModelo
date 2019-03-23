using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IList<TEntity> SelectAll();

        Task<IList<TEntity>> SelectAllAsync();

        TEntity SelectById(int id);

        Task<TEntity> SelectByIdAsync(int id);

        TEntity Insert(TEntity obj);

        Task<TEntity> InsertAsync(TEntity obj);

        TEntity Update(TEntity obj);

        Task<TEntity> UpdateAsync(TEntity obj);

        TEntity Remove(int id);
    }
}