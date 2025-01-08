using UserApp_Blazor.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Data.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> InsertAsync(User user)
    {
        return (await context.Users.AddAsync(user)).Entity;
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await Task.FromResult(context.Set<User>().Update(user).Entity);
    }


    public async Task<IEnumerable<User>> SelectAllAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}