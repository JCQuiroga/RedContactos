using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class AltaViewModel : GeneralViewModel
    {
        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public ICommand CmdAlta { get; set; }

        public AltaViewModel(INavigator navigator, IServicioMovil servicio, Session session) : base(navigator, servicio, session)
        {
            _usuario = new UsuarioModel();
            CmdAlta = new Command(RunAlta);
        }

        private async void RunAlta()
        {
            try
            {
                IsBusy = true;
                var noesta = await _servicio.UsuarioNuevo(Usuario.login);
                if (noesta)
                {
                    var r = await _servicio.AddUsuario(Usuario);
                    if (r != null)
                    {
                        await _navigator.PushAsync<ContactosViewModel>(viewModel =>
                        {
                            Titulo = "Tus contactos";
                        });
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}