using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Shared.Entities;

[Table("disciplinas")]
public class Disciplina
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_curso")]
    public int IdCurso { get; set; }

    [Column("id_professor")]
    public int IdProfessor { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public required string Nome { get; set; }

    [Column("carga_horaria")]
    public int CargaHoraria { get; set; }

    [Column("semestre_oferta")]
    public int SemestreOferta { get; set; }

    [ForeignKey(nameof(IdCurso))]
    public Curso? Curso { get; set; }

    [ForeignKey(nameof(IdProfessor))]
    public Professor? Professor { get; set; }
}
