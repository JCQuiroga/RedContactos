using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;
using RedContactos.Servicios;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class GeneralViewModel : ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioMovil _servicio;
        protected Session _session;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio, Session session)
        {
            _navigator = navigator;
            _servicio = servicio;
            _session = session;
        }
    }
}