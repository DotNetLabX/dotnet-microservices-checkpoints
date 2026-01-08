namespace Blocks.Domain.ValueObjects;

public abstract class StringValueObject : IEquatable<StringValueObject>, IEquatable<string>
{
    public string Value { get; protected set; } = default!;

    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value.ToString();

    public bool Equals(StringValueObject? other) => Value.Equals(other?.Value);
    public bool Equals(string? other) => Value.Equals(other);
}
