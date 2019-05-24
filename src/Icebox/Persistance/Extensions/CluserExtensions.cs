using System.Linq;
using System.Collections.Generic;

using Icebox.Domain;
using Icebox.Domain.Entities;

using Icebox.Core.LoadDistributors;

namespace Icebox.Core.Persistance.Extensions
{
    public static class ClusterExtensions
    {
        public static ClusterModel FromRoute(this IEnumerable<ClusterModel> clusers, string gateway)
        {
            return clusers
                .First(cluser => gateway.Contains(cluser.Gateway));
        }
        public static ILoadDistributor MapTypeToDistrubtor(this ClusterModel node)
        {
            switch (node.LoadDistributorType)
            {
                case LoadDistributorType.ROUND_ROBIN:
                    return IoC.Resolve<RoundRobinDistribution>();
                default:
                    return null;
            }
        }
    }
}
