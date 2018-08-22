using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using System;

namespace ApiDdd.Service.Services
{
    public class UsuarioServiceApp : IUsuarioServiceApp
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioServiceApp(IUsuarioService usuarioService, Mapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public void Add(UsuarioViewModel obj)
        {

            _usuarioService.Add(_mapper.Map<Usuario>(obj));

        
        }

        public LoginViewModel GetByUser(LoginViewModel obj)
        {
            
            return _mapper.Map<LoginViewModel>(_usuarioService.GetByUser(_mapper.Map<Usuario>(obj)));
        }
    }
}
