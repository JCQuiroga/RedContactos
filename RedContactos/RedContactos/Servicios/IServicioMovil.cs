using System.Collections.Generic;
using System.Threading.Tasks;
using ContactosModel.Model;

namespace RedContactos.Servicios
{
    public interface IServicioMovil
    {
        #region Usuario

        Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario);
        Task<bool> UsuarioNuevo(string login);
        Task<UsuarioModel> AddUsuario(UsuarioModel usuario);

        #endregion

        #region Contacto

        Task<List<ContactoModel>> GetContactos(bool actuales, int id);
        Task<ContactoModel> AddContacto(ContactoModel contacto);
        Task DelContacto(ContactoModel contacto);

        #endregion

        #region Mensaje

        Task<List<MensajeModel>> GetMensaje(int id);
        Task<MensajeModel> AddMensaje(MensajeModel mensaje);
        Task UpdateMensaje(MensajeModel mensaje);

        #endregion

    }
}