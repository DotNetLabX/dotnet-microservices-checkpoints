using Blocks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Blocks.EntityFrameworkCore;

public interface IRepository<TEntity>
		where TEntity : class, IEntity
{
		Task<TEntity?> FindByIdAsync(int id);
		Task<TEntity?> GetByIdAsync(int id);
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Remove(TEntity entity);
		Task<bool> DeleteByIdAsync(int id);
}
public class Repository<TContext, TEntity> : IRepository<TEntity>
		where TContext : DbContext
		where TEntity : class, IEntity
{
		protected readonly TContext _dbContext;
		protected DbSet<TEntity> _entity;

		public Repository(TContext context)
		{
				_dbContext = context;
				_entity = _dbContext.Set<TEntity>();
		}

		public TContext Context => _dbContext;
		public virtual DbSet<TEntity> Entity => _entity;

		protected virtual IQueryable<TEntity> Query() => _entity.AsQueryable();

		public async Task<TEntity?> FindByIdAsync(int id) => await _entity.FindAsync(id);
		public async Task<TEntity?> GetByIdAsync(int id) => await Query().FirstOrDefaultAsync(e => e.Id == id);

		public async Task<TEntity> AddAsync(TEntity entity) => (await _entity.AddAsync(entity)).Entity;

		public void Update(TEntity entity) => _entity.Update(entity);
		public void Remove(TEntity entity) =>  _entity.Remove(entity);
		public virtual async Task<bool> DeleteByIdAsync(int id)
		{
				var rows = await _dbContext.Database.ExecuteSqlInterpolatedAsync(
												$"DELETE FROM {TableName} WHERE Id = {id}");
				return rows > 0;
		}

		public string TableName => _dbContext.Model.FindEntityType(typeof(TEntity))?.GetTableName()!;

		public virtual Task<int> SaveChangesAsync(CancellationToken ct = default)
				=> _dbContext.SaveChangesAsync(ct);

		Task IRepository<TEntity>.AddAsync(TEntity entity)
		{
				return AddAsync(entity);
		}
}
