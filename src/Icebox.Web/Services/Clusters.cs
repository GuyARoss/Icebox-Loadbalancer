using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Icebox.Domain;
using Icebox.Domain.Entities;
using Icebox.Core.Persistance;

namespace IceBox.Web.Services
{
    public static class Clusters
    {
        private static readonly ClusterRepository _repo = new ClusterRepository();

        public static Task AddCluster(ClusterModel model) => _repo.Create(model);
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
    }
}
