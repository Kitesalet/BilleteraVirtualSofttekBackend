using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces
{
    /// <summary>
    /// This interface defines a method in charge of seeding the db with various objects.
    /// </summary>
    public interface IEntitySeeder
    {
        /// <summary>
        /// Seeds the database with objects.
        /// </summary>
        /// <param name="modelBuilder">A ModelBuilder.</param>
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
