


using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.Entities;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Client objects into the database
    /// </summary>
    public class ClientSeeder : IEntitySeeder
    {
        private readonly IConfiguration _configuration;

        public ClientSeeder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Performs seeding of Client objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Password = EncrypterHelper.Encrypter("random", _configuration["EncryptKey"]),
                    Email = "1@1.com",
                    Name = "random",
                    CreatedDate = DateTime.Now
                }, new Client
                { 
                    Id = 2,
                    Password = EncrypterHelper.Encrypter("random", _configuration["EncryptKey"]),
                    Email = "2@2.com",
                    Name = "random",
                    CreatedDate = DateTime.Now
                }
                ); 
        }
    }
}
