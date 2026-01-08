using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;
using Blocks.EntityFramework;
using Blocks.EntityFramework.EntityConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Submission.Persistence.EntityConfigurations;

internal class ArticleEntityConfiguration : EntityConfiguration<Article>
{
    public override void Configure(EntityTypeBuilder<Article> builder)
    {
        base.Configure(builder);

		builder.Property(e => e.Title).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Scope).HasMaxLength(2048).IsRequired();

        builder.Property(e => e.Stage).HasEnumConversion().IsRequired();
        builder.Property(e => e.Type).HasEnumConversion().IsRequired();

        builder.HasOne(e => e.Journal).WithMany(e => e.Articles)
            .HasForeignKey(e => e.JournalId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Assets).WithOne(e => e.Article)
            .HasForeignKey(e => e.ArticleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
