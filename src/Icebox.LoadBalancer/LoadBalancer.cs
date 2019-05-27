using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Domain;
using Icebox.Domain.Entities;

namespace Icebox.Lb
{
    public class LoadBalancer
    {
        public readonly ILoadDistributor Distributor;
        public readonly IEnumerable<ServerNode> NodePool;

        private readonly PersistentDictionary<string, string> _persistedDictionary;

        public LoadBalancer(ILoadDistributor distributor, IEnumerable<ServerNode> nodePool, string cluserId)
        {
            Distributor = distributor;
            NodePool = nodePool;

            _persistedDictionary = new PersistentDictionary<string, string>(cluserId);
        }

        public string SelectFromPool()
        {            
            return Distributor.Invoke(NodePool, _persistedDictionary);
        }
    }
}
