using ApiDdd.Domain.Entities;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioService
    {
        void Add(Usuario obj);

        Usuario GetByUser(Usuario obj);
    }
}
