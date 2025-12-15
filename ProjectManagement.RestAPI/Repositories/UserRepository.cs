using Microsoft.EntityFrameworkCore;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DataContext;
using ProjectManagement.RestAPI.Entities;

namespace ProjectManagement.RestAPI.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDBContext _context;

    public UserRepository(ApplicationDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }
}
