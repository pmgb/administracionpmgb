using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentelWeb.Controllers
{
    public class MarcasController : ApiController
    {
        // GET: api/Marcas
        public RespuestaAPI Get()
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Marca> marcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    marcas = Db.GetMarcas();
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = marcas.Count;
            resultado.dataMarcas = marcas;
            return resultado;
        }

        // GET: api/Marcas/5
        public RespuestaAPI Get(int id)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            List<Marca> marcas = new List<Marca>();
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    marcas = Db.GetMarcasPorId(id);
                }
                resultado.error = "";
                Db.Desconectar();
            }
            catch (Exception ex)
            {
                resultado.error = "Se produjo un error";
            }

            resultado.totalElementos = marcas.Count;
            resultado.dataMarcas = marcas;
            return resultado;
        }

        // POST: api/Marcas
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

        // PUT: api/Marcas/5
        [HttpPut]
        public RespuestaAPI Put(int id, [FromBody]Marca marca)
        {
            RespuestaAPI resultado = new RespuestaAPI();
            int filasAfectadas = 0;
            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    filasAfectadas = Db.ActualizarMarca(id, marca);
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

        // DELETE: api/Marcas/5
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
                    filasAfectadas = Db.EliminarMarca(id);
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
    }
}
