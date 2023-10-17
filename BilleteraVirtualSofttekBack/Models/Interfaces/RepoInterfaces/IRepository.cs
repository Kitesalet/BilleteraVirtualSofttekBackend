using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces
{
    /// <summary>
    /// This interface defines common operations for a repository handling entities of type T.
    /// </summary>

    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities of type T with pagination.
        /// </summary>
        /// <returns>All of the T entities.</returns>
        Task<IEnumerable<T>> GetAllAsync(int? page, int? units, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets an entity of type T by its id.
        /// </summary>
        /// <param name="id">An int.</param>
        /// <returns>One of the T entities.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Adds an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>An entity by its ID.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Deletes an entity of type T by its id.
        /// </summary>
        /// <param name="id">An int</param>
        /// <returns>
        /// True if it was deleted
        /// |
        /// False if it wasnt deleted
        /// </returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Updates an entity of type T.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);
    }
}
