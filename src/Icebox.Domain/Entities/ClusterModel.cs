namespace Icebox.Common.Entities
{
    public class ClusterModel
    {
        public string ClusterId { get; set; }
        public string Name { get; set; }
        public uint MaxSize { get; set; }
        public string Gateway { get; set; }
        public LoadDistributorType LoadDistributorType { get; set; }
        public GatewayMethodType GatewayType { get; set; }
    }
}
