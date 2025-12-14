using Blocks.Domain.Entities;
using Blocks.EntityFramework;

namespace Submission.Persistence.Repositories;

public class Repository<TEntity>(SubmissionDbContext dbContext)  
		: Repository<SubmissionDbContext, TEntity>(dbContext)
		where TEntity : class, IEntity
{
}
