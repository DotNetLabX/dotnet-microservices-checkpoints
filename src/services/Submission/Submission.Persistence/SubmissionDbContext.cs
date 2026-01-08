using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;

namespace Submission.Persistence;

public class SubmissionDbContext(DbContextOptions<SubmissionDbContext> options) : DbContext(options)
{
    #region Entities
    public virtual DbSet<Journal> Journals { get; set; }
    public virtual DbSet<Article> Articles { get; set; }
	public DbSet<Person> Persons { get; set; }
	public DbSet<Author> Authors { get; set; }
	public DbSet<ArticleActor> ArticleActors { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }
    public virtual DbSet<AssetTypeDefinition> AssetTypes{ get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
