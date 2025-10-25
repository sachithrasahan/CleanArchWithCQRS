using Application.Interfaces;
using System.Collections.Concurrent;

namespace Infrastructure.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly ConcurrentDictionary<Guid, T> _data;

        public InMemoryRepository(InMemoryDatabase db)
        {
            // use a separate dictionary per type
            var typeKey = typeof(T).FullName!;


            // store nested dictionaries inside a single global store to simulate multiple tables
            if (!db.Store.TryGetValue(typeKey, out var obj))
            {
                var dict = new ConcurrentDictionary<Guid, T>();
                db.Store[typeKey] = dict;
                _data = dict;
            }
            else
            {
                _data = (ConcurrentDictionary<Guid, T>)obj;
            }
        }

        public Task AddAsync(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null) throw new InvalidOperationException("Entity does not have an Id property");

            var id = (Guid)idProperty.GetValue(entity)!;
            _data[id] = entity;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _data.TryRemove(id, out _);
            return Task.CompletedTask;
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            _data.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<T>> ListAsync()
        {
            return Task.FromResult<IEnumerable<T>>(_data.Values.AsEnumerable());
        }

        public Task UpdateAsync(T entity)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null) throw new InvalidOperationException("Entity does not have an Id property");

            var id = (Guid)idProperty.GetValue(entity)!;
            _data[id] = entity;
            return Task.CompletedTask;
        }
    }
}
