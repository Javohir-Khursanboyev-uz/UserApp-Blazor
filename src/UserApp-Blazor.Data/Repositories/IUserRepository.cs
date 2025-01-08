using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Data.Repositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<IEnumerable<User>> SelectAllAsync();
    Task<bool> SaveAsync();
}