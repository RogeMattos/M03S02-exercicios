using FichaCadastroApi.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroApi.Model
{
    // [M3S02] Ex 01 - Crie uma Model chamada Telefone
    //Criar modelo chamada TelefoneModel.cs
     // Propriedade Id
     // Propriedade Ddd
     // Propriedade Numero
     // Propriedade Ativo
     //Telefone será vinculado com a FichaModel.cs, olhar a propriedade Detalhe e deixar Identico

    [Table("Telefone")]
    public class TelefoneModel : RelacionalBase
    {
        [Required]
        public int Ddd { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required]
        public virtual FichaModel? Ficha { get; set; }


    }
}
