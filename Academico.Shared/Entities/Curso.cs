using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Shared.Entities;

[Table("cursos")]
public class Curso
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public required string Nome { get; set; }

    [Column("sigla")]
    [StringLength(10)]
    public required string Sigla { get; set; }

    [Column("carga_horaria_total")]
    public int CargaHoraria { get; set; }

    [Column("id_coordenador")]
    public int IdCoordenador { get; set; }

    [ForeignKey(nameof(IdCoordenador))]
    public Professor? Coordenador { get; set; }
}