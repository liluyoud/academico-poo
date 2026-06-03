using Academico.Shared.Contexts;
using Academico.Shared.Entities;
using Academico.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Services;

public class DisciplinaService(AcademicoContext context) : IDisciplinaService
{
    private readonly AcademicoContext _context = context;

    public async Task<List<Disciplina>> GetAllAsync()
    {
        return await _context.Disciplinas
            .Include(d => d.Curso)
            .Include(d => d.Professor)
            .OrderBy(d => d.Nome)
            .ToListAsync();
    }

    public async Task<Disciplina?> GetByIdAsync(int id)
    {
        return await _context.Disciplinas
            .Include(d => d.Curso)
            .Include(d => d.Professor)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Disciplina> CreateAsync(Disciplina disciplina)
    {
        disciplina.Curso = null;
        disciplina.Professor = null;
        _context.Disciplinas.Add(disciplina);
        await _context.SaveChangesAsync();
        return disciplina;
    }

    public async Task<bool> UpdateAsync(int id, Disciplina disciplina)
    {
        var existing = await _context.Disciplinas.FindAsync(id);
        if (existing == null) return false;

        existing.Nome = disciplina.Nome;
        existing.IdCurso = disciplina.IdCurso;
        existing.IdProfessor = disciplina.IdProfessor;
        existing.CargaHoraria = disciplina.CargaHoraria;
        existing.SemestreOferta = disciplina.SemestreOferta;
        existing.Curso = null;
        existing.Professor = null;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var disciplina = await _context.Disciplinas.FindAsync(id);
        if (disciplina == null) return false;

        _context.Disciplinas.Remove(disciplina);
        await _context.SaveChangesAsync();
        return true;
    }
}
