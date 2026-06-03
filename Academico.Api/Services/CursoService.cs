using Academico.Shared.Contexts;
using Academico.Shared.Entities;
using Academico.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Academico.Api.Services;

public class CursoService(AcademicoContext context) : ICursoService
{
    private readonly AcademicoContext _context = context;

    public async Task<List<Curso>> GetAllAsync()
    {
        return await _context.Cursos.Include(c => c.Coordenador).OrderBy(c => c.Nome).ToListAsync();
    }

    public async Task<Curso?> GetByIdAsync(int id)
    {
        return await _context.Cursos.Include(c => c.Coordenador).FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Curso> CreateAsync(Curso curso)
    {
        // Certificar que a navegação está nula para evitar duplicar/atualizar professor coordenador
        curso.Coordenador = null;
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
        return curso;
    }

    public async Task<bool> UpdateAsync(int id, Curso curso)
    {
        var existing = await _context.Cursos.FindAsync(id);
        if (existing == null) return false;

        existing.Nome = curso.Nome;
        existing.Sigla = curso.Sigla;
        existing.CargaHoraria = curso.CargaHoraria;
        existing.IdCoordenador = curso.IdCoordenador;
        existing.Coordenador = null;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var curso = await _context.Cursos.FindAsync(id);
        if (curso == null) return false;

        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();
        return true;
    }
}
