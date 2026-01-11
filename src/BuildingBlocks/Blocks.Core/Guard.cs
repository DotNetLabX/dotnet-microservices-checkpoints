namespace Blocks.Core;

public static class Guard
{
	public static void ThrowIfNullOrWhiteSpace(string value)
		=> ArgumentException.ThrowIfNullOrWhiteSpace(value);

    public static void ThrowIfNotEqual<T>(T value, T other) where T : IEquatable<T>?
        => ArgumentOutOfRangeException.ThrowIfNotEqual(value, other);

    public static T AgainstNull<T>(T? value, string parameterName)
        => value ?? throw new ArgumentNullException(parameterName, $"Value cannot be null: '{parameterName}'.");

}
