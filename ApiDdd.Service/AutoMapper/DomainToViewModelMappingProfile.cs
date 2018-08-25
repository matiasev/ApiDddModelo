using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using ApiDdd.Service.ViewModel;
using AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Login, LoginViewModel>();
        CreateMap<Usuario, UsuarioViewModel>();
        CreateMap<Produto, ProdutoViewModel>();

    }
}