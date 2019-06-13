using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Icebox.Common.Entities;
using Icebox.Services;

namespace Icebox.Web.Controllers
{
    [Route("service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpPost("create")]
        public ActionResult<Task> CreateCluster([FromBody] ServiceModel model) => ServiceRegistry.AddServerNode(model);

        [HttpPost("destroy")]
        public ActionResult<Task> DeleteClusterNode([FromBody] ServiceModel model) => ServiceRegistry.DeleteServerNode(model);

        [HttpGet("findById")]
        public ActionResult<ServiceModel> FindById([FromQuery] string id) => ServiceRegistry.FindById(id);

        [HttpGet("findAll")]
        public ActionResult<List<ServiceModel>> FindAll() => ServiceRegistry.FindAll();

        [HttpPost("update")]
        public ActionResult<Task> Update(ServiceModel model) => ServiceRegistry.Update(model);
    }
}