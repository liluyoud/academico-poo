using System.Net.Http.Json;
using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public class DisciplinaHttpClient(HttpClient http) : IDisciplinaService
{
    private readonly HttpClient _http = http;

    public async Task<List<Disciplina>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Disciplina>>("api/disciplinas") ?? [];
    }

    public async Task<Disciplina?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"api/disciplinas/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Disciplina>();
        }
        return null;
    }

    public async Task<Disciplina> CreateAsync(Disciplina disciplina)
    {
        var response = await _http.PostAsJsonAsync("api/disciplinas", disciplina);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Disciplina>())!;
    }

    public async Task<bool> UpdateAsync(int id, Disciplina disciplina)
    {
        var response = await _http.PutAsJsonAsync($"api/disciplinas/{id}", disciplina);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/disciplinas/{id}");
        return response.IsSuccessStatusCode;
    }
}
