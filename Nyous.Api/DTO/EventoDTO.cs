using System;

namespace Nyous.Api.DTO
{
    public class EventoDTO
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Link { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
