using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Repositories
{
    public interface IRepo<T> where T : class
    {
        public T GetBy();

        public T GetBy(Expression<Func<T, bool>> expression);

        public IQueryable<T> GetAll();

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        public void Add(T entity);

        public void AddRange(IQueryable<T> entities);

        public void Remove(T entity);

        public void RemoveRange(IQueryable<T> entities);

        public void Update(T entity);
    }
}
