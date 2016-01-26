using System.Threading.Tasks;
using ContactosModel.Model;
using RedContactos.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace RedContactos.Servicios
{
    public class ServicioDatos : IServicioMovil
    {
        private RestClient client;

        public ServicioDatos()
        {
            client = new RestClient(Cadenas.Url);
        }

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario");
            //Al request se le pueden añadir Headers, y al client se le pueden añadir credentials
            request.Method = Method.GET;
            request.AddQueryParameter("login",usuario.login);
            request.AddQueryParameter("password",usuario.password);

            var reponse = await client.Execute<UsuarioModel>(request);
            if (reponse.IsSuccess) return reponse.Data;
            return null;
        }

        public async Task<bool> UsuarioNuevo(string login)
        {
            var request = new RestRequest("Usuario");
            request.Method = Method.GET;
            request.AddQueryParameter("login", login);

            var reponse = await client.Execute<bool>(request);
            if (reponse.IsSuccess) return reponse.Data;
            return false;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            var request = new RestRequest("Usuario")
            {
                Method = Method.POST //Esta es otra forma de hacerlo.
            };
            request.AddJsonBody(usuario);
            var reponse = await client.Execute<UsuarioModel>(request);
            
            if (reponse.IsSuccess) return reponse.Data;
            return null;
        }
    }
}