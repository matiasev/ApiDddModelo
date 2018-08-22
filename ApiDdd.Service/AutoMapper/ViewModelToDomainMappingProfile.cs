using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using ApiDdd.Service.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UsuarioViewModel, Usuario>()
            .ConstructUsing(u => new Usuario(u.Nome, u.Email, u.Password));

        CreateMap<LoginViewModel, Login>()
            .ConstructUsing(l => new Login(l.Email, l.Password));

        CreateMap<ProdutoViewModel, Produto>()
            .ConstructUsing(p => new Produto(p.Nome, p.Quantidade, p.Status));
    }
}