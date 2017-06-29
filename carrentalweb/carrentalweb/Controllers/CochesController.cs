using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carrentalweb.Controllers
{
    public class CochesController : ApiController
    {

        // GET: api/Coches
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Coche> coches = new List<Coche>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    coches = Db.GetCoches();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = coches.Count;
            resultado.data = coches;
            return resultado;
        }

        // GET: api/Coches/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Coches
        //public void Post([FromBody]string value)
        //{
        //}

        // POST: api/Coches
        [HttpPost]
        public RespuestaAPI Post([FromBody]Coche coche)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarCoche(coche);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = filasAfectadas;
            resultado.data = null;
            return resultado;
        }




        // PUT: api/Coches/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coches/5
        public void Delete(int id)
        {
        }
    }
}
