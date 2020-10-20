using Nyous.Api.Domains;

namespace Nyous.Api.Interfaces.Repositorios
{
    public interface IContaRepositorio
    {
        Usuario Login(string email, string senha);

        Usuario Register(string nome, string email, string senha, string tipo);
    }
}
