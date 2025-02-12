using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Service.Services;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<User>> GetAllAsync(string? search = null);
}