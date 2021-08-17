using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class GpsEntity
    {
        public int idgps { get; set; }
        public string modelo { get; set; }
        public string estado_uso{ get; set; }
        public string garantia { get; set; }
        public int idchip { get; set; }
        public DateTime fecha_compra { get; set; }
        public string imei { get; set; }
        //Relaciones
        public ChipEntity Chip { get; set; }
        public GpsEntity()
        {
            Chip = new ChipEntity();
        }
    }
}