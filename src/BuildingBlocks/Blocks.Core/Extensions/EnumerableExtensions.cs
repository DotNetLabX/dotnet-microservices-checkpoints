namespace Blocks.Core;

public static class EnumerableExtensions
{
    public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        => !enumerable.Any();
}
