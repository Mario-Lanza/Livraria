using AutoMapper;

namespace Livraria_Avaliacao.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper;
        private static MapperConfiguration config;
        public static void RegistrarMappings()
        {
            config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DomainToDtoMappingProfile>();
                cfg.AddProfile<DtoToDomainMappingProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
