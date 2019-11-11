using FluentAssertions;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Infra.Contexto;
using Livraria.Infra.Repositorios;
using Livraria.Tests.Fakes;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Tests.Infra.Repositorios
{
    [TestFixture]
    public class RepositorioLivrosTests
    {
        public IRepositorioLivros repositorio;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            var livros = new List<Livro> {
                new LivroBuilder("Zorro", 3).Build(),
                new LivroBuilder("Arlindo", 2).ComQuantidadeMinima(2).Build(),
                new LivroBuilder("Genivaldo", 1).ComQuantidadeMinima(3).Build(),
            };

            var contexto = MockDbContext<Livro>.Create(livros);

            repositorio = new RepositorioLivros(contexto);
        }

        [Test]
        public void Deve_obter_livros_por_ordem_alfabetica()
        {
            var expected = new List<Livro> {
                new LivroBuilder("Arlindo", 2).Build(),
                new LivroBuilder("Genivaldo", 1).Build(),
                new LivroBuilder("Zorro", 3).Build(),
            };

            var livrosOrdenados = repositorio.ObterLivrosPorOrdemAlfabetica();

            livrosOrdenados.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }

        [Test]
        public void Deve_obter_somente_os_livros_abaixo_do_estoque_minimo()
        {
            var expected = new List<Livro> {
                new LivroBuilder("Genivaldo", 1).ComQuantidadeMinima(3).Build()
            };

            var livrosComEstoqueBaixo = repositorio.ObterLivrosComEstoqueAbaixoDoMinimoDesejado();

            livrosComEstoqueBaixo.Should().HaveCount(1);
            livrosComEstoqueBaixo.Should().BeEquivalentTo(expected);
        }
    }
}
