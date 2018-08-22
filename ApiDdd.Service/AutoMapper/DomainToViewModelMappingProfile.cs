using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using ApiDdd.Service.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Login, LoginViewModel>();
        CreateMap<Usuario, UsuarioViewModel>();
        CreateMap<Produto, ProdutoViewModel>();

    }
}