using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Service.Configurations;

namespace UserApp_Blazor.Service.Services;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<(IEnumerable<User>, PaginationMetaData)> GetAllAsync(PaginationParams @params, string search = null);
}