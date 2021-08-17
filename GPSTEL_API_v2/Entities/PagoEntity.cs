using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class PagoEntity
    {
        public int idpago { get; set; }
        public string concepto{ get; set; }
        public DateTime fecha_pago { get; set; }
        public int idvehiculo { get; set; }
        public double monto { get; set; }
        public string estado { get; set; }
        //Relaciones
        public VehiculoEntity Vehiculo{ get; set; }
        public List<ObservacionPagoEntity> ListaObservacionPago { get; set; }
        public PagoEntity()
        {
            Vehiculo = new VehiculoEntity();
            ListaObservacionPago = new List<ObservacionPagoEntity>();
        }
    }
}