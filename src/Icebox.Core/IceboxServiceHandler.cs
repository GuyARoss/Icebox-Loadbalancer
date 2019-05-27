using Icebox.Common;
using Icebox.Common.Entities;

using Icebox.Infrastructure;

using Icebox.Persistance;
using Icebox.Persistance.Extensions;

using Icebox.Core.LoadBalancing;

namespace Icebox.Core
{
    public static class IceboxServiceHandler
    {
        public static string Invoke(string requestedUrl)
        {
            ClusterModel cluster = IoC.Resolve<ClusterRepository>()
                .FindAll()
                .FromRoute(requestedUrl);

            string resolvedLoadBalancer = _resolveLoadBalancer(cluster);
            string resolvedRoute = _routeToProxy(resolvedLoadBalancer);

            return resolvedRoute;
        }

        private static string _resolveLoadBalancer(ClusterModel cluster)
        {
            if (cluster == null) return null;

            var nodePool = IoC.Resolve<ServerNodeRepository>()
                .FindAll()
                .InPool(cluserId: cluster.ClusterId);

            ILoadDistributor loadDistributer = cluster.MapTypeToDistrubtor();

            return new LoadBalancer(loadDistributer, nodePool, cluster.ClusterId)
                .SelectFromPool();
        }

        private static string _routeToProxy(string url) // todo: only supports http
        {
            return new HttpProxy(url)
                .GetResponse();
        }

    }
}
