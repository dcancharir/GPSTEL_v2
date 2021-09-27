using GPSTEL_API_v2.Entities;
using GPSTEL_API_v2.JWTClasses;
using GPSTEL_API_v2.Models;
using GPSTEL_API_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using GPSTEL_API_v2.Utilities;
using System.Security.Claims;

namespace GPSTEL_API_v2.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        UsuarioModel usuarioBL = new UsuarioModel();
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            var identity2 = identity as ClaimsIdentity;
          
            if (identity2 != null)
            {
                IEnumerable<Claim> claims = identity2.Claims;
                var usernameClaim = claims
                        .Where(x => x.Type == ClaimTypes.Email)
                        .FirstOrDefault();
                return Ok(new { usernameClaim.Value });
            }
            return Unauthorized();
            
            //return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {

            UsuarioEntity usuario = new UsuarioEntity();
            try
            {
                if (login == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);

                //TODO: Validate credentials Correctly, this code is only for demo !!
                usuario = usuarioBL.GetUserForLoginJson(login.Username);
             
                bool isCredentialValid = (Encrypt.MD5(login.Password).Equals(usuario.password));
                if (isCredentialValid)
                {
                    var token = TokenGenerator.GenerateTokenJwt(usuario.nombre,usuario.idusuario);
                    return Ok(new{
                        token,
                        usuario.nombre,
                        usuario.tipo
                        }
                    );
                }
                else
                {
                return Content(HttpStatusCode.Unauthorized, "Wrong Credentials");
                }
              
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }
    }
}
