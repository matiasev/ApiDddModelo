using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using AutoMapper;

namespace ApiDdd.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, Mapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public void Add(UsuarioViewModel obj)
        {
            _usuarioRepository.Insert(_mapper.Map<Usuario>(obj));
        }

        public LoginViewModel GetByUser(LoginViewModel obj)
        {
            return _mapper.Map<LoginViewModel>(_usuarioRepository.SelectByUser(_mapper.Map<Usuario>(obj)));
        }
    }
}
