
using System;
using Autofac;
using RedContactos.Servicios;
using RedContactos.View;
using RedContactos.ViewModel;
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
            builder.RegisterType<ServicioDatos>().As<IServicioMovil>().SingleInstance();
            builder.RegisterType<LoginView>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<AltaView>().SingleInstance();
            builder.RegisterType<AltaViewModel>().SingleInstance();
            builder.RegisterType<ContactosView>().SingleInstance();
            builder.RegisterType<ContactosViewModel>().SingleInstance();
        }
    }
}