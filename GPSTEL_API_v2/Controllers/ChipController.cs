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
        [Route("getjson")]
        public IHttpActionResult GetJson()
        {
            try
            {
                var ChipList = ChipBL.GetChipsJson();
                return Ok(ChipList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("getchipbyidjson")]
        public IHttpActionResult GetChipByIdJson([FromBody] ChipEntity chip)
        {
            try
            {
                var Chip = ChipBL.GetChipByIdJson(chip.idchip);
                if (Chip.idchip == 0)
                {
                    return NotFound();
                }
                return Ok(Chip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveChipJson")]
        public IHttpActionResult SaveChipJson([FromBody] ChipEntity chip)
        {
            int SavedId = 0;
            try
            {
                SavedId = ChipBL.SaveChipJson(chip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(SavedId);
        }
        [HttpPost]
        [Route("EditChipJson")]
        public IHttpActionResult EditChipJson([FromBody] ChipEntity chip)
        {
            bool Edited = false;
            try
            {
                Edited = ChipBL.EditChipJson(chip);
            }
            catch (Exception ex)
            {
                return BadRequest (ex.Message);
            }
            return Ok(Edited);
        }
        [HttpPost]
        [Route("EditStateofChipJson")]
        public IHttpActionResult EditStateofChipJson([FromBody] ChipEntity chip)
        {
            bool Edited = false;
            try
            {
                Edited = ChipBL.EditStateofChipJson(chip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Edited);
        }
    }
}
