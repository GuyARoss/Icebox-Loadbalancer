using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Icebox.Common.Entities;
using Icebox.Persistance;

namespace Icebox.Services
{
    public static class ServerNodes
    {
        private static readonly ServerNodeRepository _repo = new ServerNodeRepository();
        private static readonly ClusterRepository _clusterRepository = new ClusterRepository();
        private static readonly ServiceRepository _serviceRepo = new ServiceRepository();

        public static Task AddServerNode(ServerNode model) // this process is too expensive...
        {
            var foundCluster = _clusterRepository.FindById(model.ClusterId);

            var nodesByCluster = _repo.FindByClusterId(model.ClusterId);

            int currentSize = model.ClusterId != null && nodesByCluster != null ? nodesByCluster.Count() : 0;
            var foundService = _serviceRepo.FindById(model.ServiceId);            

            if (foundCluster != null && foundCluster.MaxSize < currentSize)
            {
                throw new System.Exception(string.Format("Max Size for Cluster Exceeded, Current Limit is {0}", foundCluster.MaxSize));
            } else if (foundService == null)
            {
                throw new System.Exception(string.Format("Service Does Not Exist, To Create a Cluster a Valid Serice Should Exist"));
            }

            return _repo.Create(model);
        }
        public static Task DeleteServerNode(ServerNode model) => _repo.Delete(model);
        public static ServerNode FindById(string id) => _repo.FindById(id);
        public static List<ServerNode> FindAll() => _repo.FindAll().ToList();
    }
}
