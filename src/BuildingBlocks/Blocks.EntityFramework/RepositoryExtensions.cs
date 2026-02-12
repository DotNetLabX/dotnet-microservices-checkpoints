using Blocks.Domain.Entities;
using Blocks.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Blocks.EntityFrameworkCore;

public static class RepositoryExtensions
{
	public static async Task<TEntity> FindByIdOrThrowAsync<TEntity, TContext>(this Repository<TContext, TEntity> repository, int id)
		where TContext : DbContext
		where TEntity : class, IEntity
	{ 
		var entity = await repository.FindByIdAsync(id);
		if(entity is null)
			throw new NotFoundException($"{typeof(TEntity).Name} not found");

		return entity;
	}

    public static async Task<TEntity> FindByIdOrThrowAsync<TEntity>(this DbSet<TEntity> dbSet, int id)
        where TEntity : class, IEntity
    {
        var entity = await dbSet.FindAsync(id);
        if (entity is null)
            throw new NotFoundException($"{typeof(TEntity).Name} not found");

        return entity;
    }

    public static async Task<TEntity> GetByIdOrThrowAsync<TEntity, TContext>(this Repository<TContext, TEntity> repository, int id, CancellationToken ct = default)
		where TContext : DbContext
		where TEntity : class, IEntity
	{
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException($"{typeof(TEntity).Name} not found");

        return entity;
    }
}
