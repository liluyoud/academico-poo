using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public interface IAlunoService
{
    Task<List<Aluno>> GetAllAsync();
    Task<Aluno?> GetByIdAsync(int id);
    Task<Aluno> CreateAsync(Aluno aluno);
    Task<bool> UpdateAsync(int id, Aluno aluno);
    Task<bool> DeleteAsync(int id);
}
