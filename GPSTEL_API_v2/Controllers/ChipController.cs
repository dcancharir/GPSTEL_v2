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
    [RoutePrefix("api/chip")]
    public class ChipController : ApiController
    {
        ChipModel ChipBL = new ChipModel();
        [HttpGet]
        public IHttpActionResult GetJson()
        {
            var ChipList = ChipBL.GetChipsJson();
            return Ok(ChipList);
        }
        public IHttpActionResult GetChipByIdJson(int id)
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
        public IHttpActionResult SaveChipJson([FromBody] ChipEntity chip)
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
        [HttpPost]
        public IHttpActionResult EditChipJson([FromBody] ChipEntity chip)
        {
            bool Edited = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Edited = ChipBL.EditChipJson(chip);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(Edited);
        }
    }
}
