using Microsoft.EntityFrameworkCore;
using Nyous.Api.Contexts;
using Nyous.Api.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Nyous.Api.Repositorios
{
    public abstract class BaseRepositorio<T> : IRepository<T> where T : class
    {
        private readonly NyousContext _context;

        protected BaseRepositorio(NyousContext context)
        {
            _context = context;
        }

        public virtual void Adicionar(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Atualizar(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> BuscarPor(Expression<Func<T, bool>> whereExpression, string[] navigationProperties = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (navigationProperties != null)
            {
                query = navigationProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return query.Where(whereExpression).ToList();
        }
        
        public virtual T BuscarPorId(Guid id, string[] navigationProperties = null)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> ObterTodos(string[] navigationProperties = null)
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        public virtual void Dispose()
        {
            _context?.Dispose();
        }


        public void Remover(Guid id)
        {
            T obj = BuscarPorId(id);

            if(obj != null)
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}
