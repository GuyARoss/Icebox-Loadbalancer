using System;
using System.Collections.Generic;

using Icebox.Common.Entities;
using System.Threading.Tasks;

using Icebox.Infrastructure;

namespace Icebox.Common
{
    public interface ILoadDistributor
    {
        string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<int> store);
    }
}
