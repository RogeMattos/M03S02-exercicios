using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace FichaCadastroApi.Model
{
    [Table("Detalhe")]
    public class DetalheModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName ="VARCHAR"), Required, StringLength(500)]
        public string? Feeedback { get; set; }

        [Required]
        public int Nota { get; set; }

        [Required]
        public bool Ativado { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required]
        public virtual FichaModel Ficha { get; set; }

    }
}
