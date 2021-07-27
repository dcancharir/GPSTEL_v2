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

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(18)]
        public string tipo { get; set; }
    }
}