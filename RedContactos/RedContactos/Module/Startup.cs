using Autofac;
using MvvmLibrary.Factorias;
using MvvmLibrary.ModuloBase;
using RedContactos.View;
using RedContactos.View.Contactos;
using RedContactos.View.Mensajes;
using RedContactos.ViewModel;
using RedContactos.ViewModel.Contactos;
using RedContactos.ViewModel.Mensajes;
using RedContactos.ViewModel.Usuarios;
using Xamarin.Forms;

namespace RedContactos.Module
{
    public class Startup:AutofacBootstrapper
    {
        private readonly App _application;

        public Startup(App application)
        {
            _application = application;
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<ContactosModule>();
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<LoginViewModel, LoginView>();
            viewFactory.Register<AltaViewModel, AltaView>();
            viewFactory.Register<ContactosViewModel, ContactosView>();
            viewFactory.Register<AddContactoViewModel, AddContactoView>();
            viewFactory.Register<EnviarMensajeViewModel, EnviarMensajeView>();
            viewFactory.Register<DetalleMensajeViewModel, DetalleMensajeView>();
            viewFactory.Register<MisMensajesViewModel, MisMensajesView>();
            viewFactory.Register<PrincipalViewModel, PrincipalView>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            var main = viewFactory.Resolve<LoginViewModel>();
            var np = new NavigationPage(main);
            _application.MainPage = np;
        }
    }
}