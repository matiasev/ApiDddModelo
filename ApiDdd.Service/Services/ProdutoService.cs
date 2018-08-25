using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.ViewModel;
using AutoMapper;

namespace ApiDdd.Service.Services
{
    public class ProdutoService : BaseService<Produto, ProdutoViewModel>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
