using AutoMapper;
using FluentAssertions;
using Livraria.Domain.Entidades;
using Livraria.Tests.Fakes;
using Livraria_Avaliacao.AutoMapper;
using NUnit.Framework;

namespace Livraria.Tests.WebUI.AutoMapper
{
    [TestFixture]
    public class DtoMappingProfileTests
    {
        private const string NOME_LIVRO = "Livro";
        private const int QUANTIDADE_LIVRO = 5;
        public static IMapper Mapper;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DtoMappingProfile>();
            });

            Mapper = config.CreateMapper();
        }

        [Test]
        public void Deve_mapear_corretamente_todos_os_dados_de_livro()
        {
            var expected = new LivroBuilder(NOME_LIVRO, QUANTIDADE_LIVRO).LivroPadrao().Build();
            var livroDto = new LivroDtoBuilder(NOME_LIVRO, QUANTIDADE_LIVRO).LivroPadrao().Build();

            var result = Mapper.Map<Livro>(livroDto);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
