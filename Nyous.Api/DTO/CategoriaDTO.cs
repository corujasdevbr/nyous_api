using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Nyous.Api.DTO
{
    public class CategoriaDTO
    {
        public string Nome { get; set; }

        public string UrlImagem { get; set; }
    }
}
