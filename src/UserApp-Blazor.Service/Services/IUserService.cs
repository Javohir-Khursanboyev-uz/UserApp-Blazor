using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Shared.Configurations;

namespace UserApp_Blazor.Service.Services;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<User>> GetAllAsync(PaginationParams @params, string search = null);
}