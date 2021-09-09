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
        [Required]
        [StringLength(50)]
        public string operador { get; set; }
        [Required]
        [StringLength(20)]
        public string tipo_contrato { get; set; }
        [Required]
        [StringLength(18)]
        public string numero { get; set; }
        public string estado { get; set; }
    }
}