using System.Collections.Generic;

namespace Nyous.Api.Domains
{
    public class Categoria : BaseDomain
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
