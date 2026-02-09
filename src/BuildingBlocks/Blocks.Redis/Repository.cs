using Redis.OM;
using Redis.OM.Searching;
using StackExchange.Redis;

namespace Blocks.Redis;

public class Repository<T>
    where T : Entity
{
    private readonly IRedisCollection<T> _collection;
    private readonly IDatabase _redisDb;

    public Repository(IConnectionMultiplexer redis, RedisConnectionProvider provider) =>
        (_redisDb, _collection) = (redis.GetDatabase(), provider.RedisCollection<T>());

    public IRedisCollection<T> Collection => _collection;


    public async Task<T?> GetByIdAsync(int id) => await _collection.FindByIdAsync(id.ToString());
    public async Task<IEnumerable<T>> GetAllAsync() => await _collection.ToListAsync();


    public async Task AddAsync(T entity)
    {
        if (entity.Id < 0)
            throw new InvalidOperationException($"Invalid ID: {entity.Id}. IDs must be positive or zero.");

        if (entity.Id == 0)
            entity.Id = await GenerateNewId();

        await _collection.InsertAsync(entity);
    }

    public async Task UpdateAsync(T entity) => await _collection.UpdateAsync(entity);

    public async Task DeleteAsync(T entity) => await _collection.DeleteAsync(entity);

    public async Task SaveAllAsync() => await _collection.SaveAsync();

    public async Task<int> GenerateNewId() => (int)await _redisDb.StringIncrementAsync($"{typeof(T).Name}:Id:Sequence");
}
