using Blocks.Core;
using Blocks.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;

namespace Submission.Persistence.EntityConfigurations;

public class AssetTypeDefinitionEntityConfiguration : IEntityTypeConfiguration<AssetTypeDefinition>
{
    public void Configure(EntityTypeBuilder<AssetTypeDefinition> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(e => e.Name).HasEnumConversion().IsRequired().HasMaxLength(MaxLength.C64).HasColumnOrder(1);
        builder.Property(e => e.MaxFileSizeInMB).HasDefaultValue(5); // 5MB
        builder.Property(e => e.DefaultFileExtension).HasDefaultValue("pdf").IsRequired().HasMaxLength(MaxLength.C8);

        builder.ComplexProperty(e => e.AllowedFileExtensions, builder =>
        {
            var convertor = BuilderExtensions.BuildJsonListConvertor<string>();
            builder.Property(e => e.Extensions)
                .HasConversion(convertor)
                .HasColumnName(builder.Metadata.PropertyInfo!.Name)
                .IsRequired();
        });
    }
}
