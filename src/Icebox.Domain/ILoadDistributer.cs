using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

using Icebox.Common.Entities;

namespace Icebox.Common
{
    public interface ILoadDistributor
    {
        string Invoke(IEnumerable<ServerNode> nodes, PersistentDictionary<string, string> store);
    }
}
