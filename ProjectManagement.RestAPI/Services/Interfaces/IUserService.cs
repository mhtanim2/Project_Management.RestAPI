using ProjectManagement.RestAPI.DTOs;

namespace ProjectManagement.RestAPI.Services.Interfaces;

public interface IUserService
{
    Task<int> CreateAsync(UserCreateDto dto);
    Task UpdateAsync(int id, UserUpdateDto dto);
    Task<ICollection<UserReadDto>> GetAllAsync();
    Task<UserReadDto?> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
