using System.Net.Http.Json;
using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public class CursoHttpClient(HttpClient http) : ICursoService
{
    private readonly HttpClient _http = http;

    public async Task<List<Curso>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Curso>>("api/cursos") ?? [];
    }

    public async Task<Curso?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"api/cursos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Curso>();
        }
        return null;
    }

    public async Task<Curso> CreateAsync(Curso curso)
    {
        var response = await _http.PostAsJsonAsync("api/cursos", curso);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Curso>())!;
    }

    public async Task<bool> UpdateAsync(int id, Curso curso)
    {
        var response = await _http.PutAsJsonAsync($"api/cursos/{id}", curso);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/cursos/{id}");
        return response.IsSuccessStatusCode;
    }
}
