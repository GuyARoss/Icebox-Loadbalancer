using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;
using Icebox.Persistance;

namespace Icebox.Services
{
    public static class Clusters
    {
        private static readonly ClusterRepository _repo = new ClusterRepository();
        private static readonly ServiceRepository _serviceRepo = new ServiceRepository();

        public static Task AddCluster(ClusterModel model)
        {
            var foundService = _serviceRepo.FindById(model.ServiceId);

            if (foundService == null)
            {
                throw new Exception("Service Does Not Exist, To Create a Cluster a Valid Serice Should Exist");
            }
            
            return _repo.Create(model);
        }
        public static Task DeleteCluster(ClusterModel model) => _repo.Delete(model);
        public static ClusterModel FindById(string id) => _repo.FindById(id);
        public static List<ClusterModel> FindAll() => _repo.FindAll().ToList();
        public static Dictionary<string, int> GetDistributorTypes()
        {
            var typesDic = new Dictionary<string, int>();

            foreach (int value in Enum.GetValues(typeof(LoadDistributorType)))
            {
                typesDic.Add(Enum.GetName(typeof(LoadDistributorType), value), value);
            }

            return typesDic;
        }
        public static Dictionary<string, int> GetGatewayTypes()
        {
            var typesDic = new Dictionary<string, int>();

            foreach (int value in Enum.GetValues(typeof(GatewayMethodType)))
            {
                typesDic.Add(Enum.GetName(typeof(GatewayMethodType), value), value);
            }

            return typesDic;
        }
    }
}
