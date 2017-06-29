using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace carrentalweb
{
    public class Coche
    {
        public long id { get; set; }
        public string matricula { get; set; }
        public long idmarca { get; set; }
        public long idTipoCombustible { get; set; }
        public string color { get; set; }
        public decimal cilindrada { get; set; }
        public int nPlazas { get; set; }
        public DateTime FechaMatriculacion { get; set; }
        
    }
}


