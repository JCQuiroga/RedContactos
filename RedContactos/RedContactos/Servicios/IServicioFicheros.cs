using System;

namespace RedContactos.Servicios
{
    public interface IServicioFicheros
    {
        void GuardarTexto(string texto, string fichero);
        string RecuperarTexto(string fichero);
    }
}