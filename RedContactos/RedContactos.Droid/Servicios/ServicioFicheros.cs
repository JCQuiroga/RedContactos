using System;
using System.IO;
using RedContactos.Droid.Servicios;
using RedContactos.Servicios;
using Xamarin.Forms;

[assembly: Dependency(typeof(ServicioFicheros))]
namespace RedContactos.Droid.Servicios
{
    public class ServicioFicheros : IServicioFicheros
    {
        public void GuardarTexto(string texto, string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            try
            {
                File.WriteAllText(rutafinal, texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public string RecuperarTexto(string fichero)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var rutafinal = Path.Combine(path, fichero);
            try
            {
                return File.ReadAllText(rutafinal);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}