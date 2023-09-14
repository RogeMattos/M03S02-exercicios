using System.ComponentModel.DataAnnotations;

namespace FichaCadastroApi.DTO.Telefone
{
    //[M3S02] Ex 02 - Crie uma Dto chamada Telefone
    public class TelefoneCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int FichaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public  int Ddd { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public bool Ativo { get; set; }
    }
}
