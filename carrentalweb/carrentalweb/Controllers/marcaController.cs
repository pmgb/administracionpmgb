//using ApiCarRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace carrentalweb.Controllers
{
    public class marcaController : ApiController
    {
        // GET: api/marca
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/marca/5
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/marca
        //[HttpPost]
        //public RespuestaAPI Post([FromBody]Marca marca)
        //{
        //    RespuestaAPI resultado = new RespuestaAPI();
        //    int filasAfectadas = 0;
        //    try
        //    {
        //        Db.Conectar();

        //        if (Db.EstaLaConexionAbierta())
        //        {
        //            filasAfectadas = Db.AgregarMarca(marca);
        //        }
        //        resultado.error = "";
        //        Db.Desconectar();
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.error = "Se produjo un error";
        //    }

        //    resultado.totalElementos = filasAfectadas;
        //    resultado.dataMarcas = null;
        //    return resultado;
        //}


        //public void Post([FromBody]string value)
        [HttpPost]
        public RespuestaAPI Post([FromBody]Marca marca)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.AgregarMarca(marca);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = filasAfectadas;
            resultado.dataMarcas = null;
            return resultado;
        }

        // PUT: api/marca/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/marca/5
        public void Delete(int id)
        {
        }
    }

    public class Marca
    {
    }
}
