using Academico.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academico.Shared.Contexts;

public class AcademicoContext(DbContextOptions<AcademicoContext> options): DbContext(options)
{
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Disciplina> Disciplinas { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Matricula> Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
