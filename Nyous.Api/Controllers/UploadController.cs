using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous.Api.Utils;

namespace Nyous.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] IFormFile arquivo)
        {
            try
            {
                //Verifico se foi enviado um arquivo com a imagem
                if (arquivo != null)
                {
                    var urlImagem = Upload.Local(arquivo);

                    return Ok(new { url = urlImagem });
                }

                return BadRequest(new { 
                    messagem = "Arquivo não informado"
                });
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
