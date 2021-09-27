using GPSTEL_API_v2.Entities;
using GPSTEL_API_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GPSTEL_API_v2.Controllers
{
    public class VehiculoController : ApiController
    {
        VehiculoModel VehiculoBL= new VehiculoModel();
        [HttpGet]
        [Route("getjson")]
        public IHttpActionResult GetJson()
        {
            try
            {
                var VehiculosList = VehiculoBL.GetVehiculosJson();
                return Ok(VehiculosList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("GetVehiculosByIdJson")]
        public IHttpActionResult GetVehiculosByIdJson([FromBody] VehiculoEntity vehiculo)
        {
            try
            {
                var Vehiculo = VehiculoBL.GetVehiculoByIdJson(vehiculo.idvehiculo);
                if (Vehiculo.idvehiculo == 0)
                {
                    return NotFound();
                }
                return Ok(Vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveVehiculoJson")]
        public IHttpActionResult SaveVehiculoJson([FromBody] VehiculoEntity vehiculo)
        {
            int SavedId = 0;
            try
            {
                SavedId = VehiculoBL.SaveVechiculoJson(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(SavedId);
        }
        [HttpPost]
        [Route("EditVehiculoJson")]
        public IHttpActionResult EditVehiculoJson([FromBody] VehiculoEntity vehiculo)
        {
            bool Edited = false;
            try
            {
                Edited = VehiculoBL.EditVehiculoJson(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Edited);
        }
        [HttpPost]
        [Route("EditStateofVehiculoJson")]
        public IHttpActionResult EditStateofVehiculoJson([FromBody] VehiculoEntity vehiculo)
        {
            bool Edited = false;
            try
            {
                Edited = VehiculoBL.EditStateofVehiculoJson(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Edited);
        }
    }
}
