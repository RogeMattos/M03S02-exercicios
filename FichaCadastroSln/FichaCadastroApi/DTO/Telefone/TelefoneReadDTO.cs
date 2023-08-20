using FichaCadastroApi.Base;
using System.ComponentModel.DataAnnotations;

namespace FichaCadastroApi.DTO.Telefone
{
    //[M3S02] Ex 02 - Crie uma Dto chamada Telefone
    public class TelefoneReadDTO : DTOBase
    {
        // [M3S02] Ex 02 - Criar a propriedade que devolve a lista de telefone
        public string Contato { get; set; }
 
        public bool Ativo { get; set; }

    }
}
