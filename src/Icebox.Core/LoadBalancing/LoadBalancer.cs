using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;

namespace Icebox.Core.LoadBalancing
{
    public class LoadBalancer : IDisposable
    {
        public readonly ILoadDistributor Distributor;
        public readonly IEnumerable<ServerNode> NodePool;

        private readonly PersistentDictionary<int, int> _persistedDictionary;

        public LoadBalancer(ILoadDistributor distributor, IEnumerable<ServerNode> nodePool, string cluserId)
        {
            Distributor = distributor;
            NodePool = nodePool;

            _persistedDictionary = new PersistentDictionary<int, int>(cluserId);
        }

        public void Dispose()
        {
            _persistedDictionary.Dispose();
        }

        public string SelectInstanceFromPool()
        {        
            return Distributor.Invoke(NodePool, _persistedDictionary);                        
        }        
    }
}
