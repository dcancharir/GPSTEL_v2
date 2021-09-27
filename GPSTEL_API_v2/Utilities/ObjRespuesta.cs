using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Utilities
{
    public class ObjRespuesta
    {
        public bool respuesta { get; set; }
        public string mensaje{ get; set; }
        public object data{ get; set; }
        public ObjRespuesta()
        {
            respuesta = false;
            mensaje = string.Empty;
            data = new object();
        }
    }
}