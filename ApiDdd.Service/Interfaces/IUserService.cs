using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUserService : IBaseService<User, UserViewModel>
    {
        Task<UserViewModel> Add(UserViewModel obj);

        LoginViewModel GetByUser(LoginViewModel obj);
    }
}
