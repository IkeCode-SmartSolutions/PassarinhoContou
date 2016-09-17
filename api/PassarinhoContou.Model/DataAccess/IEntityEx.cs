using System.Linq;
using System.Threading.Tasks;

namespace PassarinhoContou.Model
{
    public interface IEntityEx<T> where T : class
    {
        void Create(T obj);

        Task CreateAsync(T obj);

        T FindById(int id);

        Task<T> FindByIdAsync(int id);

        IQueryable<T> FindAll();

        void Update(T obj);

        Task UpdateAsync(T obj);

        void Remove(T obj);

        Task RemoveAsync(T obj);
    }
}
