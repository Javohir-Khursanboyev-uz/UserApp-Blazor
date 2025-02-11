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

        var apiResponse = await response.Content.ReadFromJsonAsync<Response>();
        if (apiResponse is not null && apiResponse.Data is not null)
        {
            var userJson = System.Text.Json.JsonSerializer.Serialize(apiResponse.Data);
            return System.Text.Json.JsonSerializer.Deserialize<User>(userJson)!;
        }

        throw new Exception("Failed to create user.");
    }

    public async Task<User> UpdateAsync(long id, User user)
    {
        var response = await httpClient.PutAsJsonAsync($"{baseUri}/{id}", user);
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<Response>();

        if (apiResponse is not null && apiResponse.Data is not null)
        {
            var userJson = System.Text.Json.JsonSerializer.Serialize(apiResponse.Data);
            return System.Text.Json.JsonSerializer.Deserialize<User>(userJson)!;
        }

        throw new Exception("Failed to update user.");
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var response = await httpClient.DeleteAsync($"{baseUri}/{id}");
        response.EnsureSuccessStatusCode();

        var apiResponse = await response.Content.ReadFromJsonAsync<Response>();

        return apiResponse is not null && apiResponse.StatusCode == 200;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {

        var response = await httpClient.GetFromJsonAsync<Response>(baseUri);
        if (response is not null)
        {
            var usersJson = System.Text.Json.JsonSerializer.Serialize(response.Data);
            return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<User>>(usersJson) ?? Enumerable.Empty<User>(); ;
        }

        return Enumerable.Empty<User>();
    }
}   