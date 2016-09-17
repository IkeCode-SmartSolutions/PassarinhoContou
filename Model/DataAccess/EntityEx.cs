using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PassarinhoContou.Model
{
    public class EntityEx<T> : IEntityEx<T>, IDisposable where T : BaseModel
    {
        #region .: Context :.

        private PassarinhoContouContext _context;

        protected PassarinhoContouContext DataContext
        {
            get { return _context ?? (_context = new PassarinhoContouContext()); }
        }

        #endregion

        public void Create(T obj)
        {
            DataContext.Set<T>().Add(obj);
            DataContext.SaveChanges();
        }

        public async Task CreateAsync(T obj)
        {
            DataContext.Set<T>().Add(obj);
            await DataContext.SaveChangesAsync();
        }

        public T FindById(int id)
        {
            return DataContext.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await DataContext.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<T> FindAll()
        {
            return DataContext.Set<T>();
        }

        public void Update(T obj)
        {
            DataContext.Entry(obj).State = EntityState.Modified;
            DataContext.SaveChanges();
        }

        public async Task UpdateAsync(T obj)
        {
            DataContext.Entry(obj).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        public void Remove(T obj)
        {
            DataContext.Set<T>().Remove(obj);
            DataContext.SaveChanges();
        }

        public async Task RemoveAsync(T obj)
        {
            DataContext.Set<T>().Remove(obj);
            await DataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
