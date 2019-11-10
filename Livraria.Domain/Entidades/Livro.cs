using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Domain.Entidades
{
    public class Livro : Entidade
    {
        [MaxLength(150)]
        public string Nome { get; set; }
        [MaxLength(70)]
        public string Autor { get; set; }
        [MaxLength(70)]
        public string Editora { get; set; }
        public DateTime? DataPublicacao { get; set; }

        public int Quantidade { get; set; }

        public int? QuantidadeMinimaCompra { get; set; }

        public bool QuantidadeMenorDoLimiteMinimo()
        {
            if (QuantidadeMinimaCompra == null) return false;
                
            return Quantidade < QuantidadeMinimaCompra;
        }
    }
}
