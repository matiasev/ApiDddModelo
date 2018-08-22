using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;

namespace ApiDdd.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Add(Usuario obj)
        {
           _usuarioRepository.Insert(obj);
        }

        public Usuario GetByUser(Usuario obj)
        {
            return _usuarioRepository.SelectByUser(obj);
        }
    }
}
