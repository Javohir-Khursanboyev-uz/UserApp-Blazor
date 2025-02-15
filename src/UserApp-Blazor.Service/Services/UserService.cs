using UserApp_Blazor.Data.Repositories;
using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Service.Extensions;
using UserApp_Blazor.Shared.Configurations;
using UserApp_Blazor.Shared.Exceptions;

namespace UserApp_Blazor.Service.Services;

public class UserService(IUserRepository userRepository) : IUserService
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
        var existUser = (await userRepository.SelectAllAsync()).FirstOrDefault(u => u.Id == id)
            ?? throw new NotFoundException($"User is not found");

        var alreadyExistUser = (await userRepository.SelectAllAsync()).FirstOrDefault(u => u.Email == user.Email && u.Id != id);
        if (alreadyExistUser is not null)
            throw new AlreadyExistException($"User already exist with this Email {user.Email}");

        existUser.Id = id;
        existUser.Name = user.Name;
        existUser.Email = user.Email;
        existUser.About = user.About;
        return await userRepository.UpdateAsync(id, existUser);
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
            users = users.Where(u => u.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            u.Email.Contains(search, StringComparison.OrdinalIgnoreCase));

        return users.ToPaginateAsEnumerable(@params);
    }
}