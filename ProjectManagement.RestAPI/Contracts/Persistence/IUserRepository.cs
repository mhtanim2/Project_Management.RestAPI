using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}
