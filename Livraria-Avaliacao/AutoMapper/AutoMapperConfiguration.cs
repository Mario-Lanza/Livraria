using AutoMapper;

namespace Livraria_Avaliacao.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper;
        public static void RegistrarMappings()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DomainMappingProfile>();
                cfg.AddProfile<DtoMappingProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
