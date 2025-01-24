using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Web.Service.Services;

public class UserService : IUserService
{
    public Task<User> CreateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(long id, User user)
    {
        throw new NotImplementedException();
    }
}