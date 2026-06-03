using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Shared.Entities;

[Table("alunos")]
public class Aluno
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_curso")]
    public int IdCurso { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public required string Nome { get; set; }

    [Column("cpf")]
    [StringLength(14)]
    public required string Cpf { get; set; }

    [Column("email")]
    [StringLength(100)]
    public required string Email { get; set; }

    [Column("data_nascimento")]
    public DateOnly DataNascimento { get; set; }

    [Column("status_aluno")]
    [StringLength(20)]
    public string StatusAluno { get; set; } = "Ativo";

    [ForeignKey(nameof(IdCurso))]
    public Curso? Curso { get; set; }
}
