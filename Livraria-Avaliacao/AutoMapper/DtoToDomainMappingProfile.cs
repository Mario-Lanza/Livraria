using AutoMapper;
using Livraria.Domain.Entidades;
using Livraria_Avaliacao.Dto;

namespace Livraria_Avaliacao.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<LivroDto, Livro>();
        }
    }
}
