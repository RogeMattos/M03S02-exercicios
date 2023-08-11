using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using FichaCadastroApi.Base;

namespace FichaCadastroApi.Model
{
    [Table("Detalhe")]
    public class DetalheModel : RelacionalBase   
    {
       

        [Column(TypeName ="VARCHAR"), Required, StringLength(500)]
        public string? Feeedback { get; set; }

        [Required]
        public int Nota { get; set; }

        [Required]
        public bool Ativado { get; set; }

      
        [Required]
        public virtual FichaModel Ficha { get; set; }

    }
}
