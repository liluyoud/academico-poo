using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public interface ICursoService
{
    Task<List<Curso>> GetAllAsync();
    Task<Curso?> GetByIdAsync(int id);
    Task<Curso> CreateAsync(Curso curso);
    Task<bool> UpdateAsync(int id, Curso curso);
    Task<bool> DeleteAsync(int id);
}
