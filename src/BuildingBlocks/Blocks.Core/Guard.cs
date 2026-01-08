namespace Blocks.Core;

public static class Guard
{
	public static void ThrowIfNullOrWhiteSpace(string value)
		=> ArgumentException.ThrowIfNullOrWhiteSpace(value);

    public static void ThrowIfNotEqual<T>(T value, T other) where T : IEquatable<T>?
        => ArgumentOutOfRangeException.ThrowIfNotEqual(value, other);
}
