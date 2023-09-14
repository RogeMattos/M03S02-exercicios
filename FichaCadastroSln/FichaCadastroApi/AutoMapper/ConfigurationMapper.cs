using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.DTO.Telefone;
using FichaCadastroApi.Model;

namespace FichaCadastroApi.AutoMapper
{
    public class ConfigurationMapper : Profile
    {
        public ConfigurationMapper()
        {
            CreateMap<FichaModel, FichaReadDTO>()
                 .ForMember(dest => dest.FichaComDetalhes, opt => opt.MapFrom(src => src.Detalhes));

             CreateMap<FichaCreateDTO, FichaModel>()
               .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailInformado.ToLower()))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataDeNascimento));

            //Configuração da maper para a tabela telefone
            CreateMap<FichaModel, TelefoneModel>()
                .ForMember(dest => dest.Ficha, opt => opt.MapFrom(src => src.Telefones));

            CreateMap<TelefoneCreateDTO, TelefoneModel>()
              .ForMember(dest => dest.Ddd, opt => opt.MapFrom(src => src.Ddd))
               .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
               .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo));

            // [M3S02] Ex 02 - Configurar o Automapper para concatenar o DDD + Telefone
            CreateMap<TelefoneModel, TelefoneReadDTO>()
            .ForMember(dest => dest.Contato, opt => opt.MapFrom(src => $"{src.Ddd} {src.Numero}"));

            CreateMap<FichaUpDateDTO, FichaModel>();

            CreateMap<DetalheModel, FichaDetalheReadDTO>();

            CreateMap<TelefoneUpDateDTO, TelefoneModel>();

            


        }
    }
}
