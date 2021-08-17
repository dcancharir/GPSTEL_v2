using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPSTEL_API_v2.Entities
{
    public class ClienteEntity
    {
        public int idcliente { get; set; }
        public DateTime fecha_contrato { get; set; }
        public string estado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni_ruc { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string direccion { get; set; }
        public int iddistrito { get; set; }
        public DistritoEntity Distrito { get; set; }
        public List<VehiculoEntity> ListaVehiculo { get; set; }
        public List<ObservacionClienteEntity> ListaObservacionCliente { get; set; }
        public ClienteEntity()
        {
            Distrito = new DistritoEntity();
            ListaVehiculo = new List<VehiculoEntity>();
            ListaObservacionCliente = new List<ObservacionClienteEntity>();
        }
    }
}