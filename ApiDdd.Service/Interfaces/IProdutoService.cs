using ApiDdd.Domain.Entities;
using ApiDdd.Service.ViewModel;

namespace ApiDdd.Domain.Interfaces
{
    public interface IProdutoService : IBaseService<Produto, ProdutoViewModel>
    {
    }
}