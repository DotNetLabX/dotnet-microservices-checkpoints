using Auth.Domain.Users;
using Blocks.Core;
using Blocks.EntityFramework;
using Blocks.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Persistence.EntityConfigurations;

internal class UserEntityConfiguration : EntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(MaxLength.C64);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(MaxLength.C64);
        builder.Property(e => e.Gender).IsRequired().HasEnumConversion();

        builder.OwnsOne(
            e => e.Honorific, b =>
            {
                b.Property(e => e.Value)
                    .HasMaxLength(MaxLength.C32)
                    .HasColumnName(nameof(User.Honorific));
                
                b.WithOwner(); //required to avoid navigation issues
            }
        );

        builder.OwnsOne(
            e => e.ProfessionalProfile, b =>
            {
                b.Property(e => e.Position).HasMaxLength(MaxLength.C32).HasColumnNameSameAsProperty();
                b.Property(e => e.CompanyName).HasMaxLength(MaxLength.C32).HasColumnNameSameAsProperty();
                b.Property(e => e.Affiliation).HasMaxLength(MaxLength.C32).HasColumnNameSameAsProperty();

                b.WithOwner(); //required to avoid navigation issues
            }
        );

        builder.Property(e => e.PictureUrl).HasMaxLength(MaxLength.C2048);

        builder.HasMany(p => p.UserRoles).WithOne().HasForeignKey(p => p.UserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.RefreshTokens).WithOne().HasForeignKey(p => p.UserId)
            .IsRequired().OnDelete(DeleteBehavior.Cascade);
    }
}
