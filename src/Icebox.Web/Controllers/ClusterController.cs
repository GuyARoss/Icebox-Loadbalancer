using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Icebox.Common.Entities;
using Icebox.Services;

namespace Icebox.Web.Controllers
{
    [Route("clusters")]
    [ApiController]
    public class ClusterController : ControllerBase
    {
        [HttpPost("create")]
        public ActionResult<Task> CreateCluster([FromBody] ClusterModel model) => Clusters.AddCluster(model);

        [HttpPost("destroy")]
        public ActionResult<Task> DeleteCluster([FromBody] ClusterModel model) => Clusters.DeleteCluster(model);

        [HttpGet("findById")]       
        public ActionResult<ClusterModel> FindById([FromQuery] string id) => Clusters.FindById(id);

        [HttpGet("findAll")]
        public ActionResult<List<ClusterModel>> FindAll() => Clusters.FindAll();

    }
}