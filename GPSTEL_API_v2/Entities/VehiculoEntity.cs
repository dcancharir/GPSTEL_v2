using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class VehiculoEntity
    {
        public int idvehiculo { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string anio_vehiculo { get; set; }
        public string color { get; set; }
        public string nro_motor { get; set; }
        public string particular_mtc { get; set; }
        public string estado { get; set; }
        public int idgps { get; set; }
        public DateTime fecha_instalacion { get; set; }
        public int idcliente { get; set; }
        public string mensualidad { get; set; }
        //Relaciones
        public GpsEntity GPS { get; set; }
        public ClienteEntity Cliente { get; set; }
        public List<ObservacionVehiculoEntity> ListaObservacionVehiculo { get; set; }
        public VehiculoEntity()
        {
            GPS = new GpsEntity();
            Cliente = new ClienteEntity();
            ListaObservacionVehiculo = new List<ObservacionVehiculoEntity>();
        }
    }
}