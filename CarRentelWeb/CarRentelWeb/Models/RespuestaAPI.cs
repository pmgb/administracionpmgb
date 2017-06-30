using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentelWeb
{
    public class RespuestaAPI
    {
        public int totalElementos { get; set; }

        public string error { get; set; }

        public List<Usuario> dataUsuario { get; set; }
        public List<Coche> data { get; set; }

        public List<Marca> dataMarcas { get; set; }

        public List<TipoCombustible> dataTiposCombustible { get; set; }
    }
}