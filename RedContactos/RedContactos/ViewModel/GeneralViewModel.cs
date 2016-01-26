using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;
using RedContactos.Servicios;

namespace RedContactos.ViewModel
{
    public class GeneralViewModel : ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioMovil _servicio;

        public GeneralViewModel(INavigator navigator, IServicioMovil servicio)
        {
            _navigator = navigator;
            _servicio = servicio;
        }
    }
}