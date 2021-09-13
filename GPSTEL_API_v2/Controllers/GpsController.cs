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
    [Authorize]
    [RoutePrefix("api/gps")]
    public class GpsController : ApiController
    {
        GpsModel ChipBL = new GpsModel();
        [HttpGet]
        [Route("getjson")]
        [ActionName("getjson")]
        public IHttpActionResult GetJson()
        {
            try
            {
                var GpsListList = ChipBL.GetGpssJson();
                return Ok(GpsListList);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("GetGpsByIdJson")]
        public IHttpActionResult GetGpsByIdJson([FromBody] GpsEntity gps)
        {
            try
            {
                var Chip = ChipBL.GetGpsByIdJson(gps.idgps);
                if (Chip.idchip == 0)
                {
                    return NotFound();
                }
                return Ok(Chip);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("SaveGpsJson")]
        public IHttpActionResult SaveGpsJson([FromBody] GpsEntity gps)
        {
            int SavedId = 0;
            try
            {
                SavedId = ChipBL.SaveGpsJson(gps);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(SavedId);
        }
        [HttpPost]
        [Route("EditGpsJson")]
        public IHttpActionResult EditGpsJson([FromBody] GpsEntity gps)
        {
            bool Edited = false;
            try
            {
                Edited = ChipBL.EditGpsJson(gps);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(Edited);
        }
        [HttpPost]
        [Route("EditStateofGpsJson")]
        public IHttpActionResult EditStateofGpsJson([FromBody] GpsEntity gps)
        {
            bool Edited = false;
            try
            {
                Edited = ChipBL.EditStateofGpsJson(gps);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(Edited);
        }
    }
}
