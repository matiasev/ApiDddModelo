using ApiDdd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
