using System.Net.Http.Json;
using UserApp_Blazor.Domain.Entities;

namespace UserApp_Blazor.Web.Service.Services;

public class UserService : IUserService
{
    private readonly HttpClient httpClient;
    private const string baseUri = "/api/Users";

    public UserService(IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<User> CreateAsync(User user)
    {
        var response = await httpClient.PostAsJsonAsync(baseUri, user);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<User>())!;
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        var updateUri = $"{baseUri}/{id}";
        var response = await httpClient.PutAsJsonAsync(updateUri, user);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<User>())!;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var deleteUri = $"{baseUri}/{id}";
        var response = await httpClient.DeleteAsync(deleteUri);
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<User>>(baseUri) ?? Array.Empty<User>();
    }
}   