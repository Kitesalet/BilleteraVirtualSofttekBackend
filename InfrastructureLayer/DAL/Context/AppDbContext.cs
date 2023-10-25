using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.DAL.DBSeeding;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
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
            #region FLUENT API REGION


            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.DestinationAccount)
                .WithMany()
                .HasForeignKey(a => a.DestinationAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.SourceAccount)
                .WithMany()
                .HasForeignKey(a => a.SourceAccountId)
                .OnDelete(DeleteBehavior.Restrict);



            #endregion



            #region Seeding config


            var seeder = new List<IEntitySeeder>()
            {
                new ClientSeeder(_configuration),
                new AccountSeeder()
                //new TransactionSeeder()

            };
            

            foreach (var seed in seeder)
            {
                seed.SeedDatabase(modelBuilder);
            }

            #endregion


            base.OnModelCreating(modelBuilder);

            
        }

    }
}
