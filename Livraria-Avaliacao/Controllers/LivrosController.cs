using System;
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
    public class LivrosController : ControllerBase
    {
        private readonly IServicoLivros servicoLivros;

        public LivrosController(IServicoLivros servicoLivros)
        {
            this.servicoLivros = servicoLivros;
        }

        [HttpGet]
        public IEnumerable<LivroDto> Get()
        {
            var livros = servicoLivros.ObterLivrosPorOrdemAlfabetica();
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<LivroDto>>(livros);
        }

        [HttpGet("{id}")]
        public LivroDto Get(string id)
        {
            var livro = servicoLivros.Consultar(Guid.Parse(id));
            return AutoMapperConfiguration.Mapper.Map<LivroDto>(livro);
        }

        [HttpPost]
        public bool Post([FromBody]LivroDto livro)
        {
            servicoLivros.Salvar(AutoMapperConfiguration.Mapper.Map<Livro>(livro));
            return true;
        }

        [HttpPut]
        public bool Put([FromBody]LivroDto livro)
        {
            servicoLivros.Alterar(AutoMapperConfiguration.Mapper.Map<Livro>(livro));
            return true;
        }

        [HttpDelete("{id}")]
        public bool Delete(string id)
        {
            servicoLivros.Excluir(Guid.Parse(id));
            return true;
        }
    }
}