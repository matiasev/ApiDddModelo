using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario, UsuarioViewModel>
    {
        Task<UsuarioViewModel> Add(UsuarioViewModel obj);

        LoginViewModel GetByUser(LoginViewModel obj);
    }
}
