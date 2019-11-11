using AutoMapper;
using Livraria.Domain.Entidades;
using Livraria_Avaliacao.Dto;

namespace Livraria_Avaliacao.AutoMapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Livro, LivroDto>()
                .ForMember(dest => dest.QuantidadeMinima, opt => opt.MapFrom(src => src.QuantidadeMinimaCompra));
        }
    }
}
