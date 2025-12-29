using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Blocks.EntityFramework;

public static class BuilderExtensions
{
    public static PropertyBuilder<TEnum> HasEnumConversion<TEnum>(this PropertyBuilder<TEnum> builder)
        where TEnum : Enum
    {
        return builder.HasConversion(
            e => e.ToString(),
            value => (TEnum)Enum.Parse(typeof(TEnum), value));
    }

		public static PropertyBuilder<T> HasJsonCollectionConversion<T>(this PropertyBuilder<T> builder)
				=> builder.HasConversion(BuildJsonListConvertor<T>());

		public static ValueConverter<TCollection, string> BuildJsonListConvertor<TCollection>()
		{
				Func<TCollection, string> serializeFunc = v => JsonSerializer.Serialize(v);
				Func<string, TCollection> deserializeFunc = v => JsonSerializer.Deserialize<TCollection>(v ?? "[]")!;

				return new ValueConverter<TCollection, string>(
						v => serializeFunc(v),
						v => deserializeFunc(v));
		}
}
