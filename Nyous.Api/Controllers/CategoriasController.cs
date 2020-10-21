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
        //[Authorize(Roles = "Admin" )]
        public IActionResult Cadastrar(CategoriaDTO categoria)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.Nome = categoria.Nome;
                cat.UrlImagem = categoria.UrlImagem;

                _categoriaRepositorio.Adicionar(cat);

                return Ok(cat);
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

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
