using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria_Avaliacao.Dto
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public DateTime DataPublicacao { get; set; }

        public int Quantidade { get; set; }

        public int QuantidadeMinimaCompra { get; set; }
    }
}
