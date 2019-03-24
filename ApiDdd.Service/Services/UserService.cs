using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace ApiDdd.Service.Services
{
    public class UserService : BaseService<User, UserViewModel>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Add(UserViewModel obj)
        {
            return await _mapper.Map<Task<UserViewModel>>(_userRepository.Insert(_mapper.Map<User>(obj)));
        }

        public LoginViewModel GetByUser(LoginViewModel obj)
        {
            return _mapper.Map<LoginViewModel>(_userRepository.SelectByUser(_mapper.Map<User>(obj)));
        }
    }
}
