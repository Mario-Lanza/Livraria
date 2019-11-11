using Livraria_Avaliacao.Dto;
using System;

namespace Livraria.Tests.Fakes
{
    public class LivroDtoBuilder
    {
        private readonly LivroDto livro;
        public LivroDtoBuilder(string nome, int quantidade)
        {
            livro = new LivroDto {
                Nome = nome,
                Quantidade = quantidade
            };
        }

        public LivroDtoBuilder LivroPadrao()
        {
            ComId(LivroBuilder.ID_PADRAO);
            ComAutor(LivroBuilder.AUTOR);
            ComEditora(LivroBuilder.EDITORA);
            ComDataPublicacao(DateTime.Today);
            ComQuantidadeMinima(LivroBuilder.QUANTIDADEMINIMA);
            return this;
        }

        public LivroDtoBuilder ComId(string id)
        {
            livro.Id = Guid.Parse(id);
            return this;
        }

        public LivroDtoBuilder ComAutor(string autor)
        {
            livro.Autor = autor;
            return this;
        }

        public LivroDtoBuilder ComEditora(string editora)
        {
            livro.Editora = editora;
            return this;
        }

        public LivroDtoBuilder ComDataPublicacao(DateTime dataPublicacao)
        {
            livro.DataPublicacao = dataPublicacao;
            return this;
        }

        public LivroDtoBuilder ComQuantidadeMinima(int quantidadeMinima)
        {
            livro.QuantidadeMinima = quantidadeMinima;
            return this;
        }

        public LivroDto Build()
        {
            return livro;
        }
    }
}
