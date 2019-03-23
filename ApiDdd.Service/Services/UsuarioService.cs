using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ApiDdd.Service.Services
{
    public class UsuarioService : BaseService<Usuario, UsuarioViewModel>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
            : base(usuarioRepository, mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioViewModel> Add(UsuarioViewModel obj)
        {
            return await _mapper.Map<Task<UsuarioViewModel>>(_usuarioRepository.Insert(_mapper.Map<Usuario>(obj)));
        }

        public LoginViewModel GetByUser(LoginViewModel obj)
        {
            return _mapper.Map<LoginViewModel>(_usuarioRepository.SelectByUser(_mapper.Map<Usuario>(obj)));
        }
    }
}
