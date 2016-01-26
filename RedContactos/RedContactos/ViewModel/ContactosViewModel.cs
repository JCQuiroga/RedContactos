using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class ContactosViewModel:GeneralViewModel
    {
        public ContactosViewModel(INavigator navigator, IServicioMovil servicio, Session session) : base(navigator, servicio, session)
        {
        }
    }
}