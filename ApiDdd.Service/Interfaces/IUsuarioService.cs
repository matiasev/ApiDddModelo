using ApiDdd.Application.ViewModel;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioService
    {
        void Add(UsuarioViewModel obj);

        LoginViewModel GetByUser(LoginViewModel obj);
    }
}
