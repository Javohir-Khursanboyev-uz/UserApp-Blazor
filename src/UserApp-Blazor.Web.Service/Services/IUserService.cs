using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Shared.Models;

namespace UserApp_Blazor.Web.Service.Services;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<PaginatedResponse<User>> GetAllAsync(string? search = null);
}