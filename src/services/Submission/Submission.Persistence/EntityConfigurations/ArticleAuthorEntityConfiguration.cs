using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;
using Blocks.EntityFramework;

public class ArticleAuthorEntityConfiguration : IEntityTypeConfiguration<ArticleAuthor>
{
		public void Configure(EntityTypeBuilder<ArticleAuthor> builder)
		{
				builder.Property(e => e.ContributionAreas).HasJsonCollectionConversion().IsRequired();
		}
}
