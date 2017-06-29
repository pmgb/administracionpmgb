//using ApiCarRental;
using carrentalweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carrentalweb.Controllers
{
    public class loginController : ApiController
    {
        // GET: api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        [HttpPost]
        public RespuestaAPI Post([FromBody]Login login)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    usuarios = Db.Login(Login.email, Login.password);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = usuarios.Count;
            resultado.dataUsuario = usuarios;
            return resultado;
        }


        // PUT: api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/login/5
        public void Delete(int id)
        {
        }
    }
}
