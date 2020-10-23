using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyous.Api.Domains;
using Nyous.Api.DTO;
using Nyous.Api.Interfaces.Repositorios;
using System;

namespace Nyous.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepositorio _eventoRepositorio;

        public EventosController(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Cadastrar(EventoDTO evento)
        {
            try
            {
                Evento evt = new Evento();
                evt.Nome = evento.Nome;
                evt.UrlImagem = evento.UrlImagem;
                evt.CategoriaId = evento.CategoriaId;
                evt.Link = evento.Link;
                evt.Descricao = evento.Descricao;

                _eventoRepositorio.Adicionar(evt);

                return Ok(new { data = evt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Alterar(Guid id, EventoDTO evento)
        {
            try
            {
                Evento evt = _eventoRepositorio.BuscarPorId(id);

                if (evt == null)
                {
                    return NotFound();
                }

                evt.Nome = evento.Nome;
                evt.UrlImagem = evento.UrlImagem;
                evt.CategoriaId = evento.CategoriaId;
                evt.Link = evento.Link;
                evt.Descricao = evento.Descricao;

                _eventoRepositorio.Atualizar(evt);

                return Ok(new { data = evt });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                Evento cat = _eventoRepositorio.BuscarPorId(id);

                if (cat == null)
                {
                    return NotFound();
                }

                _eventoRepositorio.Remover(id);

                return Ok(new { data = cat });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var Eventos = _eventoRepositorio.ObterTodos(new string[] { "Categoria"});

                return Ok(new { data = Eventos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("categorias")]
        public IActionResult BuscarEventosComEventos()
        {
            try
            {
                var Eventos = _eventoRepositorio.ObterTodos(new string[] { "categoria" });

                return Ok(new { data = Eventos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Evento cat = _eventoRepositorio.BuscarPorId(id);

                if (cat == null)
                {
                    return NotFound();
                }

                return Ok(new { data = cat });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
