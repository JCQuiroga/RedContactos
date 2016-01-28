using System;
using System.Windows.Input;
using ContactosModel.Model;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel.Contactos
{
    public class EnviarMensajeViewModel : GeneralViewModel
    {
        private ContactoModel _contacto;
        public ContactoModel Contacto
        {
            get { return _contacto; }
            set { SetProperty(ref _contacto, value); }
        }

        private MensajeModel _mensaje;
        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set { SetProperty(ref _mensaje, value); }
        }

        public ICommand CmdEnviar { get; set; }

        public EnviarMensajeViewModel(INavigator navigator, IServicioMovil servicio, IPage page) : base(navigator, servicio, page)
        {
            CmdEnviar = new Command(RunEnviarMensaje);
        }

        private async void RunEnviarMensaje()
        {
            try
            {
                IsBusy = true;
                Mensaje.idOrigen = Contacto.idOrigen;
                Mensaje.fecha = DateTime.Now;
                Mensaje.idDestino = Contacto.idDestino;
                Mensaje.leido = false; //no hace falta, porque los booleanos por defecto son false.
                var r = await _servicio.AddMensaje(Mensaje);
                if (r != null)
                {
                    await _page.MostrarAlerta("Exito", "Mensaje enviado","Aceptar");
                }
                else
                {
                    await _page.MostrarAlerta("Error", "No se pudo enviar", "Aceptar");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}