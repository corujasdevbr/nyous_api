using Nyous.Api.Contexts;
using Nyous.Api.Domains;
using Nyous.Api.Interfaces.Repositorios;

namespace Nyous.Api.Repositorios
{
    public class EventoRepositorio : Repository<Evento>, IEventoRepositorio
    {

        public EventoRepositorio(NyousContext context) : base(context) { }

    }
}
