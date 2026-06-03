using Academico.Shared.Contexts;
using Academico.Shared.Entities;
using Academico.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Services;

public class MatriculaService(AcademicoContext context) : IMatriculaService
{
    private readonly AcademicoContext _context = context;

    public async Task<List<Matricula>> GetAllAsync()
    {
        return await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Disciplina)
                .ThenInclude(d => d!.Curso)
            .OrderByDescending(m => m.DataMatricula)
            .ToListAsync();
    }

    public async Task<Matricula?> GetByIdAsync(int id)
    {
        return await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Disciplina)
                .ThenInclude(d => d!.Curso)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Matricula> CreateAsync(Matricula matricula)
    {
        matricula.Aluno = null;
        matricula.Disciplina = null;
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();
        return matricula;
    }

    public async Task<bool> UpdateAsync(int id, Matricula matricula)
    {
        var existing = await _context.Matriculas.FindAsync(id);
        if (existing == null) return false;

        existing.IdAluno = matricula.IdAluno;
        existing.IdDisciplina = matricula.IdDisciplina;
        existing.NotaFinal = matricula.NotaFinal;
        existing.StatusMatricula = matricula.StatusMatricula;
        existing.DataMatricula = matricula.DataMatricula;
        existing.Aluno = null;
        existing.Disciplina = null;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var matricula = await _context.Matriculas.FindAsync(id);
        if (matricula == null) return false;

        _context.Matriculas.Remove(matricula);
        await _context.SaveChangesAsync();
        return true;
    }
}
