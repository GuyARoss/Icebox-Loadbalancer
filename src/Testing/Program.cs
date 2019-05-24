using System;

using Icebox.Core.Persistance;
using Icebox.Domain.Entities;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var rq = new ClusterRepository();

            rq.Create(new ClusterModel
            {
                ClusterId = "123",
                Gateway ="11",
                LoadDistributorType = 0,
                MaxSize = 12,
                Name = "idk"
            });

            Console.WriteLine();
            Console.Read();
        }
    }
}
