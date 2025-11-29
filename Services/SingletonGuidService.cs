using Scoped_Transient_Demo.Interfaces;

namespace Scoped_Transient_Demo.Services
{
    public class SingletonGuidService : IGuidService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
