using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class ChipEntity
    {
       
        public int idchip { get; set; }
        public string operador { get; set; }
        public string tipo_contrato { get; set; }
        public string numero { get; set; }
        public string estado { get; set; }
    }
}