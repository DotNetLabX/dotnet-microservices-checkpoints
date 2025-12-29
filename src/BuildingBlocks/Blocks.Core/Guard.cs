namespace Blocks.Core;

public static class Guard
{
		public static void ThrowIfNullOrWhiteSpace(string value)
				=> ArgumentException.ThrowIfNullOrWhiteSpace(value);

}
