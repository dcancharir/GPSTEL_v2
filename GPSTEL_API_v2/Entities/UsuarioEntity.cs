using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class UsuarioEntity
    {
        public int idusuario { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
        public string estado { get; set; }
        public string tipo { get; set; }
    }
}