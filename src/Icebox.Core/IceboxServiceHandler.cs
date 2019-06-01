using System;

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
        public static Tuple<string, GatewayMethodType> Invoke(string requestedUrl)
        {
            ClusterModel cluster = IoC.Resolve<ClusterRepository>()
                .FindAll()
                .FromRoute(requestedUrl);

            string resolvedLoadBalancer = _resolveLoadBalancer(cluster);   

            switch (cluster.GatewayType)
            {
                case GatewayMethodType.PROXY:
                    {
                        string resolvedProxy = _routeToProxy(resolvedLoadBalancer);
                        return new Tuple<string, GatewayMethodType>(resolvedProxy, cluster.GatewayType);
                    }
                case GatewayMethodType.REDIRECT:
                    {
                        return new Tuple<string, GatewayMethodType>(resolvedLoadBalancer, cluster.GatewayType);
                    }
                default:
                    {
                        throw new Exception(string.Format("Gateway Method '{0}' is Not A Supported Type", cluster.GatewayType.ToString()));
                    }
            }
        }

        private static string _resolveLoadBalancer(ClusterModel cluster)
        {
            if (cluster == null) return null;

            var nodePool = IoC.Resolve<ServerNodeRepository>()
                .FindAll()
                .InPool(cluserId: cluster.Id);

            ILoadDistributor loadDistributer = cluster.MapTypeToDistrubtor();

            return new LoadBalancer(loadDistributer, nodePool, cluster.Id)
                .SelectInstanceFromPool();
        }

        private static string _routeToProxy(string url) // todo: only supports http
        {
            return new HttpProxy(url)
                .GetResponse();
        }
    }
}
