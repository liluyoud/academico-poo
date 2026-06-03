using System.Net.Http.Json;
using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public class ProfessorHttpClient(HttpClient http) : IProfessorService
{
    private readonly HttpClient _http = http;

    public async Task<List<Professor>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Professor>>("api/professores") ?? [];
    }

    public async Task<Professor?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"api/professores/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Professor>();
        }
        return null;
    }

    public async Task<Professor> CreateAsync(Professor professor)
    {
        var response = await _http.PostAsJsonAsync("api/professores", professor);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Professor>())!;
    }

    public async Task<bool> UpdateAsync(int id, Professor professor)
    {
        var response = await _http.PutAsJsonAsync($"api/professores/{id}", professor);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/professores/{id}");
        return response.IsSuccessStatusCode;
    }
}
