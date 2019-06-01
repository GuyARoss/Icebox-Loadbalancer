using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Icebox.Common.Entities;
using Icebox.Web.Services;

namespace Icebox.Web.Controllers
{
    [Route("node")]
    [ApiController]
    public class ServerNodeController : ControllerBase
    {
        [HttpPost("create")]
        public ActionResult<Task> CreateCluster([FromBody] ServerNode model) => ServerNodes.AddServerNode(model);

        [HttpPost("destory")]
        public ActionResult<Task> DeleteClusterNode([FromBody] ServerNode model) => ServerNodes.DeleteServerNode(model);

        [HttpGet("findById")]
        public ActionResult<ServerNode> FindById([FromQuery] string id) => ServerNodes.FindById(id);

        [HttpGet("findAll")]
        public ActionResult<List<ServerNode>> FindAll() => ServerNodes.FindAll();
    }
}