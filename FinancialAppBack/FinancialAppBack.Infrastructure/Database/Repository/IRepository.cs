namespace FinancialAppBack.Infrastructure.Database.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query { get; }
    Task AddAsync(T entity, bool autoSave = false);
    Task UpdateAsync(T entity, bool autoSave = false);
    Task DeleteAsync(T entity, bool autoSave = false);
    Task SaveChangesAsync();
}