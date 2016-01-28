
using System;
using Autofac;
using MvvmLibrary.Factorias;
using RedContactos.Servicios;
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
    public class ContactosModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<INavigation>( 
                              ctx => App.Current.MainPage.Navigation).SingleInstance();

            builder.RegisterInstance<Func<Page>>(() =>
            {
                var masterP = App.Current.MainPage as MasterDetailPage;
                var page = masterP != null ? masterP.Detail : App.Current.MainPage;
                var navigation = page as IPageContainer<Page>;
                return navigation != null ? navigation.CurrentPage : page;
            });
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<PageProxy>().As<IPage>().SingleInstance();

            builder.RegisterType<ServicioDatos>().As<IServicioMovil>().SingleInstance();
            builder.RegisterType<LoginView>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<AltaView>().SingleInstance();
            builder.RegisterType<AltaViewModel>().SingleInstance();
            builder.RegisterType<ContactosView>().SingleInstance();
            builder.RegisterType<ContactosViewModel>().SingleInstance();
            builder.RegisterType<PrincipalView>().SingleInstance();
            builder.RegisterType<PrincipalViewModel>().SingleInstance();
            builder.RegisterType<AddContactoView>().SingleInstance();
            builder.RegisterType<AddContactoViewModel>().SingleInstance();
            builder.RegisterType<EnviarMensajeView>().SingleInstance();
            builder.RegisterType<EnviarMensajeViewModel>().SingleInstance();
            builder.RegisterType<MisMensajesView>().SingleInstance();
            builder.RegisterType<MisMensajesViewModel>().SingleInstance();
            builder.RegisterType<DetalleMensajeView>().SingleInstance();
            builder.RegisterType<DetalleMensajeViewModel>().SingleInstance();
        }
    }
}