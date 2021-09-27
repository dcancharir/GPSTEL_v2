using GPSTEL_API_v2.Entities;
using GPSTEL_API_v2.Models;
using GPSTEL_API_v2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GPSTEL_API_v2.Controllers
{
    public class ClienteController : ApiController
    {
        ClienteModel ClienteBL= new ClienteModel();
        [HttpGet]
        [Route("getjson")]
        public IHttpActionResult GetJson()
        {
            try
            {
                var ChipList = ClienteBL.GetClientesJson();
                return Ok(ChipList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("GetClienteByIdJson")]
        public IHttpActionResult GetClienteByIdJson([FromBody] ClienteEntity cliente)
        {
            try
            {
                var Cliente= ClienteBL.GetClienteByIdJson(cliente.idcliente);
                if (Cliente.idcliente == 0)
                {
                    return NotFound();
                }
                return Ok(Cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveClienteJson")]
        public IHttpActionResult SaveClienteJson([FromBody] ClienteEntity cliente)
        {
            int SavedId = 0;
            try
            {
                ClienteEntity ClienteRepetido = ClienteBL.GetClienteByNroDniRucJson(cliente.dni_ruc);
                if (ClienteRepetido.idcliente == 0)
                {
                    SavedId = ClienteBL.SaveClienteJson(cliente);
                }
                else
                {
                    return BadRequest("El Cliente ya se encuentra registrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(SavedId);
        }
        [HttpPost]
        [Route("EditClienteJson")]
        public IHttpActionResult EditClienteJson([FromBody] ClienteEntity cliente)
        {
            bool Edited = false;
            try
            {
                Edited = ClienteBL.EditClienteJson(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Edited);
        }
        [HttpPost]
        [Route("EditStateofClienteJson")]
        public IHttpActionResult EditStateofClienteJson([FromBody] ClienteEntity cliente)
        {
            bool Edited = false;
            try
            {
                Edited = ClienteBL.EditStateofClienteJson(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(Edited);
        }
    }
}
