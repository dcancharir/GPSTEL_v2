using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace GPSTEL_API_v2.Controllers
{
    [Authorize]
    [RoutePrefix("api/security")]
    public class SecurityController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("GetControllersJson")]
        public IHttpActionResult GetControllersJson()
        {
            try
            {

                Assembly asm = Assembly.GetAssembly(typeof(GPSTEL_API_v2.WebApiApplication));

                var controlleractionlist = asm.GetTypes()
                        .Where(type => typeof(ApiController).IsAssignableFrom(type))
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                        .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
                return Ok(controlleractionlist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetControllersJsonV2")]
        public IHttpActionResult GetControllersJsonV2()
        {
            try
            {

                Assembly asm = Assembly.GetAssembly(typeof(GPSTEL_API_v2.WebApiApplication));

                var controlleractionlist = asm.GetTypes()
                        .Where(type => typeof(ApiController).IsAssignableFrom(type))
                        .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                        .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                        .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
                return Ok(controlleractionlist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //        public List<dynamic> MetodosLista_List()
        //        {
        //            Assembly asm = Assembly.GetAssembly(typeof(GPSTEL_API_v2.WebApiApplication));
        //            var lista = asm.GetTypes()
        //                        .Where(type => typeof(ApiController).IsAssignableFrom(type))
        //                        .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        //                        .Where(m => (System.Attribute.GetCustomAttributes(typeof(autorizacion), true).Length > 0))
        //                        .Where(m => (String.Join(",", (m.GetCustomAttributesData()
        //                                                                .Where(f => f.Constructor.DeclaringType.Name == "seguridad")
        //                                                                .Select(c => (c.ConstructorArguments[0].Value))))
        //                                                          != "False"))
        //                        .Select(x => new
        //                        {
        //                            Controller = x.DeclaringType.Name,
        //                            Action = x.Name,
        //                            ReturnType = x.ReturnType.Name,
        //                            Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
        //                            AttributesControlador = x.DeclaringType.GetCustomAttributesData(),
        //                            AttributesControladorString = String.Join(",", x.DeclaringType.GetCustomAttributesData().Select(
        //                                         a => String.Join(",", a.ConstructorArguments.Select(b => a.AttributeType.Name + " = " + b.Value))
        //                                )),
        //                            AttributesMetodo = x.GetCustomAttributesData(),
        //                            AttributesMetodostring = String.Join(",", x.GetCustomAttributesData()
        //                                  .Select(
        //                                         a => String.Join(",", a.ConstructorArguments.Select(b => a.AttributeType.Name + " = " + b.Value))
        //)),

        //                        })
        //                        .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
        //            return lista.ToList<dynamic>();

        //        }

    }
}
