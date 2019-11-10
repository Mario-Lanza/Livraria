using AutoMapper;
using Livraria.Domain.Entidades;
using Livraria_Avaliacao.Dto;

namespace Livraria_Avaliacao.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Livro, LivroDto>()
                .ForMember(dest => dest.QuantidadeMinima, opt => opt.MapFrom(src => src.QuantidadeMinimaCompra));
        }
    }
}
