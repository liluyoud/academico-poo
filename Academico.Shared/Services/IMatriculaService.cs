using Academico.Shared.Entities;

namespace Academico.Shared.Services;

public interface IMatriculaService
{
    Task<List<Matricula>> GetAllAsync();
    Task<Matricula?> GetByIdAsync(int id);
    Task<Matricula> CreateAsync(Matricula matricula);
    Task<bool> UpdateAsync(int id, Matricula matricula);
    Task<bool> DeleteAsync(int id);
}
