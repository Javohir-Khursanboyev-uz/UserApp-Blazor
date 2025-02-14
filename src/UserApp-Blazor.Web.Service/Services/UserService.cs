using System.Net.Http.Json;
using System.Text.Json;
using UserApp_Blazor.Domain.Entities;
using UserApp_Blazor.Shared.Configurations;
using UserApp_Blazor.Shared.Models;

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
        var apiResponse = await response.Content.ReadFromJsonAsync<Response>();

        if (!response.IsSuccessStatusCode || apiResponse is null)
            throw new Exception(apiResponse?.Message ?? "Failed to fetch users.");

        var userJson = System.Text.Json.JsonSerializer.Serialize(apiResponse.Data);
        return System.Text.Json.JsonSerializer.Deserialize<User>(userJson)!;
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

        throw new Exception(apiResponse?.Message);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var response = await httpClient.DeleteAsync($"{baseUri}/{id}");
        var apiResponse = await response.Content.ReadFromJsonAsync<Response>();

        if (!response.IsSuccessStatusCode || apiResponse is null)
            throw new Exception(apiResponse?.Message ?? "Failed to fetch users.");

        return apiResponse is not null && apiResponse.StatusCode == 200;
    }

    public async Task<PaginatedResponse<User>> GetAllAsync(PaginationParams @params, string? search = null)
    {
        var uri = $"{baseUri}?search={Uri.EscapeDataString(search ?? "")}&pageIndex={@params.PageIndex}&pageSize={@params.PageSize}";
        var response = await httpClient.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
            return new PaginatedResponse<User>();

        // X-Pagination headerni olish
        PaginationMetaData pagination = null;

        if (response.Headers.TryGetValues("X-Pagination", out var values))
        {
            var paginationJson = values.FirstOrDefault();
            if (!string.IsNullOrEmpty(paginationJson))
            {
                pagination = JsonSerializer.Deserialize<PaginationMetaData>(paginationJson);
            }
        }

        // JSON javobni Response obyektiga deserialize qilish
        var apiResponse = await httpClient.GetFromJsonAsync<Response>(uri);
        if (apiResponse is not null)
        {
            var usersJson = JsonSerializer.Serialize(apiResponse.Data);
            var users = JsonSerializer.Deserialize<IEnumerable<User>>(usersJson) ?? Enumerable.Empty<User>();

            return new PaginatedResponse<User> { Data = users, Pagination = pagination };
        }

        return new PaginatedResponse<User>();
    }
}