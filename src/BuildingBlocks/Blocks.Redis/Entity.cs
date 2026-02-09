using Redis.OM.Modeling;

namespace Blocks.Redis;

public class Entity
{
    [RedisIdField]
    [Indexed]
    public int Id { get; set; }
}
