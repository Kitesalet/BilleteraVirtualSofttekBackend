using AutoMapper;
using BilleteraVirtualSofttekBack.DAL.Repositories;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.Models.Interfaces.OtherInterfaces;

namespace IntegradorSofttekImanol.DAL.UnitOfWork
{
    /// <summary>
    /// The implemmentation of a unit that manages repositories and databases.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ClientRepository ClientRepository { get; }
        public AccountRepository AccountRepository { get; }
        public TransactionRepository TransactionRepository { get; }

        /// <summary>
        /// Initializes an instance of UnitOfWork using dependency injection with its parameters
        /// </summary>
        /// <param name="context">AppDbContext with DI</param>
        /// <param name="mapper"></param>
        public UnitOfWork(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            ClientRepository = new ClientRepository(context, configuration);
            AccountRepository = new AccountRepository(context);
            TransactionRepository = new TransactionRepository(context);

        }

        /// <inheritdoc/>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
