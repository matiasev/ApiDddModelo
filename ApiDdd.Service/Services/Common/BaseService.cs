using ApiDdd.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public IList<TViewModel> Get()
        {
            return _mapper.Map<IList<TViewModel>>(_repository.SelectAll());
        }

        public async Task<IList<TViewModel>> GetAsysc()
        {
            return await _mapper.Map<Task<IList<TViewModel>>>(_repository.SelectAllAsync());
        }

        public TViewModel GetById(int id)
        {
            return _mapper.Map<TViewModel>(_repository.SelectById(id));
        }

        public async Task<TViewModel> GetByIdAsync(int id)
        {
            return await _mapper.Map<Task<TViewModel>>(_repository.SelectByIdAsync(id));
        }

        public TViewModel Add(TViewModel obj)
        {
            return _mapper.Map<TViewModel>(_repository.Insert(_mapper.Map<TEntity>(obj)));
        }

        public async Task<TViewModel> AddAsync(TViewModel obj)
        {
            return await _mapper.Map<Task<TViewModel>>(_repository.InsertAsync(_mapper.Map<TEntity>(obj)));
        }

        public TViewModel Update(TViewModel obj)
        {
            return _mapper.Map<TViewModel>(_repository.Update(_mapper.Map<TEntity>(obj)));
        }

        public Task<TEntity> UpdateAsync(TViewModel obj)
        {
            return _mapper.Map<Task<TEntity>>(_repository.UpdateAsync(_mapper.Map<TEntity>(obj)));
        }

        public TViewModel Delete(int id)
        {
            return _mapper.Map<TViewModel>(_repository.Remove(id));
        }
    }
}