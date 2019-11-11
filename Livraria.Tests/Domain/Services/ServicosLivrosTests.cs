using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Domain.Interfaces.Servicos;
using Livraria.Domain.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Tests.Domain.Services
{
    [TestFixture]
    public class ServicosLivrosTests
    {
        public IServicoLivros servico;
        public IRepositorioLivros repositorio;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            repositorio = Substitute.For<IRepositorioLivros>();

            servico = new ServicoLivros(repositorio);
        }

        [TearDown]
        public void TearDown()
        {
            repositorio.ClearReceivedCalls();
        }

        [Test]
        public void Deve_chamar_o_metodo_do_repositorio_para_obter_livros_por_ordem_alfabetica()
        {
            servico.ObterLivrosPorOrdemAlfabetica();

            repositorio.Received(1).ObterLivrosPorOrdemAlfabetica();
        }

        [Test]
        public void Deve_chamar_o_metodo_do_repositorio_para_obter_livros_abaixo_do_estoque_minimo()
        {
            servico.ObterLivrosComEstoqueAbaixoDoMinimoDesejado();

            repositorio.Received(1).ObterLivrosComEstoqueAbaixoDoMinimoDesejado();
        }
    }
}
