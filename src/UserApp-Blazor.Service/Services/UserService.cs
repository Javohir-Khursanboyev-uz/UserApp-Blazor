using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Data.Repositories;

namespace UserApp_Blazor.Service.Services;

public class UserService (IUserRepository userRepository) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        return await userRepository.InsertAsync(user);
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        return await userRepository.UpdateAsync(id, user);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        return await userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userRepository.SelectAllAsync();
    }
}