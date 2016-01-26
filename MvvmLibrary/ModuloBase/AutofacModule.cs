using Autofac;
using MvvmLibrary.Factorias;
using Xamarin.Forms;

namespace MvvmLibrary.ModuloBase
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();

            /*  builder.Register<INavigation>( //Esto se registrará dentro de la propia app, no en el proyecto genérico.
                  ctx => App.Current.MainPage.Navigation).SingleInstance(); */
        }
    }
}