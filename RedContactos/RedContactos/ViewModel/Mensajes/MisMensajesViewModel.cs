using System.Collections.ObjectModel;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;

namespace RedContactos.ViewModel.Mensajes
{
    public class MisMensajesViewModel : GeneralViewModel
    {

        private ObservableCollection<MensajeModel> _mensajes;
        public ObservableCollection<MensajeModel> Mensajes
        {
            get { return _mensajes; }
            set { SetProperty(ref _mensajes, value); }
        }

        private MensajeModel _mensajeSeleccionado;
        public MensajeModel MensajeSeleccionado
        {
            get { return _mensajeSeleccionado; }
            set
            {
                if(value!=null) VerDetalleMensaje();
                SetProperty(ref _mensajeSeleccionado, value);
            }
        }

        public MisMensajesViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
        }

        private async void VerDetalleMensaje()
        {
            if (_mensajeSeleccionado != null)
            {
                if (!_mensajeSeleccionado.leido)
                {
                    _mensajeSeleccionado.leido = true;
                    await _servicio.UpdateMensaje(_mensajeSeleccionado);
                }
                await _navigator.PushAsync<DetalleMensajeViewModel>(viewModel =>
                {
                    viewModel.Mensaje = _mensajeSeleccionado; // Se podria usar MensajeSeleccionado y daria lo mismo. Solo importa al hacer el Set, que debe pasar por el SetProperty de la variable publica.
                    viewModel.Titulo = _mensajeSeleccionado.asunto;
                });
                MensajeSeleccionado = null;
            }
        }
    }
}