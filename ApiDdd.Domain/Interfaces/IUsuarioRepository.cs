using ApiDdd.Domain.Entities;
using System.Threading.Tasks;

namespace ApiDdd.Domain.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> Insert(Usuario obj);

        Usuario SelectByUser(Usuario obj);
    }
}
