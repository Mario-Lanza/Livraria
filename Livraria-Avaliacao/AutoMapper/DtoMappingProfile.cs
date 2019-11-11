using AutoMapper;
using Livraria.Domain.Entidades;
using Livraria_Avaliacao.Dto;

namespace Livraria_Avaliacao.AutoMapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<LivroDto, Livro>()
                .ForMember(dest => dest.QuantidadeMinimaCompra, opt => opt.MapFrom(src => src.QuantidadeMinima));
        }
    }
}
