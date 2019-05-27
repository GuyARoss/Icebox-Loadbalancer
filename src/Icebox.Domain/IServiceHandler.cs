using System.Threading.Tasks;

namespace Icebox.Common
{
    public interface IServiceHandler
    {
        Task Invoke();
    }
}
