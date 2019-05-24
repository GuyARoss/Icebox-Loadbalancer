
namespace Icebox.Domain
{
    public static class IoC
    {
        public static T Resolve<T>() where T : new()
        {
            return new T();
        }
    }
    
}
