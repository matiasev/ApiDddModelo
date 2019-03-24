using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;

namespace ApiDdd.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
    }
}
