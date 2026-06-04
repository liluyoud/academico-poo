namespace Academico.Shared.Services;

public interface IEntityService<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(int id, T entity);
    Task<bool> DeleteAsync(int id);
}
