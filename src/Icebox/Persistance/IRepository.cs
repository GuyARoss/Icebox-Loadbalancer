using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icebox.Core.Persistance
{
    public interface IRepository<T>
    {
        T FindById(string id);
        IEnumerable<T> FindAll();
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
