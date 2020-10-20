using System;

namespace Nyous.Api.Domains
{
    public class BaseDomain
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
