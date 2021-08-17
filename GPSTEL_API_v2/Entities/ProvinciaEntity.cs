using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class ProvinciaEntity
    {
        public int idprovincia { get; set; }
        public string nombre { get; set; }
        public int iddepartamento { get; set; }
    }
}