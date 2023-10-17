

using BilleteraVirtualSofttekBack.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.Context
{
    /// <summary>
    /// Represents the application's database context that manages database tables.
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes an instance of AppDbContext.
        /// </summary>
        /// <param name="options">A DbContextOptions.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {

            _configuration = configuration;

        }


        #region Database tables
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BaseAccount> Accounts { get; set; }

        #endregion

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Seeding config

            /*
            var seeder = new List<IEntitySeeder>()
            {
                new ProjectSeeder(),
                new ServiceSeeder(),
                new WorkSeeder(),
                new UserSeeder(_configuration),
            };
            

            foreach (var seed in seeder)
            {
                seed.SeedDatabase(modelBuilder);
            }

            #endregion


            base.OnModelCreating(modelBuilder);

            */
        }

    }
}
