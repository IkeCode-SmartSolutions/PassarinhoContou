using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System.IO;

namespace PassarinhoContou.Model
{
    public class EFLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new EFLogger();
        }

        public void Dispose()
        {
            // N/A
        }

        private class EFLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
            
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText(@".\EF.LOG", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
    }

    public class EntityEx<T> : IEntityEx<T>, IDisposable where T : BaseModel
    {
        #region .: Context :.

        private PassarinhoContouContext _context;

        protected PassarinhoContouContext DataContext
        {
            get { return _context ?? (_context = new PassarinhoContouContext()); }
        }

        #endregion

        public EntityEx()
        {

        }

        public EntityEx(PassarinhoContouContext context)
        {
            this._context = context;
            var serviceProvider = context.GetInfrastructure<IServiceProvider>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new EFLoggerProvider());
        }

        public void Create(T obj)
        {
            obj.CreationDate = DateTime.UtcNow;
            DataContext.Set<T>().Add(obj);
            DataContext.SaveChanges();
        }

        public async Task CreateAsync(T obj)
        {
            obj.CreationDate = DateTime.UtcNow;
            DataContext.Set<T>().Add(obj);
            await DataContext.SaveChangesAsync();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>()
                .SingleOrDefault(predicate);
        }

        public T FindById(int id)
        {
            return DataContext.Set<T>().SingleOrDefault(i => i.Id == id);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await DataContext.Set<T>().SingleOrDefaultAsync(i => i.Id == id);
        }
        
        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            var ctx = DataContext.Set<T>().Where(predicate);
            return ctx;
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
