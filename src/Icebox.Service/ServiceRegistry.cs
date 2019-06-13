using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Icebox.Common.Entities;
using Icebox.Persistance;

namespace Icebox.Services
{
    public class ServiceRegistry
    {
        private static readonly ServiceRepository _repo = new ServiceRepository();
        public static Task AddServerNode(ServiceModel model) => _repo.Create(model);
        public static Task DeleteServerNode(ServiceModel model) => _repo.Delete(model);
        public static ServiceModel FindById(string id) => _repo.FindById(id);
        public static List<ServiceModel> FindAll() => _repo.FindAll().ToList();
        public static Task Update(ServiceModel model) => _repo.Update(model);
    }
}
