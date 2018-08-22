using ApiDdd.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ApiDdd.Service.Services
{
    public abstract class BaseServiceApp<TEntity, TViewModel> : IBaseServiceApp<TEntity, TViewModel> where TEntity : class
    {
        private readonly IBaseService<TEntity> _service;
        private readonly IMapper _mapper;

        public BaseServiceApp(IBaseService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(TViewModel obj)
        {
            _service.Add(_mapper.Map<TEntity>(obj));
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public IList<TViewModel> Get()
        {
            return _mapper.Map<IList<TViewModel>>(_service.Get());
        }

        public TViewModel GetById(int id)
        {
            return _mapper.Map<TViewModel>(_service.GetById(id));
        }

        public void Update(TViewModel obj)
        {
            _service.Update(_mapper.Map<TEntity>(obj));

        }
    }
}