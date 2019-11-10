using System.Collections.Generic;
using Livraria.Domain.Interfaces.Servicos;
using Livraria_Avaliacao.AutoMapper;
using Livraria_Avaliacao.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Livraria_Avaliacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IServicoLivros servicoLivros;

        public EstoqueController(IServicoLivros servicoLivros)
        {
            this.servicoLivros = servicoLivros;
        }

        [HttpGet]
        public IEnumerable<LivroDto> Get()
        {
            var livros = servicoLivros.ObterLivrosComEstoqueAbaixoDoMinimoDesejado();
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<LivroDto>>(livros);
        }
    }
}