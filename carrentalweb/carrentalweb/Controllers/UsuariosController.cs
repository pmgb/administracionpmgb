//using ApiCarRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carrentalweb.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    usuarios = Db.GetUsuarios();
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

        // GET: api/Usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        [HttpDelete]
        public RespuestaAPI Delete(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.EliminarUsuario(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = filasAfectadas;
            resultado.dataUsuario = null;
            return resultado;
        }
    }
}