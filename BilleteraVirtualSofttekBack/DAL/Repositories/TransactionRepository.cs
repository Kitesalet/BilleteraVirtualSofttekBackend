using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.DAL.Repositories
{

    /// <summary>
    /// The interface implementation to access to transaction data.
    /// </summary>
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI.</param>
        public TransactionRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }


        /// <inheritdoc/>
        public async Task<IEnumerable<Transaction>> GetTransactionsByAccount(int accountId, int page, int units)
        {

            return await _context.Transactions
                                                        .Include(e => e.SourceAccount)
                                                        .Include(t => t.DestinationAccount)
                                                        .Where(t => (t.SourceAccountId == accountId || t.DestinationAccountId == accountId) && t.DeletedDate == null)
                                                        .OrderByDescending(t => t.CreatedDate)
                                                        .Skip((page - 1) * units)
                                                        .Take(units) 
                                                        .ToListAsync();

        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Transaction>> GetTransactionsByClient(int clientId, int page, int units)
        {
            return await _context.Transactions.Include(e => e.SourceAccount)
                                                 .Include(t => t.DestinationAccount)
                                                 .Where(t => t.ClientId == clientId
                                                 && t.DeletedDate == null)
                                                 .OrderByDescending(t => t.CreatedDate)
                                                 .Skip((page - 1) * units)
                                                 .Take(units)
                                                 .ToListAsync();
        }
    }
    }
