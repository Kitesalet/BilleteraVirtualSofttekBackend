using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Entities.Accounts;
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
        /// Performs seeding of PesoAccount objects into the database during migration.
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
                }, new PesoAccount
                {
                    Id = 4,
                    AccountNumber = 4,
                    Alias = "riccad",
                    Balance = 2000,
                    CBU = 532456234,
                    Type = AccountType.Peso,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                });

            /// <summary>
            /// Performs seeding of PesoAccount objects into the database during migration.
            /// </summary>
            /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
            modelBuilder.Entity<DollarAccount>().HasData(
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
                }, new DollarAccount
                {
                    Id = 5,
                    AccountNumber = 5,
                    Alias = "acor",
                    Balance = 4000,
                    CBU = 654334523,
                    Type = AccountType.Dollar,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                });

            /// <summary>
            /// Performs seeding of PesoAccount objects into the database during migration.
            /// </summary>
            /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
            modelBuilder.Entity<CryptoAccount>().HasData(
                new CryptoAccount
                {
                    Id = 3,
                    UUID = Guid.NewGuid(),
                    Balance = 1000,
                    Type = AccountType.Crypto,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                }, new CryptoAccount
                {
                    Id = 6,
                    UUID = Guid.NewGuid(),
                    Balance = 2000,
                    Type = AccountType.Crypto,
                    ClientId = 1,
                    CreatedDate = DateTime.Now
                });
        }
    }
}
