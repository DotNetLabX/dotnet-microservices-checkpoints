namespace Blocks.Core;

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        => !enumerable.Any();

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        => enumerable == null || !enumerable.Any();
}
