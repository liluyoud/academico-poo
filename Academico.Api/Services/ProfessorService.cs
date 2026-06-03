using Academico.Shared.Contexts;
using Academico.Shared.Entities;
using Academico.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Services;

public class ProfessorService(AcademicoContext context) : IProfessorService
{
    private readonly AcademicoContext _context = context;

    public async Task<List<Professor>> GetAllAsync()
    {
        return await _context.Professores.OrderBy(p => p.Nome).ToListAsync();
    }

    public async Task<Professor?> GetByIdAsync(int id)
    {
        return await _context.Professores.FindAsync(id);
    }

    public async Task<Professor> CreateAsync(Professor professor)
    {
        _context.Professores.Add(professor);
        await _context.SaveChangesAsync();
        return professor;
    }

    public async Task<bool> UpdateAsync(int id, Professor professor)
    {
        var existing = await _context.Professores.FindAsync(id);
        if (existing == null) return false;

        existing.Nome = professor.Nome;
        existing.Email = professor.Email;
        existing.Titulacao = professor.Titulacao;
        existing.DataContratacao = professor.DataContratacao;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var professor = await _context.Professores.FindAsync(id);
        if (professor == null) return false;

        _context.Professores.Remove(professor);
        await _context.SaveChangesAsync();
        return true;
    }
}
