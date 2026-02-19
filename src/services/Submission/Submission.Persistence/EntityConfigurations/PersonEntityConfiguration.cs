using Blocks.EntityFrameworkCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Submission.Domain.Entities;

namespace Submission.Persistence.EntityConfigurations;

internal class PersonEntityConfiguration : EntityConfiguration<Person>
{
		public override void Configure(EntityTypeBuilder<Person> builder)
		{
				base.Configure(builder);

				builder.HasIndex(x => x.UserId).IsUnique();

				builder.HasDiscriminator<string>(e => e.TypeDiscriminator)
						.HasValue<Person>(nameof(Person))
						.HasValue<Author>(nameof(Author)); 

				builder.Property(e => e.FirstName).IsRequired().HasMaxLength(64);
				builder.Property(e => e.LastName).IsRequired().HasMaxLength(64);
				builder.Property(e => e.Title).HasMaxLength(64);
				builder.Property(e => e.Affiliation).IsRequired().HasMaxLength(512)
						.HasComment("Institution or organization they are associated with when they conduct their research.");

				builder.ComplexProperty(
					 o => o.Email, builder =>
					 {
							 builder.Property(n => n.Value)
									 .HasColumnName(builder.Metadata.PropertyInfo!.Name)
									 .HasMaxLength(64);
					 });
		}
}
