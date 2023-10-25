using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.Entities.Accounts;
using BilleteraVirtualSofttekBack.Models.Interfaces.RepoInterfaces;
using IntegradorSofttekImanol.DAL.Context;
using IntegradorSofttekImanol.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BilleteraVirtualSofttekBack.DAL.Repositories
{

    /// <summary>
    /// The interface implementation to access to account-related data.
    /// </summary>
    public class AccountRepository : Repository<BaseAccount>, IAccountRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes an instance of UsuarioRepository using dependency injection with its parameters.
        /// </summary>
        /// <param name="context">An AppDbContext with DI.</param>
        public AccountRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        /// <inheritdoc />
        public async Task<IEnumerable<BaseAccount>> GetAllAccountsByClient(int clientId)
        {
            var accountsByUser = await _context.Accounts.Where(a => a.ClientId == clientId && a.DeletedDate == null).OrderBy(a => a.Type).ToListAsync();

            return accountsByUser;
        }

        /// <inheritdoc />
        public async Task<bool> VerifyExistingAccountNumber(int accountNumber)
        {
            bool accountNumberExistsInPeso = await _context.Accounts.OfType<PesoAccount>().AnyAsync(a => a.AccountNumber == accountNumber);

            bool accountNumberExistsInDollar = await _context.Accounts.OfType<DollarAccount>().AnyAsync(a => a.AccountNumber == accountNumber);

            if (accountNumberExistsInPeso == false && accountNumberExistsInDollar == false)
            {

                return false;
            }

            return true;
        }

        /// <inheritdoc />
        public async Task<bool> VerifyExistingAlias(string alias)
        {

            bool aliasExistsInPeso = await _context.Accounts.OfType<PesoAccount>().AnyAsync(a => a.Alias == alias);

            bool aliasExistsInDollar = await _context.Accounts.OfType<DollarAccount>().AnyAsync(a => a.Alias == alias);

            if(aliasExistsInPeso == false && aliasExistsInDollar == false)
            {

                return false;
            }

            return true;
            
        }

        /// <inheritdoc />
        public async Task<bool> VerifyExistingCBU(int cbu)
        {

            bool CBUExistsInPeso = await _context.Accounts.OfType<PesoAccount>().AnyAsync(a => a.CBU == cbu);

            bool CBUExistsInDollar = await _context.Accounts.OfType<DollarAccount>().AnyAsync(a => a.CBU == cbu);

            if(CBUExistsInDollar == false && CBUExistsInDollar == false)
            {
                return false;
            }

            return true;

        }

        /// <inheritdoc />
        public async Task<bool> VerifyExistingUUID(string UUID)
        {

            bool flag = await _context.Accounts.OfType<CryptoAccount>().AnyAsync(c => $"{c.UUID}" == UUID);

            if(flag == true)
            {
                return false;
            }

            return true;

        }

    }
    }
