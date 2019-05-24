using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Domain.Entities;

namespace Icebox.Core
{
    public interface ILoadDistributor
    {
        string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<string, string> store);
    }
}
