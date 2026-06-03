using Academico.Shared.Contexts;
using Academico.Shared.Entities;
using Academico.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Services;

public class AlunoService(AcademicoContext context) : IAlunoService
{
    private readonly AcademicoContext _context = context;

    public async Task<List<Aluno>> GetAllAsync()
    {
        return await _context.Alunos
            .Include(a => a.Curso)
            .OrderBy(a => a.Nome)
            .ToListAsync();
    }

    public async Task<Aluno?> GetByIdAsync(int id)
    {
        return await _context.Alunos
            .Include(a => a.Curso)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Aluno> CreateAsync(Aluno aluno)
    {
        aluno.Curso = null;
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
        return aluno;
    }

    public async Task<bool> UpdateAsync(int id, Aluno aluno)
    {
        var existing = await _context.Alunos.FindAsync(id);
        if (existing == null) return false;

        existing.Nome = aluno.Nome;
        existing.Cpf = aluno.Cpf;
        existing.Email = aluno.Email;
        existing.DataNascimento = aluno.DataNascimento;
        existing.IdCurso = aluno.IdCurso;
        existing.StatusAluno = aluno.StatusAluno;
        existing.Curso = null;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null) return false;

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
        return true;
    }
}
