using System.Linq;
using System.Collections.Generic;

using Icebox.Common;
using Icebox.Common.Entities;


namespace Icebox.Persistance.Extensions
{
    public static class ClusterExtensions
    {
        public static ClusterModel FromRoute(this IEnumerable<ClusterModel> clusers, string gateway)
        {
            return clusers
                .First(cluser => gateway.Contains(cluser.Gateway));
        }
    }
}
