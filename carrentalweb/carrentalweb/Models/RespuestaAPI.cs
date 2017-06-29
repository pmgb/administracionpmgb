using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCarRental
{
    public class RespuestaAPI
    {
        internal List<Usuario> dataUsuario;

        public int totalElementos { get; set; }

        public string error { get; set; }

        public List<Usuario> data { get; set; }

        public List<TipoCombustible> dataTiposCombustible { get; set; }

        public List<Marca> dataMarca { get; set; }
    }
}