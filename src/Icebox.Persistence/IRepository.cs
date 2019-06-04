using System.Collections.Generic;
using System.Threading.Tasks;

namespace Icebox.Persistance
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
