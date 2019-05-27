using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;

namespace Icebox.Core.LoadBalancing.Distributors
{
    public class RoundRobinDistribution : ILoadDistributor
    {        
        public string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<string, string> store)
        {
            throw new NotImplementedException();
        }
    }
}
