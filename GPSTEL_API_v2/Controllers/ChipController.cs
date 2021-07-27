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
    [RoutePrefix("api/chip")]
    public class ChipController : ApiController
    {
        ChipModel ChipBL = new ChipModel();
        [HttpGet]
        public IHttpActionResult Get()
        {
            var ChipList = ChipBL.GetChipsJson();
            return Ok(ChipList);
        }
        public IHttpActionResult GetChipById(int id)
        {
            try
            {
                var Chip = ChipBL.GetChipByIdJson(id);
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
        public IHttpActionResult Post([FromBody] ChipEntity chip)
        {
            int SavedId = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                SavedId = ChipBL.SaveChipJson(chip);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(SavedId);
        }
    }
}
