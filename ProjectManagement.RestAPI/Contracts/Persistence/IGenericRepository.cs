
using ProjectManagement.RestAPI.Entities;
using ProjectManagement.RestAPI.Entities.Common;

namespace ProjectManagement.RestAPI.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
