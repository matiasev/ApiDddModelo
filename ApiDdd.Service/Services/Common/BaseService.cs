using ApiDdd.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ApiDdd.Service.Services
{
    public abstract class BaseService<TEntity, TViewModel> : IBaseService<TEntity, TViewModel> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(TViewModel obj)
        {
            _repository.Insert(_mapper.Map<TEntity>(obj));
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public IList<TViewModel> Get()
        {
            return _mapper.Map<IList<TViewModel>>(_repository.SelectAll());
        }

        public TViewModel GetById(int id)
        {
            return _mapper.Map<TViewModel>(_repository.SelectById(id));
        }

        public void Update(TViewModel obj)
        {
            _repository.Update(_mapper.Map<TEntity>(obj));

        }
    }
}