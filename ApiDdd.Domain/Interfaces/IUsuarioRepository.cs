using ApiDdd.Domain.Entities;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Insert(Usuario obj);

        Usuario SelectByUser(Usuario obj);
    }
}
