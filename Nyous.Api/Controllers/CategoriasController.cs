using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nyous.Api.Domains;
using Nyous.Api.DTO;
using Nyous.Api.Interfaces.Repositorios;

namespace Nyous.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpPost]
        [Authorize(Roles = "Admin" )]
        public IActionResult Cadastrar(CategoriaDTO categoria)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.Nome = categoria.Nome;
                cat.UrlImagem = categoria.UrlImagem;

                _categoriaRepositorio.Adicionar(cat);

                return Ok(new { data = cat});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Alterar(Guid id, CategoriaDTO categoria)
        {
            try
            {
                Categoria cat = _categoriaRepositorio.BuscarPorId(id);

                if(cat == null)
                {
                    return NotFound();
                }

                cat.Nome = categoria.Nome;
                cat.UrlImagem = categoria.UrlImagem;

                _categoriaRepositorio.Atualizar(cat);

                return Ok(new { data = cat });
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
                Categoria cat = _categoriaRepositorio.BuscarPorId(id);

                if (cat == null)
                {
                    return NotFound();
                }

                _categoriaRepositorio.Remover(id);

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
                var categorias = _categoriaRepositorio.ObterTodos();

                return Ok(new { data = categorias });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("eventos")]
        public IActionResult BuscarCategoriasComEventos()
        {
            try
            {
                var categorias = _categoriaRepositorio.ObterTodos(new string[] { "eventos"} );

                return Ok(new { data = categorias });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Categoria cat = _categoriaRepositorio.BuscarPorId(id);

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
