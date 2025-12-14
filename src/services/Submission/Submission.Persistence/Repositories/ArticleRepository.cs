using Submission.Domain.Entities;

namespace Submission.Persistence.Repositories;

public class ArticleRepository(SubmissionDbContext dbContext)  
		: Repository<Article>(dbContext)
{
}
 