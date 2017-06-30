using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentelWeb.Controllers
{
    public class TiposCombustibleController : ApiController
    {
        // GET: api/TiposCombustible
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<TipoCombustible> tiposCombustibles = new List<TipoCombustible>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    tiposCombustibles = Db.GetTiposCombustibles();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = tiposCombustibles.Count;
            resultado.dataTiposCombustible = tiposCombustibles;
            return resultado;
        }

        // GET: api/TiposCombustible/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TiposCombustible
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TiposCombustible/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TiposCombustible/5
        public void Delete(int id)
        {
        }
    }
}
