using Microsoft.EntityFrameworkCore;
using Submission.Domain.Entities;

namespace Submission.Persistence;

public class SubmissionDbContext : DbContext
{
    #region Entities
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
    #endregion


}
