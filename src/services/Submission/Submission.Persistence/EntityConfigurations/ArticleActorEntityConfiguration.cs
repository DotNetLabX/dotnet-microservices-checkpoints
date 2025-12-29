using Articles.Abstractions.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using Blocks.EntityFramework;

namespace Submission.Persistence.EntityConfigurations;

internal class ArticleActorEntityConfiguration : IEntityTypeConfiguration<ArticleActor>
{
		public void Configure(EntityTypeBuilder<ArticleActor> builder)
		{
				builder.HasKey(e => new { e.ArticleId, e.PersonId, e.Role });

				builder.HasDiscriminator(e => e.TypeDiscriminator)
						.HasValue<ArticleActor>(nameof(ArticleActor))
						.HasValue<ArticleAuthor>(nameof(ArticleAuthor));

				builder.Property(e => e.Role).HasEnumConversion().HasDefaultValue(UserRoleType.AUT);

				builder.HasOne(aa => aa.Article)
						.WithMany(a => a.Actors)
						.HasForeignKey(aa => aa.ArticleId)
						.OnDelete(DeleteBehavior.Cascade);

				builder.HasOne(aa => aa.Person)
						.WithMany(a => a.ArticleActors)
						.HasForeignKey(aa => aa.PersonId)
						.OnDelete(DeleteBehavior.Restrict);
		}
}
