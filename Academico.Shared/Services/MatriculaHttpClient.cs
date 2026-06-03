using System.Net.Http.Json;
using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public class MatriculaHttpClient(HttpClient http) : IMatriculaService
{
    private readonly HttpClient _http = http;

    public async Task<List<Matricula>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Matricula>>("api/matriculas") ?? [];
    }

    public async Task<Matricula?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"api/matriculas/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Matricula>();
        }
        return null;
    }

    public async Task<Matricula> CreateAsync(Matricula matricula)
    {
        var response = await _http.PostAsJsonAsync("api/matriculas", matricula);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Matricula>())!;
    }

    public async Task<bool> UpdateAsync(int id, Matricula matricula)
    {
        var response = await _http.PutAsJsonAsync($"api/matriculas/{id}", matricula);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/matriculas/{id}");
        return response.IsSuccessStatusCode;
    }
}
