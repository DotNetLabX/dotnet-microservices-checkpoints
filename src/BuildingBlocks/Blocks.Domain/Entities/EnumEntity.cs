namespace Blocks.Domain.Entities;

public abstract class EnumEntity<TEnum>  : Entity<TEnum>
    where TEnum : struct, Enum
{
    public TEnum Name { get; init; } = default!;
}
