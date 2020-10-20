using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nyous.Api.Interfaces.Repositorios
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> ObterTodos(String[] navigationProperties = null);
        IEnumerable<T> BuscarPor(Expression<Func<T, Boolean>> whereExpression, String[] navigationProperties = null);
        T BuscarPorId(Guid id, String[] navigationProperties = null);
        void Adicionar(T obj);
        void Atualizar(T obj);
        void Remover(Guid id);
    }
}
