using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Icebox.Services;
using Icebox.Web.Common;

namespace Icebox.Web.Controllers
{
    [Route("options")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        [HttpGet("distributorTypes")]
        public ActionResult<List<OptionModel<int>>> DistributorTypes()
        {
            return Clusters.GetDistributorTypes()
                .Select(type => new OptionModel<int>
                {
                    Title = type.Key,
                    Value = type.Value,
                })
                .ToList();
        }

        [HttpGet("gatewayTypes")]
        public ActionResult<List<OptionModel<int>>> GatewayTypes()
        {
            return Clusters.GetGatewayTypes()
                .Select(type => new OptionModel<int>
                {
                    Title = type.Key,
                    Value = type.Value,
                })
                .ToList();
        }
    }
}