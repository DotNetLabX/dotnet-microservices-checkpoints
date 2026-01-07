namespace Blocks.Core;

public static class StringExtensions
{
    public static string FormatWith(this string @this, params object[] additionalArgs)
        => string.Format(@this, additionalArgs);

    public static string FormatWith(this string @this, object arg)
        => string.Format(@this, arg);
}

