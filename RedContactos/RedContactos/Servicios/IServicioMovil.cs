using System.Threading.Tasks;
using ContactosModel.Model;

namespace RedContactos.Servicios
{
    public interface IServicioMovil
    {
        Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario);
        Task<bool> UsuarioNuevo(string login);
        Task<UsuarioModel> AddUsuario(UsuarioModel usuario);
    }
}