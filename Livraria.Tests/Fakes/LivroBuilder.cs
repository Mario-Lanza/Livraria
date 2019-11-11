using Livraria.Domain.Entidades;
using System;

namespace Livraria.Tests.Fakes
{
    public class LivroBuilder
    {
        public const string ID_PADRAO = "12345678-1234-1234-1234-123456789123";
        public const string AUTOR = "Autor";
        public const string EDITORA = "Editora";
        public const int QUANTIDADEMINIMA = 2;
        private readonly Livro livro;
        public LivroBuilder(string nome, int quantidade)
        {
            livro = new Livro
            {
                Nome = nome,
                Quantidade = quantidade
            };
        }
        public LivroBuilder LivroPadrao()
        {
            ComId(ID_PADRAO);
            ComAutor(AUTOR);
            ComEditora(EDITORA);
            ComDataPublicacao(DateTime.Today);
            ComQuantidadeMinima(QUANTIDADEMINIMA);
            return this;
        }

        public LivroBuilder ComId(string id)
        {
            livro.Id = Guid.Parse(id);
            return this;
        }

        public LivroBuilder ComAutor(string autor)
        {
            livro.Autor = autor;
            return this;
        }

        public LivroBuilder ComEditora(string editora)
        {
            livro.Editora = editora;
            return this;
        }

        public LivroBuilder ComDataPublicacao(DateTime dataPublicacao)
        {
            livro.DataPublicacao = dataPublicacao;
            return this;
        }

        public LivroBuilder ComQuantidadeMinima(int quantidadeMinima)
        {
            livro.QuantidadeMinimaCompra = quantidadeMinima;
            return this;
        }

        public Livro Build()
        {
            return livro;
        }
    }
}
