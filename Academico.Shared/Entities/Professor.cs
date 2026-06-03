using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academico.Shared.Entities;

[Table("professores")]
public class Professor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(100)]
    public required string Nome { get; set; }

    [Column("email")]
    [StringLength(100)]
    public required string Email { get; set; }

    [Column("titulacao")]
    [StringLength(50)]
    public required string Titulacao { get; set; }

    [Column("data_contratacao")]
    public DateOnly DataContratacao { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
