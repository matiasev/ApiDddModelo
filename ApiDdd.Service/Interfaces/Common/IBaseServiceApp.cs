using FluentValidation;
using System.Collections.Generic;

namespace ApiDdd.Domain.Interfaces
{
    public interface IBaseServiceApp<TEntity, TViewModel> where TEntity : class
    {

        void Add(TViewModel obj);

        void Delete(int id);

        IList<TViewModel> Get();

        TViewModel GetById(int id);

        void Update(TViewModel obj);
    }
}