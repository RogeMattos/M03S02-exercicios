﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FichaCadastroApi.Base;

namespace FichaCadastroApi.Model

{
    [Table("Ficha")]
    public class FichaModel : RelacionalBase

    {
       
    
        [Column(TypeName = "VARCHAR"), Required, StringLength(250)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public virtual IList<DetalheModel>? Detalhes { get; set;}

        public virtual IList<TelefoneModel>? Telefones { get; set; }









    }

}
