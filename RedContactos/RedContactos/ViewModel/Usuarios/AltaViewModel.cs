using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;
using RedContactos.ViewModel.Contactos;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Usuarios
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

        public AltaViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
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
                        Cadenas.Session["usuario"] = r;
                        await _navigator.PushAsync<ContactosViewModel>(viewModel =>
                        {
                            viewModel.Titulo = "Tus contactos";
                        });
                    }
                    else
                    {
                        await _page.MostrarAlerta("Error", "Error al crear usuario", "Aceptar");
                    }
                }
                else
                {
                    await _page.MostrarAlerta("Error","Error. Usuario ya registrado","Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}