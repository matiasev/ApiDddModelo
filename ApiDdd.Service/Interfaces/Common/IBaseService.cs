using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IBaseService<TEntity, TViewModel> where TEntity : class
    {
        IList<TViewModel> Get();

        Task<IList<TViewModel>> GetAsysc();

        TViewModel GetById(int id);

        Task<TViewModel> GetByIdAsync(int id);

        TViewModel Add(TViewModel obj);

        Task<TViewModel> AddAsync(TViewModel obj);

        TViewModel Update(TViewModel obj);

        Task<TEntity> UpdateAsync(TViewModel obj);

        TViewModel Delete(int id);
    }
}