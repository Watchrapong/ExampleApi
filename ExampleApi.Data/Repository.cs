using ExampleApi.Core;
using ExampleApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Data;

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly ExampleApiDbContext _context;

    public Repository(ExampleApiDbContext context)
    {
        context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _context = context;
    }

    public IQueryable<T> Table
    {
        get
        {
            if (typeof(ISoftDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                // Filter out deleted entities if T implements ISoftDeleteEntity
                return _context.Set<T>().Where(x => EF.Property<DateTime?>(x, "Deleted") == null);
            }
            else
            {
                return _context.Set<T>();
            }
        }
    }

    public IQueryable<T> TableTracking => Table.AsTracking();

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Delete(T entity, DeleteMode deleteMode = DeleteMode.Soft)
    {
        if (deleteMode == DeleteMode.Soft && entity is ISoftDeleteEntity softDeleteEntity)
        {
            var isTracked = _context.ChangeTracker.Entries<T>().Any(e => e.Entity == entity);
            if (!isTracked)
            {
                throw new InvalidOperationException("Entity must be tracked to perform soft delete. Use TableTracking to query the entity.");
            }

            softDeleteEntity.Deleted = DateTime.UtcNow;
            return;
        }

        _context.Remove(entity);
    }

    public void Insert(T entity)
    {
        _context.Add(entity);
    }

    public IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, IEntity
    {
        return _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetTableTracking<TEntity>() where TEntity : class, IEntity
    {
        return _context.Set<TEntity>().AsTracking();
    }
}
