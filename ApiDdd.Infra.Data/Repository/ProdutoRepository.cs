using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;

namespace ApiDdd.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
    }
}
