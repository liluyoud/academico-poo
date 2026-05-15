using Academico.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academico.Shared.Contexts;

public class AcademicoContext(DbContextOptions<AcademicoContext> options): DbContext(options)
{
    public DbSet<Curso> Cursos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
