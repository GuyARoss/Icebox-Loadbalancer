using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Icebox.Domain.Entities;
using Icebox.Core.Persistance;

namespace IceBox.Web.Services
{
    public static class ServerNodes
    {
        private static readonly ServerNodeRepository _repo = new ServerNodeRepository();
        public static Task AddServerNode(ServerNode model) => _repo.Create(model);
        public static Task DeleteServerNode(ServerNode model) => _repo.Delete(model);
        public static ServerNode FindById(string id) => _repo.FindById(id);
        public static List<ServerNode> FindAll() => _repo.FindAll().ToList();
    }
}
