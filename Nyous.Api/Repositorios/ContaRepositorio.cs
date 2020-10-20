using Nyous.Api.Contexts;
using Nyous.Api.Domains;
using Nyous.Api.Interfaces.Repositorios;
using System.Linq;

namespace Nyous.Api.Repositorios
{
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly NyousContext _context;

        public ContaRepositorio(NyousContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario Register(string nome, string email, string senha, string tipo)
        {
            Usuario usuario = new Usuario() { Nome = nome, Email = email, Senha = senha, Tipo = tipo };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
