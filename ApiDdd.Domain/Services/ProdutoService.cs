using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;

namespace ApiDdd.Service.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {
        }
    }
}
