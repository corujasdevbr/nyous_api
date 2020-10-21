using Nyous.Api.Contexts;
using Nyous.Api.Domains;
using Nyous.Api.Interfaces.Repositorios;

namespace Nyous.Api.Repositorios
{
    public class CategoriaRepositorio : Repository<Categoria>, ICategoriaRepositorio
    {

        public CategoriaRepositorio(NyousContext context) : base(context) { }

    }
}
