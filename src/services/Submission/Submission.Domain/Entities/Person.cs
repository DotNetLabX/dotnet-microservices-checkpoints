using Blocks.Domain.Entities;
using Submission.Domain.ValueObjects;

namespace Submission.Domain.Entities;

public class Person : IEntity
{
		public int Id { get; init; }

		public required string FirstName { get; init; }
		public required string LastName { get; init; }

		public string FullName => FirstName + " " + LastName;

		public string? Title { get; init; }
		public required EmailAddress EmailAddress { get; init; }
		public required string Affiliation { get; init; }
		 
		public int? UserId { get; set; }

		public IReadOnlyCollection<ArticleActor> ArticleActors { get; private set; } = new List<ArticleActor>();


		public string TypeDiscriminator { get; init; } = null!; // EF discriminator
}
