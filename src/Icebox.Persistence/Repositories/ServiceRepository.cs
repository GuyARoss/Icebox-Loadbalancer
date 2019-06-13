using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Icebox.Common.Entities;

using Icebox.Infrastructure;

namespace Icebox.Persistance
{
    public class ServiceRepository : Db<ServiceModel>, IRepository<ServiceModel>
    {
        public override string TableName => "services";
        public override Dictionary<string, string> TableColumns => new Dictionary<string, string>{
            { "Id", "TEXT" },
            { "Name", "TEXT" },
            { "Description", "TEXT" },
        };

        public Task Create(ServiceModel entity)
        {
            string sql = string.Format("INSERT INTO `{0}` (Id, Name, Description) VALUES ('{1}', '{2}', '{3}')",
                TableName, entity.Id, entity.Name, entity.Description);

            return _executeNonQueryCommand(sql);
        }

        public Task Delete(ServiceModel entity)
        {
            string sql = string.Format("delete from `{0}` where Id='{1}'", TableName, entity.Id);

            return _executeNonQueryCommand(sql);
        }

        public IEnumerable<ServiceModel> FindAll()
        {
            string sql = string.Format("select * from `{0}`", TableName);
            return _exectuteQueryCommand(sql, _mapReader);
        }

        public ServiceModel FindById(string id)
        {
            string sql = string.Format("select * from `{0}` WHERE Id='{1}'", TableName, id);

            var models = _exectuteQueryCommand(sql, _mapReader);

            if (models.Count() > 0)
            {
                return models.First(cluser => cluser != null);
            }

            return null;
        }

        public Task Update(ServiceModel entity)
        {
            string sql = string.Format("update `{0}` set Name='{1}', Description='{2}' WHERE Id='{3}'",
                TableName, entity.Name, entity.Description, entity.Id);

            return _executeNonQueryCommand(sql);
        }

        private ServiceModel _mapReader(SQLiteDataReader reader)
        {
            return new ServiceModel
            {
                Id = reader["Id"] as string,
                Description = reader["Description"] as string,
                Name = reader["Name"] as string,
            };
        }
    }
}
