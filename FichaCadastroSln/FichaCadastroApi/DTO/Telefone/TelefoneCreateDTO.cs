﻿using System.ComponentModel.DataAnnotations;

namespace FichaCadastroApi.DTO.Telefone
{
    //[M3S02] Ex 02 - Crie uma Dto chamada Telefone
    public class TelefoneCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(3, ErrorMessage = "Este campo aceita até 3 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo aceita até 3 caracteres")]
        public int Ddd { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(9, ErrorMessage = "Este campo aceita até 9 caracteres")]
        [MinLength(9, ErrorMessage = "Este campo aceita até 9 caracteres")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public bool Ativo { get; set; }
    }
}
