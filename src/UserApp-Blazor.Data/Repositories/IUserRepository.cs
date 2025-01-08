using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Data.Repositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(long id, User user);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<User>> SelectAllAsync();
}