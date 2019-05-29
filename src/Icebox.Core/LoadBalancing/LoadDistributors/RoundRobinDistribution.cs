using System.Linq;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;

namespace Icebox.Core.LoadBalancing.Distributors
{
    public class RoundRobinDistribution : ILoadDistributor
    {        
        public string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<int, int> store)
        {           
            int currentId = store.Count == 0 ? 0 : store[0]; // is 0th index if store is empty.

            if (currentId >= nodes.Count()) 
            {
                currentId = 0;
            }

            store[0] = currentId >= nodes.Count() ? 0 : currentId + 1; // update index

            return nodes.ToList()[currentId].Address;
        }       
    }
}
