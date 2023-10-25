using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using IntegradorSofttekImanol.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace IntegradorSofttekImanol.DAL.Repositories
{
    /// <summary>
    /// The implemmentation that defines common operations for a repository handling entities of type T.
    /// </summary>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        /// <summary>
        /// Initializes an instance of Repository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">AppDbContext with DI.</param>
        public Repository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        /// <inheritdoc/>
        public virtual async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> Delete(int id)
        {
            var entity = await _set.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            if(entity.DeletedDate == null) 
            {
                entity.DeletedDate = DateTime.Now;
            }
            else
            {
                return false;
            } 

            return true;

        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<T>> GetAllAsync(int? page, int? units, params Expression<Func<T,object>>[] includes)
        {
            
            IQueryable<T> query = _set.Where(t => t.DeletedDate == null);

            if(page != null)
            {
                query = query.Skip((int)((page - 1) * units));
            }

            if(units != null)
            {
                query = query.Take((int)units);
            }

            foreach(var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = _set.FirstOrDefault(e => e.Id == id && e.DeletedDate == null);

            return entity;
        }

        /// <inheritdoc/>
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
