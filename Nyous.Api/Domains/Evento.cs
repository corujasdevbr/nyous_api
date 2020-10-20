using System;

namespace Nyous.Api.Domains
{
    public class Evento : BaseDomain
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
