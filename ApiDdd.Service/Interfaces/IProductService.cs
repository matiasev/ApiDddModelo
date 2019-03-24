using ApiDdd.Domain.Entities;
using ApiDdd.Service.ViewModel;

namespace ApiDdd.Domain.Interfaces
{
    public interface IProductService : IBaseService<Product, ProductViewModel>
    {
    }
}