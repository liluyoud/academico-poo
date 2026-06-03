using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public interface IProfessorService
{
    Task<List<Professor>> GetAllAsync();
    Task<Professor?> GetByIdAsync(int id);
    Task<Professor> CreateAsync(Professor professor);
    Task<bool> UpdateAsync(int id, Professor professor);
    Task<bool> DeleteAsync(int id);
}
