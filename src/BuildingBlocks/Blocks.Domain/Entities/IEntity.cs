namespace Blocks.Domain.Entities;

public interface IEntity
{
    public int Id { get; }
}

public interface IEntity<TPrimaryKey>
    where TPrimaryKey : struct
{
    TPrimaryKey Id { get; }
}

//public abstract class Entity : Entity<int>, IEntity;

public abstract class Entity : IEntity
{
    public virtual int Id { get; init; }
}


public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    where TPrimaryKey : struct
{
    public virtual TPrimaryKey Id { get; init; }
}