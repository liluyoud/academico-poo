using System.Net.Http.Json;
using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public class AlunoHttpClient(HttpClient http) : IAlunoService
{
    private readonly HttpClient _http = http;

    public async Task<List<Aluno>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Aluno>>("api/alunos") ?? [];
    }

    public async Task<Aluno?> GetByIdAsync(int id)
    {
        var response = await _http.GetAsync($"api/alunos/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Aluno>();
        }
        return null;
    }

    public async Task<Aluno> CreateAsync(Aluno aluno)
    {
        var response = await _http.PostAsJsonAsync("api/alunos", aluno);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Aluno>())!;
    }

    public async Task<bool> UpdateAsync(int id, Aluno aluno)
    {
        var response = await _http.PutAsJsonAsync($"api/alunos/{id}", aluno);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/alunos/{id}");
        return response.IsSuccessStatusCode;
    }
}
