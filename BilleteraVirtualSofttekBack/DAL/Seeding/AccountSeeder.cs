using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.Accounts;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Account objects into the database
    /// </summary>
    public class AccountSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Client objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PesoAccount>().HasData(
                new PesoAccount
                {
                    Id = 1,
                    AccountNumber = 1,
                    Alias = "espada",
                    Balance = 1000,
                    CBU = 123456789,
                    Type = AccountType.Peso,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                },
                new DollarAccount
                {
                    Id = 2,
                    AccountNumber = 2,
                    Alias = "roca",
                    Balance = 2000,
                    CBU = 234567891,
                    Type = AccountType.Dollar,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                },
                new CryptoAccount
                {
                    Id = 3,
                    UUID = Guid.NewGuid(),
                    Balance = 1000,
                    Type = AccountType.Crypto,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                }
                ); ;
        }
    }
}
