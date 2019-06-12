using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Icebox.Core;
using Icebox.Common;

namespace Icebox.Web.Controllers
{
    [Route("gateway/{*any}")]
    [ApiController]
    public class GatewayController : ControllerBase
    {        
        public ActionResult<string> Invoke()
        {
             string pathValue = HttpContext.Request.Path.Value.Replace("gateway/", "");


            Tuple<string, GatewayMethodType> resolvedHanlder = IceboxServiceHandler.Invoke(pathValue);

            if (resolvedHanlder.Item2 == GatewayMethodType.REDIRECT)
            {
                return new RedirectResult(resolvedHanlder.Item1);
            } else
            {
                return resolvedHanlder.Item1;
            }
        }
    }
}