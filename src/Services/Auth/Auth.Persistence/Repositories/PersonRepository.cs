using Auth.Domain.Persons;
using Blocks.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Persistence.Repositories;

public class PersonRepository(AuthDbContext context) 
    : Repository<AuthDbContext, Person>(context)
{
    public async Task<Person?> GetByUserIdAsync(int userId, CancellationToken ct = default)
        => await Query()
        .SingleOrDefaultAsync(p => p.UserId == userId, ct);

    public async Task<Person?> GetByEmailAsync(string email, CancellationToken ct = default)
        => await Query()
        .SingleOrDefaultAsync(p => p.Email.NormalizedEmail == email.ToUpperInvariant(), ct);


    protected override IQueryable<Person> Query()
        => base.Query().Include(a => a.User);
}
