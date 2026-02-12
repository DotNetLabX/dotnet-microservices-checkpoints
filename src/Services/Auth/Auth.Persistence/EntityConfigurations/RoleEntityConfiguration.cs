using Auth.Domain.Roles;
using Blocks.Core;
using Blocks.EntityFrameworkCore;
using Blocks.EntityFrameworkCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Persistence.EntityConfigurations;

internal class RoleEntityConfiguration : EntityConfiguration<Role>
{
    public override void Configure(EntityTypeBuilder<Role> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Type).HasEnumConversion().HasMaxLength(MaxLength.C64).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(MaxLength.C256).IsRequired(); ;
    }
}
