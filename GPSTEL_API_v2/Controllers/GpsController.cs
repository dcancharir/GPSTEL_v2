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
        public IHttpActionResult GetJson()
        {
            var GpsListList = ChipBL.GetGpssJson();
            return Ok(GpsListList);
        }
        public IHttpActionResult GetGpsByIdJson(int id)
        {
            try
            {
                var Chip = ChipBL.GetGpsByIdJson(id);
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
        public IHttpActionResult SaveGpsJson([FromBody] GpsEntity gps)
        {
            int SavedId = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                SavedId = ChipBL.SaveGpsJson(gps);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(SavedId);
        }
        [HttpPost]
        public IHttpActionResult EditGpsJson([FromBody] GpsEntity gps)
        {
            bool Edited = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Edited = ChipBL.EditGpsJson(gps);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(Edited);
        }
    }
}
