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
        [HttpPost]
        [Route("GetDepartamentosJson")]
        public IHttpActionResult GetDepartamentosJson()
        {
            try
            {
                var List = DepartamentoBL.GetDepartamentosJson();
                return Ok(List);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("GetProvinciasByDepartamentoJson")]
        public IHttpActionResult GetProvinciasByDepartamentoJson([FromBody] int iddepartamento)
        {
            try
            {
                var List = ProvinciaBL.GetProvinciasByDepartamentoJson(iddepartamento);
                return Ok(List);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("GetDistritosByProvinciaJson")]
        public IHttpActionResult GetDistritosByProvinciaJson([FromBody] int idprovincia)
        {
            try
            {
                var List = DistritoBL.GetDistritosByProvinciaJson(idprovincia);
                return Ok(List);
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
