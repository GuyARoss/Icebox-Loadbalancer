using System;
using System.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;
using Icebox.Infrastructure;

namespace Icebox.Core.LoadBalancing
{
    public class LoadBalancer : IDisposable
    {   
        public readonly ILoadDistributor Distributor;
        public readonly IEnumerable<ServerNode> NodePool;

        private readonly PersistentDictionary<int> _persistedDictionary;
        
        public LoadBalancer(ILoadDistributor distributor, IEnumerable<ServerNode> nodePool, string clusterId)
        {
            Distributor = distributor;
            NodePool = nodePool;

            _persistedDictionary = new PersistentDictionary<int>(clusterId);            
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
