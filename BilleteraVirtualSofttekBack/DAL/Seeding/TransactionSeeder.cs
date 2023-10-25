using BilleteraVirtualSofttekBack.Helpers;
using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Enums;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;


namespace IntegradorSofttekImanol.DAL.DBSeeding
{
    /// <summary>
    /// Is the implementation of the interface IEntitySeeder, that seeds Transaction objects into the database
    /// </summary>
    public class TransactionSeeder : IEntitySeeder
    {

        /// <summary>
        /// Performs seeding of Transaction objects into the database during migration.
        /// </summary>
        /// <param name="modelBuilder">Takes a modelBuilder object to use Fluent API.</param>
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    SourceAccountId = 1,
                    Amount = 100,
                    ClientId = 1,
                    CreatedDate = DateTime.Now,
                    Type = TransactionType.Deposit,
                    Concept = TransactionConcept.Deposit
                });

            
        }
    }
}
