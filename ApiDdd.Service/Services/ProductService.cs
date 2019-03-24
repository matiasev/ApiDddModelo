using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.ViewModel;
using AutoMapper;

namespace ApiDdd.Service.Services
{
    public class ProductService : BaseService<Product, ProductViewModel>, IProductService
    {
        public ProductService(IProductRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
