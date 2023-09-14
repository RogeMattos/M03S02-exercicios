using System;
using System.ComponentModel.DataAnnotations;

namespace FichaCadastroApi.DTO.Telefone
{
    public class TelefoneUpDateDTO
    {
        //[M3S02] Ex 02 - Crie uma Dto chamada Telefone
        //[M3S02] Ex 05 - Criar a validação na DTO Telefone
        
        public int Ddd { get; set; }
        
        public int Numero { get; set; }

        
        public bool Ativo { get; set; }
    }
}
