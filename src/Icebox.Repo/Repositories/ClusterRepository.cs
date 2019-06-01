using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

using Icebox.Common;
using Icebox.Common.Entities;

using Icebox.Infrastructure;

namespace Icebox.Persistance
{
    public class ClusterRepository : Db<ClusterModel>, IRepository<ClusterModel>
    {
        public override string TableName => "clusers";
        public override Dictionary<string, string> TableColumns => new Dictionary<string, string>
        {
            { "Id", "TEXT" },
            { "Name", "TEXT" },
            { "MaxSize", "INTEGER" },
            { "Gateway", "TEXT" },
            { "LoadDistributorType", "INTEGER" },
            { "GatewayType", "INTEGER" },
            { "ServiceId", "TEXT" }
        };

        public Task Create(ClusterModel entity)
        {
            string sql = string.Format("INSERT INTO `{0}` (Id, Name, MaxSize, Gateway, LoadDistributorType) " +
                "VALUES ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", TableName, 
                entity.Id, entity.Name, entity.MaxSize, entity.Gateway, (int)entity.LoadDistributorType, entity.ServiceId);

            return _executeNonQueryCommand(sql);
        }
        public Task Delete(ClusterModel entity)
        {
            string sql = string.Format("delete from `{0}` where Id='{1}'", TableName, entity.Id);

            return _executeNonQueryCommand(sql);
        }
        public IEnumerable<ClusterModel> FindAll()
        {
            string sql = string.Format("select * from `{0}`", TableName);

            return _exectuteQueryCommand(sql, _mapReader);
        }
        public ClusterModel FindById(string id)
        {
            string sql = string.Format("select * from `{0}` WHERE Id='{1}'", TableName, 
                id);

            var clusterModels = _exectuteQueryCommand(sql, _mapReader);

            if (clusterModels.Count() > 0)
            {
                return clusterModels.First(cluser => cluser != null);
            }

            return null;
        }      
        public Task Update(ClusterModel entity)
        {
            string sql = string.Format("update `{0}` set Gateway='{1}', LoadDistrutorType='{2}', MaxSize='{3}', Name='{4}', ServiceId='{5}' WHERE" +
                "Id = '{5}'", TableName, entity.Gateway, entity.LoadDistributorType, entity.MaxSize, entity.Name, 
                entity.Id, entity.ServiceId);

            return _executeNonQueryCommand(sql);
        }

        private ClusterModel _mapReader(SQLiteDataReader reader)
        {
            return new ClusterModel
            {
                Id = reader["Id"] as string,
                Gateway = reader["Gateway"] as string,
                LoadDistributorType = (LoadDistributorType)Convert.ToInt32(reader["LoadDistributorType"]),
                MaxSize = Convert.ToUInt32(reader["MaxSize"]),
                Name = reader["Name"] as string,
                ServiceId = reader["ServiceId"] as string
            };
        }
    }
}
