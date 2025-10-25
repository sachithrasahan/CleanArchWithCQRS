using System.Collections.Concurrent;

namespace Infrastructure.InMemory
{
    public class InMemoryDatabase
    {
        public ConcurrentDictionary<string, object> Store { get; } = new();
    }
}
