using System;
using System.Collections.Generic;

namespace RedContactos.Util
{
    public class Session
    {
        private Dictionary<string, object> _session = new Dictionary<string, object>();

        public Object this[string index]  //Indexor: Sobre una clase determinada, define como acceder con indice.
        {
            get { return _session[index]; }
            set { _session[index] = value; }
        }
    }
}
