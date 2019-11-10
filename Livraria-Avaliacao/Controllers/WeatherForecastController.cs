using System.Collections.Generic;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Servicos;
using Livraria_Avaliacao.AutoMapper;
using Livraria_Avaliacao.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Livraria_Avaliacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IServicoLivros servicoLivros;

        public WeatherForecastController(IServicoLivros servicoLivros)
        {
            this.servicoLivros = servicoLivros;
        }

        [HttpGet]
        public IEnumerable<LivroDto> Get()
        {
            var livros = servicoLivros.ObterLivrosPorOrdemAlfabetica();
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<LivroDto>>(livros);
        }
    }
}
