using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Domain;
using Icebox.Domain.Entities;

namespace Icebox.Lb.Distributors
{
    public class RoundRobinDistribution : ILoadDistributor
    {        
        public string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<string, string> store)
        {
            throw new NotImplementedException();
        }
    }
}
