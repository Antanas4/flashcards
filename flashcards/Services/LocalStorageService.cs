using Blazored.LocalStorage;
using System.Threading.Tasks;

public class LocalStorageService
{
    private readonly ILocalStorageService _localStorage;
    public LocalStorageService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SetTokenAsync(string key, string token)
    {
        if (!string.IsNullOrWhiteSpace(token))
        {
            await _localStorage.SetItemAsync(key, token);
        }
    }

    public async Task<string?> GetTokenAsync(string key)
    {
        return await _localStorage.GetItemAsync<string>(key);
    }
}
