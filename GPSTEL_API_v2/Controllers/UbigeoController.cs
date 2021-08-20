using GPSTEL_API_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GPSTEL_API_v2.Controllers
{
    [RoutePrefix("api/ubigeo")]
    public class UbigeoController : ApiController
    {
        DepartamentoModel DepartamentoBL = new DepartamentoModel();
        ProvinciaModel ProvinciaBL = new ProvinciaModel();
        DistritoModel DistritoBL = new DistritoModel();
        [HttpGet]
        public IHttpActionResult GetDepartamentosJson()
        {
            var List = DepartamentoBL.GetDepartamentosJson();
            return Ok(List);
        }
        [HttpPost]
        public IHttpActionResult GetProvinciasByDepartamentoJson([FromBody] int iddepartamento)
        {
            var List = ProvinciaBL.GetProvinciasByDepartamentoJson(iddepartamento);
            return Ok(List);
        }
        [HttpPost]
        public IHttpActionResult GetDistritosByProvinciaJson([FromBody] int idprovincia)
        {
            var List = DistritoBL.GetDistritosByProvinciaJson(idprovincia);
            return Ok(List);
        }
    }
}
