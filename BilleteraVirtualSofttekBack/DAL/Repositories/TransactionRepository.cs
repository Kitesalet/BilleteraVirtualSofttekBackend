using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.DAL.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI.</param>
        public TransactionRepository(AppDbContext context, IConfiguration configuration) : base(context)
        {

            _context = context;
            _configuration = configuration;

        }

        
    }
    }
