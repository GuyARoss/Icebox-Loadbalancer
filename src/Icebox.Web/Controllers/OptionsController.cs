using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using IceBox.Web.Services;
using IceBox.Web.Entities;

namespace IceBox.Web.Controllers
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
    }
}