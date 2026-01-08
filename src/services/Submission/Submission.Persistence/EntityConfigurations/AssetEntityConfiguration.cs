using Blocks.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using Blocks.EntityFramework;
using Blocks.Core;
namespace Submission.Persistence.EntityConfigurations;

internal class AssetEntityConfiguration : EntityConfiguration<Asset>
{
    public override void Configure(EntityTypeBuilder<Asset> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Type).HasEnumConversion().IsRequired();

        builder.ComplexProperty(
             e => e.Name, builder =>
             {
                 builder.Property(vo => vo.Value)
                     .HasColumnName(builder.Metadata.PropertyInfo!.Name)
                     .HasMaxLength(MaxLength.C64).IsRequired();
             });

        builder.ComplexProperty(e => e.File, fileBuilder =>
        {
            new FileEntityConfiguration().Configure(fileBuilder);
        });
    }
}