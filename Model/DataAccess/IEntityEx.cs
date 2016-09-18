using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PassarinhoContou.Model
{
    public interface IEntityEx<T> where T : class
    {
        void Create(T obj);

        Task CreateAsync(T obj);

        T Find(Expression<Func<T, bool>> predicate);

        T FindById(int id);

        Task<T> FindByIdAsync(int id);

        IQueryable<T> GetAll();

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);

        void Update(T obj);

        Task UpdateAsync(T obj);

        void Remove(T obj);

        Task RemoveAsync(T obj);
    }
}
