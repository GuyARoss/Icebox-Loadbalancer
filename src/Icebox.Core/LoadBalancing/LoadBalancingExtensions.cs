using Icebox.Common;
using Icebox.Common.Entities;

using Icebox.Core.LoadBalancing.Distributors;

namespace Icebox.Core.LoadBalancing
{
    public static class LoadBalancingExtensions
    {
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
