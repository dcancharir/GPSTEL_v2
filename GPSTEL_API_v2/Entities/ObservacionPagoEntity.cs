using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class ObservacionPagoEntity
    {
        public int idobservacion { get; set; }
        public string observacion { get; set; }
        public string estado { get; set; }
        public int idpago { get; set; }
    }
}