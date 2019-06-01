using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Icebox.Common.Entities;

using Icebox.Infrastructure;

namespace Icebox.Persistance
{
    public class ServerNodeRepository : Db<ServerNode>, IRepository<ServerNode>
    {
        public override Dictionary<string, string> TableColumns => new Dictionary<string, string>
        {
            { "Id", "TEXT" },
            { "Name", "TEXT" },
            { "Address", "TEXT"},
            { "ClusterId", "TEXT" },
        };

        public override string TableName =>"nodes";

        public Task Create(ServerNode entity)
        {
            string sql = string.Format("INSERT INTO `{0}` (ClusterId, Name, Id, Address) " +
                "VALUES ('{1}', '{2}', '{3}', '{4}')", TableName,
                entity.ClusterId, entity.Name, entity.Id, entity.Address);

            return _executeNonQueryCommand(sql);
        }

        public Task Delete(ServerNode entity)
        {
            string sql = string.Format("delete from `{0}` Id='{1}'", TableName, entity.Id);

            return _executeNonQueryCommand(sql);
        }

        public IEnumerable<ServerNode> FindAll()
        {
            string sql = string.Format("select * from `{0}`", TableName);

            return _exectuteQueryCommand(sql, _mapReader);
        }

        public ServerNode FindById(string id)
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

        public Task Update(ServerNode entity)
        {
            string sql = string.Format("update `{0}` set ClusterId='{1}', Name='{2}', Address='{3}' WHERE" +
                "Id = '{4}'", TableName, entity.ClusterId, entity.Name, entity.Address, entity.Id);

            return _executeNonQueryCommand(sql);
        }

        private ServerNode _mapReader(SQLiteDataReader reader)
        {
            return new ServerNode
            {
                ClusterId = reader["ClusterId"] as string,
                Id = reader["Id"] as string,
                Name = reader["Name"] as string,
                Address = reader["Address"] as string,
            };
        }
    }
}
