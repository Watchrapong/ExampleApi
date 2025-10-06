using ExampleApi.Core.Entities;

namespace ExampleApi.Core;

public enum DeleteMode
{
    Soft,
    Hard
}

public interface IRepository<T> where T : class, IEntity
{
    IQueryable<T> Table { get; }
    IQueryable<T> TableTracking { get; }

    void Insert(T entity);

    /// <summary>
    /// ลบ entity ออกจากฐานข้อมูล ค่าเริ่มต้นคือ Soft Delete (Soft จำเป็นจะทำงานร่วมกับ <see cref="TableTracking"/> เท่านั้น)
    /// </summary>
    void Delete(T entity, DeleteMode deleteMode = DeleteMode.Soft);

    Task CommitAsync(CancellationToken cancellationToken = default);

    IQueryable<TEntity> GetTable<TEntity>() where TEntity : class, IEntity;
    IQueryable<TEntity> GetTableTracking<TEntity>() where TEntity : class, IEntity;
}
