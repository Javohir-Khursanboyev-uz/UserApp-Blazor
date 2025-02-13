using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Data.Repositories;
using UserApp_Blazor.Shared.Exceptions;
using UserApp_Blazor.Service.Configurations;
using UserApp_Blazor.Service.Extensions;

namespace UserApp_Blazor.Service.Services;

public class UserService (IUserRepository userRepository) : IUserService
{
    public async Task<User> CreateAsync(User user)
    {
        var existUser = (await userRepository.SelectAllAsync()).FirstOrDefault(u => u.Email == user.Email);

        if (existUser is not null)
            throw new AlreadyExistException($"User already exist with this Email {user.Email}");

        return await userRepository.InsertAsync(user);
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        return await userRepository.UpdateAsync(id, user);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = (await userRepository.SelectAllAsync()).FirstOrDefault(u => u.Id == id)
            ?? throw new NotFoundException($"User is not found");

        return await userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync(PaginationParams @params, string search = null)
    {
        var users = await userRepository.SelectAllAsync();
        if (!string.IsNullOrEmpty(search))
            users = users.Where(u =>u.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || 
            u.Email.Contains(search, StringComparison.OrdinalIgnoreCase));
        
        return users.ToPaginateAsEnumerable(@params);
    }
}