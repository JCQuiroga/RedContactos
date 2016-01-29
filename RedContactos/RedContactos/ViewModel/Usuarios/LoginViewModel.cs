using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using Newtonsoft.Json.Serialization;
using RedContactos.Servicios;
using RedContactos.Util;
using RedContactos.ViewModel.Contactos;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Usuarios
{
    public class LoginViewModel : GeneralViewModel
    {
        private UsuarioModel _usuario;

        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public ICommand CmdLogin { get; set; }
        public ICommand CmdAlta { get; set; }
        public LoginViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            _usuario = new UsuarioModel(); //MUY IMPORTANTE. Hay que inicializarlo, porque no llama al constructor de UsuarioModel por defecto.
            CmdLogin = new Command(RunLogin);
            CmdAlta = new Command(RunAlta);
        }

        private async void RunLogin()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(Usuario);
                if (us != null)
                {
                    Cadenas.Session["usuario"] = us;
                    await _navigator.PushAsync<PrincipalViewModel>(viewModel =>
                    {
                        viewModel.Titulo = "Tus Contactos";
                    });
                }
            }
            catch (Exception e)
            {
                await _page.MostrarAlerta("Error", "Error en el login", "Aceptar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void RunAlta()
        {
            await _navigator.PushAsync<AltaViewModel>(viewModel =>
            {
                Titulo = "Nuevo usuario";
            });
        }

    }
}