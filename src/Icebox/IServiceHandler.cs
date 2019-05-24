using System.Threading.Tasks;

namespace Icebox.Core
{
    public interface IServiceHandler
    {
        Task Invoke();
    }
}
