using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.ViewModel;
using AutoMapper;

namespace ApiDdd.Service.Services
{
    public class ProdutoServiceApp : BaseServiceApp<Produto, ProdutoViewModel>, IProdutoServiceApp
    {
        public ProdutoServiceApp(IProdutoService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
