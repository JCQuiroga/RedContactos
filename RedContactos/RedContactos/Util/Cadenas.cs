using System.Collections.Generic;

namespace RedContactos.Util
{
    public static class Cadenas
    {
        public static string Url = "http://apicontactos-jcq.azurewebsites.net/api"; //Añadimos el "/api" !

        public static string FicheroSettings = "contact.dat";

        public static Dictionary<string, object> Session = new Dictionary<string, object>();
    }
}