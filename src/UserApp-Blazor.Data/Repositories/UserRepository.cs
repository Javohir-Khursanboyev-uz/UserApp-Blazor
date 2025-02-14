using Microsoft.EntityFrameworkCore;
using UserApp_Blazor.Data.Contexts;
using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Data.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> InsertAsync(User user)
    {
        var createdUser = (await context.Users.AddAsync(user)).Entity;
        await context.SaveChangesAsync();
        return createdUser;
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        user.Id = id;
        var updatedUser = context.Users.Update(user).Entity;
        await context.SaveChangesAsync();
        return updatedUser;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await context.Users.Where(u => u.Id == id).FirstAsync();
        context.Users.Remove(existUser);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<User>> SelectAllAsync()
    {
        return await context.Users.ToListAsync();
    }
}