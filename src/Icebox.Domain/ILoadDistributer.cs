using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Common.Entities;
using System.Threading.Tasks;

namespace Icebox.Common
{
    public interface ILoadDistributor
    {
        string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<int, int> store);
    }
}
