using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public interface IDisciplinaService
{
    Task<List<Disciplina>> GetAllAsync();
    Task<Disciplina?> GetByIdAsync(int id);
    Task<Disciplina> CreateAsync(Disciplina disciplina);
    Task<bool> UpdateAsync(int id, Disciplina disciplina);
    Task<bool> DeleteAsync(int id);
}
