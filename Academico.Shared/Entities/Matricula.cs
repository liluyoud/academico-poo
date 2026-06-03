using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Shared.Entities;

[Table("matriculas")]
public class Matricula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_disciplina")]
    public int IdDisciplina { get; set; }

    [Column("id_aluno")]
    public int IdAluno { get; set; }

    [Column("data_matricula")]
    public DateTime DataMatricula { get; set; } = DateTime.Now;

    [Column("nota_final")]
    public decimal? NotaFinal { get; set; }

    [Column("status_matricula")]
    [StringLength(20)]
    public string StatusMatricula { get; set; } = "Cursando";

    [ForeignKey(nameof(IdDisciplina))]
    public Disciplina? Disciplina { get; set; }

    [ForeignKey(nameof(IdAluno))]
    public Aluno? Aluno { get; set; }
}
